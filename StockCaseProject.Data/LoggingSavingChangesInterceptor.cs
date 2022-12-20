using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using StockCaseProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Repository
{
    public class LoggingSavingChangesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Started saving changes.");
            //contexti çektik
            var context = eventData.Context;

            //Değişiklik olmayan kayıtları alıyoruz.
            var modifiedEntities = context.ChangeTracker.Entries()
               .Where(p => p.State != EntityState.Unchanged).ToList();
   
            


            foreach (var change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;

                var PrimaryKey = change.OriginalValues.Properties.FirstOrDefault(prop => prop.IsPrimaryKey() == true).Name;

                Dictionary<string, object> originalValuesjson = new Dictionary<string, object>();
                    Dictionary<string, object> currentValuesjson = new Dictionary<string, object>();


                ChangeLog log = new ChangeLog()
                {
                    UserName = "muhittininterception@deneme.com",
                    EntityName = entityName,
                    PrimaryKeyValue = int.Parse(change.OriginalValues[PrimaryKey].ToString()),
                    PropertyName = "",
                    OldValue = "",
                    NewValue = "",
                    DateChanged = DateTime.Now,
                    //State = EnumState.Update
                };

                if (change.State == EntityState.Deleted)
                {                                    

                    foreach (IProperty prop in change.OriginalValues.Properties)
                    {                    
                  
                        originalValuesjson.Add(prop.Name, change.OriginalValues[prop.Name].ToString());
                    }
                    log.OldValue = JsonConvert.SerializeObject(originalValuesjson);
                    log.NewValue = JsonConvert.SerializeObject(currentValuesjson);
                    log.State = EnumState.Delete;

                }
                else if (change.State == EntityState.Modified)
                {
                    foreach (IProperty prop in change.OriginalValues.Properties)
                    {
                        if (change.OriginalValues[prop.Name].ToString() != change.CurrentValues[prop.Name].ToString())
                        {
                            originalValuesjson.Add(prop.Name, change.OriginalValues[prop.Name].ToString());
                            currentValuesjson.Add(prop.Name, change.CurrentValues[prop.Name].ToString());
                        }

                    }
                    log.OldValue = JsonConvert.SerializeObject(originalValuesjson);
                    log.NewValue = JsonConvert.SerializeObject(currentValuesjson);
                    log.State = EnumState.Update;
                }
                else if (change.State == EntityState.Added)
                {

                    foreach (IProperty prop in change.OriginalValues.Properties)
                    {

                        currentValuesjson.Add(prop.Name, change.CurrentValues[prop.Name].ToString());


                    }
                    log.NewValue = JsonConvert.SerializeObject(currentValuesjson);
                    log.State = EnumState.Added;
                }

                context.Add(log);

                //}

            }



            Console.WriteLine("db işlemi bitti");
            return new ValueTask<InterceptionResult<int>>(result);
        }

        //public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData,
        //    int result,
        //    CancellationToken cancellationToken = default)
        //{
        //    Console.WriteLine($"Saved {result} No of changes.");

        //    return new ValueTask<int>(result);
        //}
    }
}
