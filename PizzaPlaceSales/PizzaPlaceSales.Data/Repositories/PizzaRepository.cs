using Microsoft.Data.SqlClient;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.DTOs.Settings;
using System.Data;

namespace PizzaPlaceSales.Data.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly ConnectionStringSettings _connectionStringSettings;
        public PizzaRepository(ConnectionStringSettings connectionStringSettings)
        {
            _connectionStringSettings = connectionStringSettings;
        }
        public async Task BulkInsert(DataTable dataTable)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_connectionStringSettings.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                SqlBulkCopyColumnMapping mapPizzaId = new SqlBulkCopyColumnMapping();
                mapPizzaId.SourceColumn = "pizza_id";
                mapPizzaId.DestinationColumn = "PizzaId";
                bulkCopy.ColumnMappings.Add(mapPizzaId);

                SqlBulkCopyColumnMapping mapPizzaTypeId = new SqlBulkCopyColumnMapping();
                mapPizzaTypeId.SourceColumn = "pizza_type_id";
                mapPizzaTypeId.DestinationColumn = "PizzaTypeId";
                bulkCopy.ColumnMappings.Add(mapPizzaTypeId);

                SqlBulkCopyColumnMapping mapSize = new SqlBulkCopyColumnMapping();
                mapSize.SourceColumn = "size";
                mapSize.DestinationColumn = "Size";
                bulkCopy.ColumnMappings.Add(mapSize);

                SqlBulkCopyColumnMapping mapPrice = new SqlBulkCopyColumnMapping();
                mapPrice.SourceColumn = "price";
                mapPrice.DestinationColumn = "Price";
                bulkCopy.ColumnMappings.Add(mapPrice);

                bulkCopy.DestinationTableName = "Pizzas";
                await bulkCopy.WriteToServerAsync(dataTable);
            }
        }
    }
}
