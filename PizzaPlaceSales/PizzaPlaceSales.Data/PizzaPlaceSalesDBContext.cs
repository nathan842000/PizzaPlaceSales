using Microsoft.EntityFrameworkCore;

namespace PizzaPlaceSales.Data
{
    public class PizzaPlaceSalesDBContext : DbContext
    {
        public PizzaPlaceSalesDBContext(DbContextOptions<PizzaPlaceSalesDBContext> options) : base(options)
        {

        }
    }
}
