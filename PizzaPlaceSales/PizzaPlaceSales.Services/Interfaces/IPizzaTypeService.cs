using Microsoft.AspNetCore.Http;

namespace PizzaPlaceSales.Services.Interfaces
{
    public interface IPizzaTypeService
    {
        Task ImportFile(IFormFile file);
    }
}
