using GastosEmpleado.Common.Models;
using System.Threading.Tasks;


namespace GastosEmpleado.Common.Services
{
   public interface IApiService
    {
        Task<Response> GetEmployeesAsync(string Document, string urlBase, string servicePrefix, string controller);

    }
}
