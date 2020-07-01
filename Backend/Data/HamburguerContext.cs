using Backend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Backend.Data
{
    public partial class HamburguerContext : DbContext
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
               // optionsBuilder.UseSqlite("Filename=devDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Users hamburguers relationship
           

            modelBuilder.Entity<UsersHamburguer>()
                .HasKey(bc => new { bc.UserId, bc.HamburguerId });
          /*  modelBuilder.Entity<UsersHamburguer>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UsersHamburguers)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UsersHamburguer>()
                .HasOne(bc => bc.Hamburguer)
                .WithMany(c => c.UsersHamburguers)
                .HasForeignKey(bc => bc.HamburguerId)
                .HasConstraintName("FK_Hamburguers_Restaurants_RestaurantId");*/

            //Hamburguers restaurant relationship
            modelBuilder.Entity<Hamburguer>()
            .HasOne(c => c.Restaurant)
            .WithMany(e => e.Hamburguers)
            .HasForeignKey(e => e.RestaurantId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Hamburguers_Restaurants_RestaurantId")
            .IsRequired();




            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }


}
