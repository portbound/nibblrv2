using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class revertingtoobjectsforingredientsandinstructions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientsJson",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "InstructionsJson",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: true),
                    Weight = table.Column<double>(type: "REAL", nullable: true),
                    WeightUnit = table.Column<double>(type: "REAL", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Step = table.Column<int>(type: "INTEGER", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instructions_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeID",
                table: "Ingredients",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_RecipeID",
                table: "Instructions",
                column: "RecipeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.AddColumn<string>(
                name: "IngredientsJson",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "InstructionsJson",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");
        }
    }
}
