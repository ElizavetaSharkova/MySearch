using Microsoft.EntityFrameworkCore.Migrations;

namespace MySearch.Migrations
{
    public partial class AddIsDisableEngine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisable",
                table: "SearchEngines",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisable",
                table: "SearchEngines");
        }
    }
}
