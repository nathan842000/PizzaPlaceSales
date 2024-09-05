using Microsoft.AspNetCore.Http;

namespace PizzaPlaceSales.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task ImportFile(IFormFile file);
    }
}
