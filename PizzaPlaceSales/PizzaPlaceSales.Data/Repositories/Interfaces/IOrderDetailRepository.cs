using System.Data;

namespace PizzaPlaceSales.Data.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task BulkInsert(DataTable dataTable);
    }
}
