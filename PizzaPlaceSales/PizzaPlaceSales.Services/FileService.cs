using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.Services.Interfaces;

namespace PizzaPlaceSales.Services
{
    public class FileService : IFileService
    {
        public bool IsValidCsvFile(IFormFile file)
        {
            return new FileInfo(file.FileName).Extension.ToLower() == ".csv";
        }
    }
}
