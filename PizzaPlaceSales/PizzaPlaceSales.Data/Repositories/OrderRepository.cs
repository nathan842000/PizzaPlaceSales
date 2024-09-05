using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.DTOs.Settings;
using System.Data;

namespace PizzaPlaceSales.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaPlaceSalesDBContext _dbContext;
        private readonly ConnectionStringSettings _connectionStringSettings;
        public OrderRepository(PizzaPlaceSalesDBContext dBContext, ConnectionStringSettings connectionStringSettings)
        {
            _dbContext = dBContext;
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

        public async Task<List<int>> GetAllOrderIds()
        {
            return await _dbContext.Orders.Select(x => x.OrderId).ToListAsync();
        }
    }
}
