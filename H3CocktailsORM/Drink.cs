using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3CocktailsORM
{
    public class Drink
    {
        [Key]
        public int Id { get; private init; }
        public string Name { get; set; }
        public Recipe Recipe { get; set; }
    }
}