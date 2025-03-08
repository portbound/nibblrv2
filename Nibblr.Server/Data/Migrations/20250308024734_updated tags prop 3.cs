using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class updatedtagsprop3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Recipes_RecipeID",
                table: "RecipeTags");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "RecipeTags",
                newName: "RecipesID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Recipes_RecipesID",
                table: "RecipeTags",
                column: "RecipesID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Recipes_RecipesID",
                table: "RecipeTags");

            migrationBuilder.RenameColumn(
                name: "RecipesID",
                table: "RecipeTags",
                newName: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Recipes_RecipeID",
                table: "RecipeTags",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
