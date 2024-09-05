using PizzaPlaceSales.Data.Repositories;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.DTOs.Settings;
using PizzaPlaceSales.Services;
using PizzaPlaceSales.Services.Interfaces;

namespace PizzaPlaceSales.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            ConfigureSettings(builder);
            ConfigureServices(builder);
            ConfigureRepositories(builder);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void ConfigureSettings(WebApplicationBuilder builder)
        {
            var connectionStringSettings = new ConnectionStringSettings();
            builder.Configuration.GetSection("ConnectionStrings").Bind(connectionStringSettings);
            builder.Services.AddSingleton(connectionStringSettings);
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IImportFileService, ImportFileService>();
            builder.Services.AddScoped<IDataTableService, DataTableService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IPizzaTypeService, PizzaTypeService>();
            builder.Services.AddScoped<IPizzaService, PizzaService>();
        }

        private static void ConfigureRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPizzaTypeRepository, PizzaTypeRepository>();
            builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
        }
    }
}
