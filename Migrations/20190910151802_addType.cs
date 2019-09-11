using Microsoft.EntityFrameworkCore.Migrations;

namespace MySearch.Migrations
{
    public partial class addType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SearchEngines_ResponseTypes_ResponseTypeId",
                table: "SearchEngines");

            migrationBuilder.RenameColumn(
                name: "ResponseTypeId",
                table: "SearchEngines",
                newName: "TypeResponseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SearchEngines_ResponseTypeId",
                table: "SearchEngines",
                newName: "IX_SearchEngines_TypeResponseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SearchEngines_ResponseTypes_TypeResponseTypeId",
                table: "SearchEngines",
                column: "TypeResponseTypeId",
                principalTable: "ResponseTypes",
                principalColumn: "ResponseTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SearchEngines_ResponseTypes_TypeResponseTypeId",
                table: "SearchEngines");

            migrationBuilder.RenameColumn(
                name: "TypeResponseTypeId",
                table: "SearchEngines",
                newName: "ResponseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SearchEngines_TypeResponseTypeId",
                table: "SearchEngines",
                newName: "IX_SearchEngines_ResponseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SearchEngines_ResponseTypes_ResponseTypeId",
                table: "SearchEngines",
                column: "ResponseTypeId",
                principalTable: "ResponseTypes",
                principalColumn: "ResponseTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
