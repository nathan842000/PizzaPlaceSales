using System.Data;

namespace PizzaPlaceSales.Data.Repositories.Interfaces
{
    public interface IPizzaRepository
    {
        Task BulkInsert(DataTable dataTable);
    }
}
