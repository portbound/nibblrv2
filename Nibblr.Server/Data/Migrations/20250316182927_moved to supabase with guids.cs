using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class movedtosupabasewithguids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    URL = table.Column<string>(type: "text", nullable: true),
                    Servings = table.Column<int>(type: "integer", nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false),
                    Fat = table.Column<double>(type: "double precision", nullable: false),
                    Carbs = table.Column<double>(type: "double precision", nullable: false),
                    Protein = table.Column<double>(type: "double precision", nullable: false),
                    Bookmarked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeID = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
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
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeID = table.Column<Guid>(type: "uuid", nullable: false),
                    Step = table.Column<int>(type: "integer", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "RecipeTags",
                columns: table => new
                {
                    RecipesID = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTags", x => new { x.RecipesID, x.TagsID });
                    table.ForeignKey(
                        name: "FK_RecipeTags_Recipes_RecipesID",
                        column: x => x.RecipesID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTags_Tags_TagsID",
                        column: x => x.TagsID,
                        principalTable: "Tags",
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

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Name",
                table: "Recipes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTags_TagsID",
                table: "RecipeTags",
                column: "TagsID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "RecipeTags");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
