using PizzaPlaceSales.DTOs.Imports;
using PizzaPlaceSales.Services.Interfaces;

namespace PizzaPlaceSales.Services.Services
{
    public class ImportFileService : IImportFileService
    {
        private readonly IFileService _fileService;
        private readonly IPizzaTypeService _pizzaTypeService;
        private readonly IPizzaService _pizzaService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public ImportFileService(IPizzaTypeService pizzaTypeService, 
            IFileService fileService, 
            IPizzaService pizzaService,
            IOrderService orderService,
            IOrderDetailService orderDetailService
        )
        {
            _fileService = fileService;
            _pizzaTypeService = pizzaTypeService;
            _pizzaService = pizzaService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        public async Task ImportFile(PizzasAndOrders pizzasAndOrders)
        {
            if (!_fileService.IsValidCsvFile(pizzasAndOrders.PizzaTypesCSVFile)
                || !_fileService.IsValidCsvFile(pizzasAndOrders.PizzasCSVFile)
                || !_fileService.IsValidCsvFile(pizzasAndOrders.OrdersCSVFile)
                || !_fileService.IsValidCsvFile(pizzasAndOrders.OrderDetailsCSVFile)
            )
                throw new InvalidDataException("All files must be csv.");

            await _pizzaTypeService.ImportFile(pizzasAndOrders.PizzaTypesCSVFile);
            await _pizzaService.ImportFile(pizzasAndOrders.PizzasCSVFile);
            await _orderService.ImportFile(pizzasAndOrders.OrdersCSVFile);
            await _orderDetailService.ImportFile(pizzasAndOrders.OrderDetailsCSVFile);
        }
    }
}
