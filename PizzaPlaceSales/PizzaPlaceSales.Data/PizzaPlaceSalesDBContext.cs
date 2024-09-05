using Microsoft.EntityFrameworkCore;
using PizzaPlaceSales.Data.Entities;

namespace PizzaPlaceSales.Data
{
    public class PizzaPlaceSalesDBContext : DbContext
    {
        public PizzaPlaceSalesDBContext(DbContextOptions<PizzaPlaceSalesDBContext> options) : base(options)
        {

        }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
