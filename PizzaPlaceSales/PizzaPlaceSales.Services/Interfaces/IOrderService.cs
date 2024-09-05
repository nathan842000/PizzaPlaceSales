using Microsoft.AspNetCore.Http;

namespace PizzaPlaceSales.Services.Interfaces
{
    public interface IOrderService
    {
        Task ImportFile(IFormFile file);
    }
}
