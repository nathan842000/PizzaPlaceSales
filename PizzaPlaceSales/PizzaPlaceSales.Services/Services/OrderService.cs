using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.Services.Interfaces;

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
            await _orderRepository.BulkInsert(orderTable);
        }
    }
}
