using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.Services.Interfaces;

namespace PizzaPlaceSales.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IFileService _fileService;
        private readonly IDataTableService _dataTableService;
        private readonly IPizzaRepository _pizzaRepository;
        public PizzaService(IFileService fileService, IDataTableService dataTableService, IPizzaRepository pizzaRepository)
        {
            _fileService = fileService;
            _dataTableService = dataTableService;
            _pizzaRepository = pizzaRepository;
        }
        public async Task ImportFile(IFormFile file)
        {
            if (!_fileService.IsValidCsvFile(file))
                throw new InvalidDataException("You can only upload with an extension of *.csv.");

            var pizzaTable = _dataTableService.CsvToDataTable(file);
            await _pizzaRepository.BulkInsert(pizzaTable);
        }
    }
}
