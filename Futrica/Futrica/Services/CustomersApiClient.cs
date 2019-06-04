using FSL.XF3.Api;
using FSL.XF3.Api.Models;
using Futrica.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Futrica.Services
{
    public sealed class CustomersApiClient : ApiClient, ICustomersApiClient
    {
        public CustomersApiClient()
            : base("http://localhost:54119/api")
        {

        }

        public async Task<BaseApiResult<List<Usuario>>> GetAllCustomers()
        {
            return await FslApiClient.Current.GetAsync<List<Usuario>>("Usuarios");
        }
    }
}
