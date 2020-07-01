using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual List<Hamburguer> Hamburguers { get; set; }

    }
}
