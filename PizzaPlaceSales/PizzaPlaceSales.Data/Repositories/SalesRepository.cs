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

        public async Task<IEnumerable<Top10SellingPizzas>> GetTop10SellingPizzasByQuantity()
        {
            var topPizzas = await
                (from od in _dbContext.OrderDetails
                 join p in _dbContext.Pizzas on od.PizzaId equals p.PizzaId
                 join pt in _dbContext.PizzaTypes on p.PizzaTypeId equals pt.PizzaTypeId
                 group new { p, pt, od.Quantity } by new { p.PizzaId, pt.PizzaTypeId, pt.Name } into g
                 select new
                 {
                     PizzaId = g.Key.PizzaId,
                     PizzaTypeId = g.Key.PizzaTypeId,
                     Name = g.Key.Name,
                     TotalQuantitySold = g.Sum(x => x.Quantity)
                 })
                .OrderByDescending(result => result.TotalQuantitySold)
                .Take(10)
                .ToListAsync();

            var result = new List<Top10SellingPizzas>();
            foreach (var item in topPizzas)
                result.Add(new Top10SellingPizzas
                {
                    PizzaId = item.PizzaId,
                    PizzaTypeId = item.PizzaTypeId,
                    Name = item.Name,
                    TotalQuantitySold= item.TotalQuantitySold
                });
            return result;
        }

        public async Task<IEnumerable<SalesByCategory>> GetTotalSalesByCategory()
        {
            var salesByCategory = await
                (from od in _dbContext.OrderDetails
                 join p in _dbContext.Pizzas on od.PizzaId equals p.PizzaId
                 join pt in _dbContext.PizzaTypes on p.PizzaTypeId equals pt.PizzaTypeId
                 group new { od.Quantity, p.Price, pt.Category } by pt.Category into g
                 select new
                 {
                     Category = g.Key,
                     TotalSales = g.Sum(x => x.Quantity * x.Price)
                 })
                .OrderByDescending(result => result.TotalSales)
                .ToListAsync();

            var result = new List<SalesByCategory>();
            foreach (var item in salesByCategory)
                result.Add(new SalesByCategory
                {
                    Category = item.Category,
                    TotalSales = item.TotalSales,
                });
            return result;
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
