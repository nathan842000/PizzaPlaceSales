using Microsoft.AspNetCore.Http;
using System.Data;

namespace PizzaPlaceSales.Services.Interfaces
{
    public interface IDataTableService
    {
        DataTable CsvToDataTable(IFormFile file);
    }
}
