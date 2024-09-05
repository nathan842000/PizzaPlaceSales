using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSales.Data.Entities
{
    public class OrderDetail
    {
        [Key]
        public required int OrderDetailsId { get; set; }
        public required int OrderId { get; set; }
        public required string PizzaId { get; set; }
        public required int Quantity { get; set; }
    }
}
