using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities.Models;

namespace Backend.Services
{
    interface IUnitOfWork
    {
        IRepository<Hamburguer> Hamburguers { get; }
        IRepository<Ingredient> Ingredients { get; }
        IRepository<Restaurant> Restaurants { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
