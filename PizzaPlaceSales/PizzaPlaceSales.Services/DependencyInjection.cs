﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaPlaceSales.DTOs.Settings;
using PizzaPlaceSales.Services.Interfaces;
using PizzaPlaceSales.Services.Services;

namespace PizzaPlaceSales.Services
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IImportFileService, ImportFileService>();
            services.AddScoped<IDataTableService, DataTableService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IPizzaTypeService, PizzaTypeService>();
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<ISalesService, SalesService>();
        }
    }
}
