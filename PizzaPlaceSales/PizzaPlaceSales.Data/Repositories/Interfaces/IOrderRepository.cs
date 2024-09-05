using System.Data;

namespace PizzaPlaceSales.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task BulkInsert(DataTable dataTable);
        Task<List<int>> GetAllOrderIds();
    }
}
