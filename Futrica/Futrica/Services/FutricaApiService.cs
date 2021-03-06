﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Futrica.Services
{
    public class FutricaApiService
    {
        public static async Task<object> CallServiceAsync<T>(string url, string operation, object requestBodyObject, string method, string username = null,
       string password = null) where T : class
        {
            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = method;
            webReq.Accept = "application/json";

            //Add basic authentication header if username is supplied
            if (!string.IsNullOrEmpty(username))
            {
                webReq.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
            }

            //Add key to header if operation is supplied
            if (!string.IsNullOrEmpty(operation))
            {
                webReq.Headers["Operation"] = operation;
            }

            //Serialize request object as JSON and write to request body
            if (requestBodyObject != null)
            {
                var requestBody = JsonConvert.SerializeObject(requestBodyObject);
                webReq.ContentLength = requestBody.Length;
                var streamWriter = new StreamWriter(webReq.GetRequestStream(), Encoding.ASCII);
                streamWriter.Write(requestBody);
                streamWriter.Close();
            }

            try
            {
                var response = await webReq.GetResponseAsync();

                var streamReader = new StreamReader(response.GetResponseStream());

                var responseContent = streamReader.ReadToEnd().Trim();

                var jsonObject = JsonConvert.DeserializeObject<T>(responseContent);

                return jsonObject;
            }
            catch (WebException e)
            {
                Console.WriteLine("\r\nWebException Raised. The following error occured : {0}", e.Status);
                return default;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
                return default;
            }
        }
    }
}
