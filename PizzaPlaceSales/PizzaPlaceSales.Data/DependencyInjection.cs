using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PizzaPlaceSales.DTOs.Settings;
using Microsoft.EntityFrameworkCore;

namespace PizzaPlaceSales.Data
{
    public static class DependencyInjection
    {
        public static void ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringSettings = new ConnectionStringSettings();
            configuration.GetSection("ConnectionStrings").Bind(connectionStringSettings);
            services.AddSingleton(connectionStringSettings);
            services.AddDbContext<PizzaPlaceSalesDBContext>(options => options.UseSqlServer(connectionStringSettings.ConnectionString));

            services.AddScoped<IPizzaTypeRepository, PizzaTypeRepository>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
        }
    }
}
