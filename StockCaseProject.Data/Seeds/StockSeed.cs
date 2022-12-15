using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockCaseProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Repository.Seeds
{
    internal class StockSeed : IEntityTypeConfiguration<Stock>
    {
        private readonly int[] _ids;

        public StockSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasData(
                new Stock
                {
                    Id = 1,
                    ProductCode = "001AD",
                    Quantiy = 120,
                    VariantCode="454CAS",
                    IsActive = true,
                    UpdatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now
                },
                new Stock
                {
                    Id = 2,
                    ProductCode = "321AD",
                    Quantiy = 220,
                    VariantCode = "DFD545S",
                    IsActive = true,
                    UpdatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now
                },
                new Stock
                {
                    Id = 3,
                    ProductCode = "00FF1AD",
                    Quantiy = 67,
                    VariantCode = "3234FSF",
                    IsActive = true,
                    UpdatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now
                },
                new Stock
                {
                    Id = 4,
                    ProductCode = "ASDFBV443",
                    Quantiy = 6,
                    VariantCode = "GFHGFX4363",
                    IsActive = true,
                    UpdatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now
                }


                );
        }
    }
}


