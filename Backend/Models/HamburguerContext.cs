using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class HamburguerContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Hamburguer> Hamburguers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<HamburguersIngredient> HamburguersIngredients { get; set; }
        public DbSet<UsersHamburguer> UsersHamburguers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:hamburguer-app.database.windows.net,1433;Initial Catalog=Hamburguer-app;Persist Security Info=False;User ID=db-root;Password=Azurelapara123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
