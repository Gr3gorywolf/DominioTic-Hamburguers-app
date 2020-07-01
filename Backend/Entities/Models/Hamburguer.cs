using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities.Models
{
    public class Hamburguer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
        public virtual List<UsersHamburguer> UsersHamburguers { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual List<HamburguersIngredient> HamburguersIngredients { get; set; }
    }
}
