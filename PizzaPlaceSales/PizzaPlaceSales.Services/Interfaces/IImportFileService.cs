using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.DTOs.Imports;

namespace PizzaPlaceSales.Services.Interfaces
{
    public interface IImportFileService
    {
        Task ImportFile(PizzasAndOrders pizzasAndOrders);
    }
}
