using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockCaseProject.Domain.Entities;
using StockCaseProject.Service.Abstract;

namespace StockCaseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : BaseSecureController
    {
        private IStockService _service;

        public StockController(IStockService service)
        {
            _service = service;
        }
            
        
        [HttpPost("Stock")]
        public async Task<IEnumerable<Stock>> GetCustomersVariantCodeStock(List<Stock> stockList)
        {
            var result = await _service.AddRangeAsync(stockList);
           
            return result;

        }

        [HttpPut("{variantCode}/quantity/{quantity}")]
        public async Task<IEnumerable<Stock>> UpdateCustomersVariantStock(string variantCode,int quantity)
        {
            var result = _service.UpdateCustomersVariantStock(variantCode, quantity);

            return await Task.FromResult(result);

        }








        // GET: api/Stock
        //[HttpGet("GetCustomers/vas")]
        [HttpGet("{variantCode}/variant")]
        public async Task<IEnumerable<Stock>> GetCustomersVariantCodeStock(string variantCode)
        {
            var result =  _service.GetAllVariantCodeAsync(variantCode);
            return await Task.FromResult(result);

        }

        [HttpGet("{productCode}/product")]
        public async Task<IEnumerable<Stock>> GetCustomersProductCodeStock(string productCode)
        {
            var result = _service.GetAllProductCodeAsync(productCode);
            return await Task.FromResult(result);

        }






    }
}
