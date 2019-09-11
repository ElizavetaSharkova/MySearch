using Microsoft.EntityFrameworkCore.Migrations;

namespace MySearch.Migrations
{
    public partial class renameRootElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RootElement",
                table: "ResponseTypes",
                newName: "RootElementPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RootElementPath",
                table: "ResponseTypes",
                newName: "RootElement");
        }
    }
}
