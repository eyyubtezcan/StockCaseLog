using StockCaseProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Service.Abstract
{
    public interface IStockService:IService<Stock>
    {
        public List<Stock> GetAllVariantCodeAsync(string variantCode);
        public List<Stock> GetAllProductCodeAsync(string productCode);
        public List<Stock> UpdateCustomersVariantStock(string variantCode, int quantity);
    }
}
