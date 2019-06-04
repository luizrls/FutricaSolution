using FSL.XF3.Api;
using FSL.XF3.Api.Models;
using Futrica.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Futrica.Services
{
    public interface ICustomersApiClient : IApiClient
    {
        Task<BaseApiResult<List<Usuario>>> GetAllCustomers();
    }
}
