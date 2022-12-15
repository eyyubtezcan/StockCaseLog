using StockCaseProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Domain.Entities
{
    public class Stock :BaseEntity
    {
        public string VariantCode { get; set; }
        public string ProductCode { get; set; }
        public int Quantiy { get; set; }

    }
}
