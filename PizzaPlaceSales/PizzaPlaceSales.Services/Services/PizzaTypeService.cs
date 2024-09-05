using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.Services.Interfaces;
using System.Data;

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
            var existingPizzaTypeIds = await _pizzaTypeRepository.GetAllPizzaTypeIds();
            var pizzaTypeIdsToInsert = new List<string>();
            foreach (DataRow row in pizzaTypeTable.Rows)            
                pizzaTypeIdsToInsert.Add((string) row["pizza_type_id"]);
                
            var existingRecordCounter = pizzaTypeIdsToInsert.Count(pi => existingPizzaTypeIds.Any(e => e == pi));
            if (existingRecordCounter <= 0) // bulk insert if PizzaTypeIds did not exist
                await _pizzaTypeRepository.BulkInsert(pizzaTypeTable);
        }
    }
}
