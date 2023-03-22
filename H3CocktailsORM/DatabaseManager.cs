using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3CocktailsORM
{
    public class DatabaseManager
    {
        private string connectionString { get; set; }

        public DatabaseManager()
        {
            connectionString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=cocktails;";
        }

        public CocktailsContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CocktailsContext>().UseNpgsql(connectionString);

            return new CocktailsContext(optionsBuilder.Options);
        }

        public void UseContext(Action<CocktailsContext> action)
        {
            var context = CreateContext();

            action(context);

            context.SaveChanges();
        }
    }
}
