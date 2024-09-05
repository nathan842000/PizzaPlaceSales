using PizzaPlaceSales.Data.Entities;
using System.Data;

namespace PizzaPlaceSales.Data.Repositories.Interfaces
{
    public interface IPizzaTypeRepository
    {
        Task<List<string>> GetAllPizzaTypeIds();
        Task BulkInsert(DataTable dataTable);
    }
}
