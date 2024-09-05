using PizzaPlaceSales.DTOs.Sales;

namespace PizzaPlaceSales.Data.Repositories.Interfaces
{
    public interface ISalesRepository
    {
        Task<IEnumerable<SalesByYear>> GetTotalSalesByYear();
        Task<IEnumerable<SalesByYearAndMonth>> GetTotalSalesByYearAndMonth();
    }
}
