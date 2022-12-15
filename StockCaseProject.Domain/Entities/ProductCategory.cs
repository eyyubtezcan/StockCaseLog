using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Domain.Entities
{
    internal class ProductCategory:BaseEntity
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsMaster  { get; set; }
        public int? SubCategoryId { get; set; }
    }
}
