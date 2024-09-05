using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.DTOs.Settings;
using System.Data;

namespace PizzaPlaceSales.Data.Repositories
{
    public class PizzaTypeRepository : IPizzaTypeRepository
    {
        private readonly PizzaPlaceSalesDBContext _dbContext;
        private readonly ConnectionStringSettings _connectionStringSettings;
        public PizzaTypeRepository(PizzaPlaceSalesDBContext dBContext, ConnectionStringSettings connectionStringSettings)
        {
            _dbContext = dBContext;
            _connectionStringSettings = connectionStringSettings;
        }
        public async Task BulkInsert(DataTable dataTable)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_connectionStringSettings.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                SqlBulkCopyColumnMapping mapPizzaTypeId = new SqlBulkCopyColumnMapping();
                mapPizzaTypeId.SourceColumn = "pizza_type_id";
                mapPizzaTypeId.DestinationColumn = "PizzaTypeId";
                bulkCopy.ColumnMappings.Add(mapPizzaTypeId);

                SqlBulkCopyColumnMapping mapName = new SqlBulkCopyColumnMapping();
                mapName.SourceColumn = "name";
                mapName.DestinationColumn = "Name";
                bulkCopy.ColumnMappings.Add(mapName);

                SqlBulkCopyColumnMapping mapCategory = new SqlBulkCopyColumnMapping();
                mapCategory.SourceColumn = "category";
                mapCategory.DestinationColumn = "Category";
                bulkCopy.ColumnMappings.Add(mapCategory);

                SqlBulkCopyColumnMapping mapIngredients = new SqlBulkCopyColumnMapping();
                mapIngredients.SourceColumn = "ingredients";
                mapIngredients.DestinationColumn = "Ingredients";
                bulkCopy.ColumnMappings.Add(mapIngredients);

                bulkCopy.DestinationTableName = "PizzaTypes";
                await bulkCopy.WriteToServerAsync(dataTable);
            }
        }

        public async Task<List<string>> GetAllPizzaTypeIds()
        {
            return await _dbContext.PizzaTypes.Select(x => x.PizzaTypeId).ToListAsync();
        }
    }
}
