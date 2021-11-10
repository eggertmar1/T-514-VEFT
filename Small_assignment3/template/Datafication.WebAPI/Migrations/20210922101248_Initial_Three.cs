using Microsoft.EntityFrameworkCore.Migrations;

namespace Datafication.WebAPI.Migrations
{
    public partial class Initial_Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManufaturerId",
                table: "IceCreams",
                newName: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "IceCreams",
                newName: "ManufaturerId");
        }
    }
}
