using SuperShop.Prism.Models;
using System.Threading.Tasks;

namespace SuperShop.Prism.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}
