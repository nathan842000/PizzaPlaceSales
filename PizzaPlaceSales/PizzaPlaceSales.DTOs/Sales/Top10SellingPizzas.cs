namespace PizzaPlaceSales.DTOs.Sales
{
    public class Top10SellingPizzas
    {
        public required string PizzaId { get; set; }
        public required string PizzaTypeId { get; set; }
        public required string Name { get; set; }
        public int TotalQuantitySold { get; set; }
    }
}
