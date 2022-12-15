using StockCaseProject.Domain.Entities;
using StockCaseProject.Repository.Abstract;
using StockCaseProject.Repository.Concreate;
using StockCaseProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Service.Concreate
{
    public class StockService : Service<Stock>, IStockService
    {
        private IStockRepository _repository;

        public StockService(IStockRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Stock> GetAllProductCodeAsync(string productCode)
        {
            var stockProduct =  this.GetAllAsync().Result.Where(x => x.ProductCode == productCode).ToList();
            return stockProduct;
        }

        public List<Stock> GetAllVariantCodeAsync(string variantCode)
        {
            var stockVariant = _repository.GetAllAsync();


            var stockVariant1= stockVariant.Result.Where(x => x.VariantCode == variantCode).ToList();
            return stockVariant1;
        }

        public List<Stock> UpdateCustomersVariantStock(string variantCode, int quantity)
        {
            var stockList = this.GetAllAsync().Result.Where(x => x.VariantCode == variantCode).ToList();

            if(stockList.Count>0)
            {
                foreach(var stock in stockList)
                {
                    stock.Quantiy = quantity;
                    _repository.Update(stock);
                }
            }

            return stockList;
        }
    }
}
