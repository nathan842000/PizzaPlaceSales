namespace PizzaPlaceSales.DTOs.Sales
{
    public class SalesByCategory
    {
        public required string Category { get; set; }
        public decimal TotalSales { get; set; }
    }
}
