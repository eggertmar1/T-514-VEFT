using Microsoft.EntityFrameworkCore.Migrations;

namespace Datafication.WebAPI.Migrations
{
    public partial class Initial_eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IceCreamId",
                table: "CategoryIceCream",
                newName: "IceCreamsId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryIceCream",
                newName: "CategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IceCreamsId",
                table: "CategoryIceCream",
                newName: "IceCreamId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "CategoryIceCream",
                newName: "CategoryId");
        }
    }
}
