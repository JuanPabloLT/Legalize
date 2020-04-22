using Legalize.Common.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Legalize.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetLegalizeAsync(string EmployeeId, string urlBase, string servicePrefix, string controller);
        
        Task<bool> CheckConnectionAsync(string url);

    }

}
