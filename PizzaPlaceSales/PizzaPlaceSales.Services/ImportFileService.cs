using PizzaPlaceSales.DTOs.Imports;
using PizzaPlaceSales.Services.Interfaces;

namespace PizzaPlaceSales.Services
{
    public class ImportFileService : IImportFileService
    {
        private readonly IFileService _fileService;
        private readonly IPizzaTypeService _pizzaTypeService;
        private readonly IPizzaService _pizzaService;
        public ImportFileService(IPizzaTypeService pizzaTypeService, IFileService fileService, IPizzaService pizzaService)
        {
            _fileService = fileService;
            _pizzaTypeService = pizzaTypeService;
            _pizzaService = pizzaService;
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
        }
    }
}
