using Microsoft.EntityFrameworkCore;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.DTOs.Sales;

namespace PizzaPlaceSales.Data.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly PizzaPlaceSalesDBContext _dbContext;
        public SalesRepository(PizzaPlaceSalesDBContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<SalesByYear>> GetTotalSalesByYear()
        {
            var salesByYear = await
                (from o in _dbContext.Orders
                 join od in _dbContext.OrderDetails on o.OrderId equals od.OrderId
                 join p in _dbContext.Pizzas on od.PizzaId equals p.PizzaId
                 group new { od, p } by o.Date.Year into g
                 select new
                 {
                     ByYear = g.Key,
                     TotalSales = g.Sum(x => x.od.Quantity * x.p.Price)
                 })
                .OrderBy(result => result.ByYear)
                .ToListAsync();

            var result = new List<SalesByYear>();
            foreach (var item in salesByYear)
                result.Add(new SalesByYear
                {
                    Year = item.ByYear,
                    TotalSales = item.TotalSales,
                });

            return result;
        }

        public async Task<IEnumerable<SalesByYearAndMonth>> GetTotalSalesByYearAndMonth()
        {
            var salesByYearMonth = await 
                (from o in _dbContext.Orders
                 join od in _dbContext.OrderDetails on o.OrderId equals od.OrderId
                 join p in _dbContext.Pizzas on od.PizzaId equals p.PizzaId
                 group new { od, p } by new { Year = o.Date.Year, Month = o.Date.Month } into g
                 select new
                 {
                     SalesYear = g.Key.Year,
                     SalesMonth = g.Key.Month,
                     TotalSales = g.Sum(x => x.od.Quantity * x.p.Price)
                 })
                .OrderBy(result => result.SalesYear)
                .ThenBy(result => result.SalesMonth)
                .ToListAsync();

            var result = new List<SalesByYearAndMonth>();
            foreach (var item in salesByYearMonth)
                result.Add(new SalesByYearAndMonth
                {
                    Year = item.SalesYear,
                    MonthName = GetMonthName(item.SalesMonth),
                    TotalSales = item.TotalSales
                });
            return result;
        }

        private string GetMonthName(int monthNumber)
        {
            if (monthNumber < 1 || monthNumber > 12)
                throw new ArgumentOutOfRangeException(nameof(monthNumber), "Month number must be between 1 and 12.");

            string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return monthNames[monthNumber - 1];
        }
    }
}
