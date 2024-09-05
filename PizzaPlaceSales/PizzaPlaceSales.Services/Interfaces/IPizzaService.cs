using Microsoft.AspNetCore.Http;

namespace PizzaPlaceSales.Services.Interfaces
{
    public interface IPizzaService
    {
        Task ImportFile(IFormFile file);
    }
}
