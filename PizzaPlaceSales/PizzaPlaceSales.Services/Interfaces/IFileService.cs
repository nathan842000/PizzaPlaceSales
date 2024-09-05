using Microsoft.AspNetCore.Http;

namespace PizzaPlaceSales.Services.Interfaces
{
    public interface IFileService
    {
        bool IsValidCsvFile(IFormFile file);
    }
}
