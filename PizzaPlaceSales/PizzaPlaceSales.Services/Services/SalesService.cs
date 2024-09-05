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
