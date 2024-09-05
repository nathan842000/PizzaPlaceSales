using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.Services.Interfaces;
using System.Data;
using System.Globalization;

namespace PizzaPlaceSales.Services.Services
{
    public class DataTableService : IDataTableService
    {
        public DataTable CsvToDataTable(IFormFile file)
        {
            // Create a DataTable to store CSV data
            var dataTable = new DataTable();

            // Read the uploaded CSV file using a stream
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                // Use CsvHelper to read the CSV
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true, // Assumes the first row is the header
                };

                using (var csvReader = new CsvReader(stream, config))
                {
                    using (var dr = new CsvDataReader(csvReader))
                    {
                        // Load data into the DataTable
                        dataTable.Load(dr);
                    }
                }
            }

            return dataTable;
        }

    }
}
