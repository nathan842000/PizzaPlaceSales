using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSales.Data.Entities
{
    public class PizzaType
    {
        [Key]
        public required string PizzaTypeId { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public required string Ingredients { get; set; }
    }
}
