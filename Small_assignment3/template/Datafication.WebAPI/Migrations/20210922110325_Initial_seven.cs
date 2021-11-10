using Microsoft.EntityFrameworkCore.Migrations;

namespace Datafication.WebAPI.Migrations
{
    public partial class Initial_seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "IceCreamCategories",
                newName: "CategoryIceCream");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "CategoryIceCream",
                newName: "IceCreamCategories");
        }
    }
}
