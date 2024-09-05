using Microsoft.Data.SqlClient;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.DTOs.Settings;
using System.Data;

namespace PizzaPlaceSales.Data.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ConnectionStringSettings _connectionStringSettings;
        public OrderDetailRepository(ConnectionStringSettings connectionStringSettings)
        {
            _connectionStringSettings = connectionStringSettings;
        }
        public async Task BulkInsert(DataTable dataTable)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_connectionStringSettings.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                SqlBulkCopyColumnMapping mapOrderDetailsId = new SqlBulkCopyColumnMapping();
                mapOrderDetailsId.SourceColumn = "order_details_id";
                mapOrderDetailsId.DestinationColumn = "OrderDetailsId";
                bulkCopy.ColumnMappings.Add(mapOrderDetailsId);

                SqlBulkCopyColumnMapping mapOrderId = new SqlBulkCopyColumnMapping();
                mapOrderId.SourceColumn = "order_id";
                mapOrderId.DestinationColumn = "OrderId";
                bulkCopy.ColumnMappings.Add(mapOrderId);

                SqlBulkCopyColumnMapping mapPizzaId = new SqlBulkCopyColumnMapping();
                mapPizzaId.SourceColumn = "pizza_id";
                mapPizzaId.DestinationColumn = "PizzaId";
                bulkCopy.ColumnMappings.Add(mapPizzaId);

                SqlBulkCopyColumnMapping mapQuantity = new SqlBulkCopyColumnMapping();
                mapQuantity.SourceColumn = "quantity";
                mapQuantity.DestinationColumn = "Quantity";
                bulkCopy.ColumnMappings.Add(mapQuantity);

                bulkCopy.DestinationTableName = "OrderDetails";
                await bulkCopy.WriteToServerAsync(dataTable);
            }
        }
    }
}
