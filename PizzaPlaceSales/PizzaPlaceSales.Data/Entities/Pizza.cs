using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSales.Data.Entities
{
    public class Pizza
    {
        [Key]
        public required string PizzaId { get; set; }
        public required string PizzaTypeId { get; set; }
        public required string Size { get; set; }
        public required decimal Price { get; set; }
    }
}
