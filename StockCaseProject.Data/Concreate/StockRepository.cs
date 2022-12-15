using Microsoft.EntityFrameworkCore;
using StockCaseProject.Domain.Entities;
using StockCaseProject.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Repository.Concreate
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
