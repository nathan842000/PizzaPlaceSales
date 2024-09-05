using System.Data;

namespace PizzaPlaceSales.Data.Repositories.Interfaces
{
    public interface IPizzaTypeRepository
    {
        Task BulkInsert(DataTable dataTable);
    }
}
