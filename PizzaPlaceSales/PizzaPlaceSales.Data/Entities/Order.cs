using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSales.Data.Entities
{
    public class Order
    {
        [Key]
        public required int OrderId { get; set; }
        public required DateOnly Date { get; set; }
        public required TimeOnly Time { get; set; }
    }
}
