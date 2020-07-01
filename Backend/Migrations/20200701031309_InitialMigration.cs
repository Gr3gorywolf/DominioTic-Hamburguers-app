using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Mesure = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Hamburguers",
                columns: table => new
                {
                    HamburguerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamburguers", x => x.HamburguerId);
                    table.ForeignKey(
                        name: "FK_Hamburguers_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HamburguersIngredients",
                columns: table => new
                {
                    HamburguersIngredientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientId = table.Column<int>(nullable: false),
                    HamburguerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HamburguersIngredients", x => x.HamburguersIngredientId);
                    table.ForeignKey(
                        name: "FK_HamburguersIngredients_Hamburguers_HamburguerId",
                        column: x => x.HamburguerId,
                        principalTable: "Hamburguers",
                        principalColumn: "HamburguerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HamburguersIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersHamburguers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    HamburguerId = table.Column<int>(nullable: false),
                    UsersHamburguerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersHamburguers", x => new { x.UserId, x.HamburguerId });
                    table.ForeignKey(
                        name: "FK_UsersHamburguers_Hamburguers_HamburguerId",
                        column: x => x.HamburguerId,
                        principalTable: "Hamburguers",
                        principalColumn: "HamburguerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersHamburguers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hamburguers_RestaurantId",
                table: "Hamburguers",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_HamburguersIngredients_HamburguerId",
                table: "HamburguersIngredients",
                column: "HamburguerId");

            migrationBuilder.CreateIndex(
                name: "IX_HamburguersIngredients_IngredientId",
                table: "HamburguersIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersHamburguers_HamburguerId",
                table: "UsersHamburguers",
                column: "HamburguerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HamburguersIngredients");

            migrationBuilder.DropTable(
                name: "UsersHamburguers");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Hamburguers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
