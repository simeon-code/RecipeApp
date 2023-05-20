using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp.Data.Migrations
{
    public partial class addLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Recipes");
        }
    }
}
