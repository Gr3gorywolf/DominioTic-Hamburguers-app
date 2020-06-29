using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities.Models
{
    public class HamburguersIngredient
    {
        public int HamburguersIngredientId {get;set;}
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int HamburguerId { get; set; }
        public Hamburguer Hamburguer { get; set; }
    }
}
