using PizzaPlaceSales.DTOs.Sales;

namespace PizzaPlaceSales.Data.Repositories.Interfaces
{
    public interface ISalesRepository
    {
        Task<IEnumerable<SalesByYear>> GetTotalSalesByYear();
        Task<IEnumerable<SalesByYearAndMonth>> GetTotalSalesByYearAndMonth();
        Task<IEnumerable<Top10SellingPizzas>> GetTop10SellingPizzasByQuantity();
        Task<IEnumerable<SalesByCategory>> GetTotalSalesByCategory();
    }
}
