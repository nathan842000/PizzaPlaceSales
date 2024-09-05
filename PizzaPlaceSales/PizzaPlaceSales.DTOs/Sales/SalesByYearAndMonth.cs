namespace PizzaPlaceSales.DTOs.Sales
{
    public class SalesByYearAndMonth
    {
        public int Year { get; set; }
        public string? MonthName { get; set; }
        public decimal TotalSales { get; set; }
    }
}
