using Microsoft.AspNetCore.Http;

namespace PizzaPlaceSales.DTOs.Imports
{
    public class PizzasAndOrders
    {
        public required IFormFile PizzaTypesCSVFile { get; set; }
        public required IFormFile PizzasCSVFile { get; set; }
        public required IFormFile OrdersCSVFile { get; set; }
        public required IFormFile OrderDetailsCSVFile { get; set; }
    }
}