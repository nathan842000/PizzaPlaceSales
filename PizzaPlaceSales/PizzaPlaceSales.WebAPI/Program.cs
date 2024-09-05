using PizzaPlaceSales.Data;
using PizzaPlaceSales.Services;

namespace PizzaPlaceSales.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.            

            builder.Services.AddControllers();
            builder.Services.ConfigureServices(builder.Configuration);
            builder.Services.ConfigureRepositories();

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
    }
}
