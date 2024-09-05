using Microsoft.AspNetCore.Http;
using PizzaPlaceSales.Data.Repositories.Interfaces;
using PizzaPlaceSales.Services.Interfaces;
using System.Data;

namespace PizzaPlaceSales.Services.Services
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
            var existingPizzaIds = await _pizzaRepository.GetAllPizzaIds();
            var pizzaIdsToInsert = new List<string>();
            foreach(DataRow row in pizzaTable.Rows)
                pizzaIdsToInsert.Add((string)row["pizza_id"]);

            var existingRecordCounter = pizzaIdsToInsert.Count(pi => existingPizzaIds.Any(e => e == pi));
            if (existingRecordCounter <= 0) // bulk insert if PizzaIds did not exist
                await _pizzaRepository.BulkInsert(pizzaTable);
        }
    }
}
