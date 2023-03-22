using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace H3CocktailsORM
{
    public class CocktailsContext : DbContext
    {

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public CocktailsContext(DbContextOptions<CocktailsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>()
                .Property(p => p.Ingredients)
                .HasConversion(p => JsonConvert.SerializeObject(p), 
                p => JsonConvert.DeserializeObject<Dictionary<Ingredient, double>>(p));

            modelBuilder.Entity<Drink>();
            modelBuilder.Entity<Ingredient>();
        }
    }
}
