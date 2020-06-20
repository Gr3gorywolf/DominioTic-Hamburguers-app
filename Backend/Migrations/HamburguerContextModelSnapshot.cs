﻿// <auto-generated />
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(HamburguerContext))]
    partial class HamburguerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Backend.Models.Hamburguer", b =>
                {
                    b.Property<int>("HamburguerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("HamburguerId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Hamburguers");
                });

            modelBuilder.Entity("Backend.Models.HamburguersIngredient", b =>
                {
                    b.Property<int>("HamburguersIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HamburguerId");

                    b.Property<int>("IngredientId");

                    b.HasKey("HamburguersIngredientId");

                    b.HasIndex("HamburguerId");

                    b.HasIndex("IngredientId");

                    b.ToTable("HamburguersIngredients");
                });

            modelBuilder.Entity("Backend.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mesure");

                    b.Property<string>("Name");

                    b.Property<int>("Quantity");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Models.UsersHamburguer", b =>
                {
                    b.Property<int>("UsersHamburguerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HamburguerId");

                    b.Property<int>("UserId");

                    b.HasKey("UsersHamburguerId");

                    b.HasIndex("HamburguerId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersHamburguers");
                });

            modelBuilder.Entity("Backend.Models.Hamburguer", b =>
                {
                    b.HasOne("Backend.Models.Category", "Category")
                        .WithMany("Hamburguers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Models.HamburguersIngredient", b =>
                {
                    b.HasOne("Backend.Models.Hamburguer", "Hamburguer")
                        .WithMany("HamburguersIngredients")
                        .HasForeignKey("HamburguerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.Models.Ingredient", "Ingredient")
                        .WithMany("HamburguersIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Models.UsersHamburguer", b =>
                {
                    b.HasOne("Backend.Models.Hamburguer", "Hamburguer")
                        .WithMany("UsersHamburguers")
                        .HasForeignKey("HamburguerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.Models.User", "User")
                        .WithMany("UsersHamburguers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
