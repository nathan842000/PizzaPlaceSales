using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace PizzaPlaceSales.Data
{
    public static class DependencyInjection
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPizzaTypeRepository, PizzaTypeRepository>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        }
    }
}
