using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockCaseProject.Domain.Entities;
using StockCaseProject.Repository.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Repository
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base
           (options)
        {

        }

        //public ApplicationDbContext()
        //{

        //}
      
        public void loglaaaa()
        {
            //try
            //{

                var modifiedEntities = ChangeTracker.Entries();
                //   .Where(p => p.State == EntityState.Modified).ToList();
                var now = System.DateTime.UtcNow;


                foreach (var change in modifiedEntities)
                {
                    var entityName = change.Entity.GetType().Name;

                    var PrimaryKey = change.OriginalValues.Properties.FirstOrDefault(prop => prop.IsPrimaryKey() == true).Name;

                    foreach (IProperty prop in change.OriginalValues.Properties)
                    {

                        var originalValue = change.OriginalValues[prop.Name].ToString();
                        var currentValue = change.CurrentValues[prop.Name].ToString();

                        if (originalValue != currentValue) //Sadece Değişen kayıt Log'a atılır.
                        {
                        ChangeLog log = new ChangeLog()
                        {
                            UserName = "muhittin@deneme.com",
                            EntityName = entityName,
                            PrimaryKeyValue = int.Parse(change.OriginalValues[PrimaryKey].ToString()),
                            PropertyName = prop.Name,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            DateChanged = now,
                            //State = EnumState.Update
                        };
                        //Değişen kayıt Log'u ElasticSearch'e atılır.
                        // ElasticSearch.CheckExistsAndInsert(log);

                        if (change.State != EntityState.Unchanged)
                        {
                            if (change.State == EntityState.Deleted)
                            {
                                log.State = EnumState.Delete;
                            }
                            else if (change.State == EntityState.Modified)
                            {
                                log.State = EnumState.Update;
                            }
                            else if (change.State == EntityState.Added)
                            {
                                log.State = EnumState.Added;
                            }
                            //else if (change.State == EntityState.Unchanged)
                            //{
                            //    log.State = EnumState.Delete;
                            //}
                            ChangeLogs.Add(log);

                             }

                        }
                    }

                }
               
        //    }
            //catch (Exception ex)
            //{
            //    var error = ex.Message;
            //    //return 0;
            //}
        }



        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        //{
        //    try
        //    {

        //        var modifiedEntities = ChangeTracker.Entries();
        //        //   .Where(p => p.State == EntityState.Modified).ToList();
        //        var now = System.DateTime.UtcNow;


        //        foreach (var change in modifiedEntities)
        //        {
        //            var entityName = change.Entity.GetType().Name;

        //            var PrimaryKey = change.OriginalValues.Properties.FirstOrDefault(prop => prop.IsPrimaryKey() == true).Name;

        //            foreach (IProperty prop in change.OriginalValues.Properties)
        //            {

        //                var originalValue = change.OriginalValues[prop.Name].ToString();
        //                var currentValue = change.CurrentValues[prop.Name].ToString();

        //                if (originalValue != currentValue) //Sadece Değişen kayıt Log'a atılır.
        //                {
        //                    ChangeLog log = new ChangeLog()
        //                    {
        //                        UserName = "deneme@deneme.com",
        //                        EntityName = entityName,
        //                        PrimaryKeyValue = int.Parse(change.OriginalValues[PrimaryKey].ToString()),
        //                        PropertyName = prop.Name,
        //                        OldValue = originalValue,
        //                        NewValue = currentValue,
        //                        DateChanged = now,
        //                        //State = EnumState.Update
        //                    };
        //                    //Değişen kayıt Log'u ElasticSearch'e atılır.
        //                    // ElasticSearch.CheckExistsAndInsert(log);

        //                    if (change.State != EntityState.Unchanged)
        //                    {
        //                        if (change.State == EntityState.Deleted)
        //                        {
        //                            log.State = EnumState.Delete;
        //                        }
        //                        else if (change.State == EntityState.Modified)
        //                        {
        //                            log.State = EnumState.Update;
        //                        }
        //                        else if (change.State == EntityState.Added)
        //                        {
        //                            log.State = EnumState.Added;
        //                        }
        //                        //else if (change.State == EntityState.Unchanged)
        //                        //{
        //                        //    log.State = EnumState.Delete;
        //                        //}
        //                        ChangeLogs.Add(log);

        //                    }

        //                }
        //            }

        //        }
        //        return await base.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        var error = ex.Message;
        //        return await base.SaveChangesAsync();
        //    }
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //When calling migrations, it will start
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Data Source=HPR480949;Initial Catalog=StockCaseProjectDb2;Persist Security Info=True;User ID=sa;Password=test123;Encrypt=false";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                }
                );
            }
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
