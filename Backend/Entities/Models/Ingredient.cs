using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Mesure { get; set; }
        public virtual List<HamburguersIngredient> HamburguersIngredients { get; set; }

    }
}
