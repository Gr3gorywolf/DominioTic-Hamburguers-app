using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities.Models
{
    public class Hamburguer
    {
        public int HamburguerId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int RestaurantId { get; set; }
        public List<UsersHamburguer> UsersHamburguers { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<HamburguersIngredient> HamburguersIngredients { get; set; }
    }
}
