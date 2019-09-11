using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySearch.Migrations
{
    public partial class Add_RequestParameters_and_ResponseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IndexedTime",
                table: "SearchResults",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "TypeResponseTypeId",
                table: "SearchEngines",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestsParameters",
                columns: table => new
                {
                    RequestsParameterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParametrName = table.Column<string>(nullable: true),
                    ParametrValue = table.Column<string>(nullable: true),
                    engineSearchEngineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsParameters", x => x.RequestsParameterId);
                    table.ForeignKey(
                        name: "FK_RequestsParameters_SearchEngines_engineSearchEngineId",
                        column: x => x.engineSearchEngineId,
                        principalTable: "SearchEngines",
                        principalColumn: "SearchEngineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResponseTypes",
                columns: table => new
                {
                    ResponseTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    RootElement = table.Column<string>(nullable: true),
                    TitleElement = table.Column<string>(nullable: true),
                    DescriptionElement = table.Column<string>(nullable: true),
                    UrlElement = table.Column<string>(nullable: true),
                    DateElement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseTypes", x => x.ResponseTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchEngines_TypeResponseTypeId",
                table: "SearchEngines",
                column: "TypeResponseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsParameters_engineSearchEngineId",
                table: "RequestsParameters",
                column: "engineSearchEngineId");

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

            migrationBuilder.DropTable(
                name: "RequestsParameters");

            migrationBuilder.DropTable(
                name: "ResponseTypes");

            migrationBuilder.DropIndex(
                name: "IX_SearchEngines_TypeResponseTypeId",
                table: "SearchEngines");

            migrationBuilder.DropColumn(
                name: "TypeResponseTypeId",
                table: "SearchEngines");

            migrationBuilder.RenameColumn(
                name: "SearchDate",
                table: "SearchRequests",
                newName: "SearshDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IndexedTime",
                table: "SearchResults",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
