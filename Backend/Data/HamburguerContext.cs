using Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public class HamburguerContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Hamburguer> Hamburguers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<HamburguersIngredient> HamburguersIngredients { get; set; }
        public DbSet<UsersHamburguer> UsersHamburguers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //azure
                optionsBuilder.UseSqlServer("Server=tcp:hamburguer-app.database.windows.net,1433;Initial Catalog=Hamburguer-app;Persist Security Info=False;User ID=db-root;Password=Azurelapara123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                //local
               // optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
    }

   
}
