using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockCaseProject.Domain.Entities;
using StockCaseProject.Service.Abstract;
using System.Security.Claims;
using System.Security.Principal;

namespace StockCaseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : BaseSecureController
    {
        private IStockService _service;
        IHttpContextAccessor _httpContextAccessor;
     
        public StockController(IStockService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;

            _httpContextAccessor = httpContextAccessor;

            // HttpContext.Items["Deneme"] = "DenemeContext";

        }
        [HttpPost("Login")]
        public async Task Login()
        {
           
            var context = this._httpContextAccessor.HttpContext.User.Claims.ToList();
           

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
{
    new Claim(ClaimTypes.Name, "anuviswan"),}, "mock"));

             _httpContextAccessor.HttpContext= new DefaultHttpContext() { User = user };


            return;

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
        [HttpDelete("{variantCode}")]
        public async Task UpdateCustomersVariantDelete(string variantCode)
        {
             _service.UpdateCustomersVariantDelete(variantCode);

             await Task.CompletedTask;

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
