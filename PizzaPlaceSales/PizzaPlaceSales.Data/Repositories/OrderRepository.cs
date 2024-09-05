using Microsoft.Data.SqlClient;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.DTOs.Settings;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PizzaPlaceSales.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ConnectionStringSettings _connectionStringSettings;
        public OrderRepository(ConnectionStringSettings connectionStringSettings)
        {
            _connectionStringSettings = connectionStringSettings;
        }
        public async Task BulkInsert(DataTable dataTable)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_connectionStringSettings.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                SqlBulkCopyColumnMapping mapOrderId = new SqlBulkCopyColumnMapping();
                mapOrderId.SourceColumn = "order_id";
                mapOrderId.DestinationColumn = "OrderId";
                bulkCopy.ColumnMappings.Add(mapOrderId);

                SqlBulkCopyColumnMapping mapDate = new SqlBulkCopyColumnMapping();
                mapDate.SourceColumn = "date";
                mapDate.DestinationColumn = "Date";
                bulkCopy.ColumnMappings.Add(mapDate);

                SqlBulkCopyColumnMapping mapTime = new SqlBulkCopyColumnMapping();
                mapTime.SourceColumn = "time";
                mapTime.DestinationColumn = "Time";
                bulkCopy.ColumnMappings.Add(mapTime);

                bulkCopy.DestinationTableName = "Orders";
                await bulkCopy.WriteToServerAsync(dataTable);
            }
        }
    }
}
