using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.DTOs.Sales;
using PizzaPlaceSales.Services.Interfaces;

namespace PizzaPlaceSales.Services.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        public SalesService(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task<IEnumerable<Top10SellingPizzas>> GetTop10SellingPizzasByQuantity()
        {
            return await _salesRepository.GetTop10SellingPizzasByQuantity();
        }

        public async Task<IEnumerable<SalesByCategory>> GetTotalSalesByCategory()
        {
            return await _salesRepository.GetTotalSalesByCategory();
        }

        public async Task<IEnumerable<SalesByYear>> GetTotalSalesByYear()
        {
            return await _salesRepository.GetTotalSalesByYear();
        }

        public async Task<IEnumerable<SalesByYearAndMonth>> GetTotalSalesByYearAndMonth()
        {
            return await _salesRepository.GetTotalSalesByYearAndMonth();
        }
    }
}
