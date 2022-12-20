using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StockCaseProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Repository
{
    
    public class TaggedQueryCommandInterceptor : DbCommandInterceptor
    {    
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            ManipulateCommand(command);


            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            ModifyCommand(command);

            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }

        private static void ManipulateCommand(DbCommand command)
        {
            
            command.CommandText += " Insert into TestTable Values('aaaaaaa')";
            if (command.CommandText.StartsWith("-- Use hint: robust plan", StringComparison.Ordinal))
            {
                command.CommandText += " OPTION (ROBUST PLAN)";
                command.CommandText += " Insert into TestTable Values('dfdasfas')";
            }
        }
        private static void ModifyCommand(DbCommand command)
        {
   
            if (!command.CommandText.Contains(nameof(ChangeLog)))
            {
                var changeLogs = new ChangeLog()
                {
                    UserName = "muhittin@deneme.com",
                    EntityName = "sdsd",
                    PrimaryKeyValue = 12,
                    PropertyName = "",
                    OldValue = command.CommandText.ToString(),
                    NewValue = command.CommandText.ToString(),
                    DateChanged = DateTime.Now,
                    //State = EnumState.Update
                };  
            }




            command.CommandText += " Insert into TestTable Values('bbbb')";
            if (command.CommandText.StartsWith("-- Apply OrderBy DESC", StringComparison.Ordinal))
            {

                Console.WriteLine("DemoDbCommandInterceptor: Applying OrderBy DESC");
                command.CommandText += " Insert into TestTable Values('dfdasfas')";
            }
        }
        public static void Log(string comm, string message)
        {

            Console.WriteLine("Intercepted: {0}, Command Text: {1} ", comm, message);
        }
    }
}
