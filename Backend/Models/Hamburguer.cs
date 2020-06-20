using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Hamburguer
    {
        public int HamburguerId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public List<UsersHamburguer> UsersHamburguers { get; set; }
        public Category Category { get; set; }
        public List<HamburguersIngredient> HamburguersIngredients { get; set; }
    }
}
