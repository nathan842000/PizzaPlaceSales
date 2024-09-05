using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.Services.Interfaces;
using System.Data;

namespace PizzaPlaceSales.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IFileService _fileService;
        private readonly IDataTableService _dataTableService;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IFileService fileService, IDataTableService dataTableService, IOrderRepository orderRepository)
        {
            _fileService = fileService;
            _dataTableService = dataTableService;
            _orderRepository = orderRepository;
        }
        public async Task ImportFile(IFormFile file)
        {
            if (!_fileService.IsValidCsvFile(file))
                throw new InvalidDataException("You can only upload with an extension of *.csv.");

            var orderTable = _dataTableService.CsvToDataTable(file);
            var existingOrderIds = await _orderRepository.GetAllOrderIds();
            var orderIdsToInsert = new List<int>();
            foreach (DataRow row in orderTable.Rows)
                orderIdsToInsert.Add(Convert.ToInt32(row["order_id"]));

            var existingRecordCounter = orderIdsToInsert.Count(pi => existingOrderIds.Any(e => e == pi));
            if (existingRecordCounter <= 0) // bulk insert if OrderIds did not exist
                await _orderRepository.BulkInsert(orderTable);
        }
    }
}
