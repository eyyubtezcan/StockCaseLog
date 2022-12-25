using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using StockCaseProject.Domain.Entities;
using StockCaseProject.Repository.Seeds;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockCaseProject.Repository
{


    public class ApplicationDbContext: DbContext
    {
        
        private LoggingSavingChangesInterceptor _interceptors;

        public ApplicationDbContext(DbContextOptions options, LoggingSavingChangesInterceptor interceptors) : base
           (options)
        {
            //_httpContextAccessor = httpContextAccessor;
            this._interceptors = interceptors;
        }

        //public ApplicationDbContext()
        //{
        //}
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //When calling migrations, it will start
            if (!optionsBuilder.IsConfigured)
            {
                
            
                var connStr = "Data Source=localhost;Initial Catalog=StockCaseProjectDb2;Persist Security Info=True;User ID=sa;Password=test123;Encrypt=false";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                }

                );
                   optionsBuilder.AddInterceptors(_interceptors);


            }
            //var deneme = _httpContextAccessor?.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Name);
            //string a = _httpContextAccessor?.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value; ;
            //optionsBuilder.AddInterceptors(new LoggingSavingChangesInterceptor(a));
            ////optionsBuilder.AddInterceptors(new TaggedQueryCommandInterceptor());
        }
        //Stocks
        public DbSet<Stock> Stocks{ get; set; }
        public DbSet<ChangeLog> ChangeLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new StockSeed(new int[] { 1, 2, 3,4 }));



        }

  
    }
}
