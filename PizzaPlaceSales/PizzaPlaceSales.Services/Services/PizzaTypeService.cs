using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.Services.Interfaces;

namespace PizzaPlaceSales.Services.Services
{
    public class PizzaTypeService : IPizzaTypeService
    {
        private readonly IFileService _fileService;
        private readonly IDataTableService _dataTableService;
        private readonly IPizzaTypeRepository _pizzaTypeRepository;
        public PizzaTypeService(IFileService fileService, IDataTableService dataTableService, IPizzaTypeRepository pizzaTypeRepository)
        {
            _fileService = fileService;
            _dataTableService = dataTableService;
            _pizzaTypeRepository = pizzaTypeRepository;
        }
        public async Task ImportFile(IFormFile file)
        {
            if (!_fileService.IsValidCsvFile(file))
                throw new InvalidDataException("You can only upload with an extension of *.csv.");

            var pizzaTypeTable = _dataTableService.CsvToDataTable(file);
            await _pizzaTypeRepository.BulkInsert(pizzaTypeTable);
        }
    }
}
