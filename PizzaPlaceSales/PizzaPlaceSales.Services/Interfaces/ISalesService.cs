using PizzaPlaceSales.DTOs.Sales;

namespace PizzaPlaceSales.Services.Interfaces
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesByYear>> GetTotalSalesByYear();
        Task<IEnumerable<SalesByYearAndMonth>> GetTotalSalesByYearAndMonth();
        Task<IEnumerable<Top10SellingPizzas>> GetTop10SellingPizzasByQuantity();
    }
}
