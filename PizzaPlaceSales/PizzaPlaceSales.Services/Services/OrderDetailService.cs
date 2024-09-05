using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.Services.Interfaces;
using System.Data;

namespace PizzaPlaceSales.Services.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IFileService _fileService;
        private readonly IDataTableService _dataTableService;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IFileService fileService, IDataTableService dataTableService, IOrderDetailRepository orderDetailRepository)
        {
            _fileService = fileService;
            _dataTableService = dataTableService;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task ImportFile(IFormFile file)
        {
            if (!_fileService.IsValidCsvFile(file))
                throw new InvalidDataException("You can only upload with an extension of *.csv.");

            var orderDetailTable = _dataTableService.CsvToDataTable(file);
            var existingOrderDetailsIds = await _orderDetailRepository.GetAllOrderDetailsIds();
            var orderDetailsIdsToInsert = new List<int>();
            foreach (DataRow row in orderDetailTable.Rows)
                orderDetailsIdsToInsert.Add(Convert.ToInt32(row["order_details_id"]));

            var existingRecordCounter = orderDetailsIdsToInsert.Count(pi => existingOrderDetailsIds.Any(e => e == pi));
            if (existingRecordCounter <= 0) // bulk insert if OrderDetailsIds did not exist
                await _orderDetailRepository.BulkInsert(orderDetailTable);
        }
    }
}
