using Microsoft.AspNetCore.Mvc;
using PizzaPlaceSales.DTOs.ApiResponses;
using PizzaPlaceSales.DTOs.Imports;
using PizzaPlaceSales.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PizzaPlaceSales.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IImportFileService _importFileService;
        public ImportController(IImportFileService importFileService)
        {
            _importFileService = importFileService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Import" }, Summary = "API call to import CSV files for pizza types, pizzas, orders and the order-details.")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ImportPizzasAndOrders([FromForm] PizzasAndOrders pizzasAndOrders)
        {
            try
            {
                await _importFileService.ImportFile(pizzasAndOrders);
                return Ok(new ApiResponse { IsSuccess = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("does not belong to table"))
                    return BadRequest(new ApiResponse { IsSuccess = false, Message = $"CSV files should be uploaded correctly in the correct fields, example 'pizza_types.csv' should be uploaded in PizzaTypesCSVFile, 'pizzas.csv' should be uploaded in PizzasCSVFile, 'orders.csv' should be uploaded in OrdersCSVFile, 'order_details.csv' should be uploaded in OrderDetailsCSVFile., {ex.Message}" });
                return BadRequest(new ApiResponse { IsSuccess = false, Message = ex.Message });
            }
        }
    }
}
