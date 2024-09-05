using Microsoft.AspNetCore.Mvc;
using PizzaPlaceSales.DTOs.ApiResponses;
using PizzaPlaceSales.DTOs.Imports;
using PizzaPlaceSales.DTOs.Sales;
using PizzaPlaceSales.Services.Interfaces;
using PizzaPlaceSales.Services.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PizzaPlaceSales.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        public SalesController(ISalesService salesService) 
        { 
            _salesService = salesService;
        }
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Sales" }, Summary = "Get total sales by year.")]
        [ProducesResponseType(typeof(SalesByYear), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTotalSalesByYear()
        {
            try
            {
                var result = await _salesService.GetTotalSalesByYear();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { IsSuccess = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Sales" }, Summary = "Get total sales by year and month.")]
        [ProducesResponseType(typeof(SalesByYearAndMonth), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTotalSalesByYearAndMonth()
        {
            try
            {
                var result = await _salesService.GetTotalSalesByYearAndMonth();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { IsSuccess = false, Message = ex.Message });
            }
        }
    }
}
