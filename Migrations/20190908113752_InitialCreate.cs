using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySearch.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchEngines",
                columns: table => new
                {
                    SearchEngineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BaseUrl = table.Column<string>(nullable: true),
                    ApiKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngines", x => x.SearchEngineId);
                });

            migrationBuilder.CreateTable(
                name: "SearchRequests",
                columns: table => new
                {
                    SearchRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SearchString = table.Column<string>(nullable: true),
                    SearchDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchRequests", x => x.SearchRequestId);
                });

            migrationBuilder.CreateTable(
                name: "SearchResults",
                columns: table => new
                {
                    SearchResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IndexedTime = table.Column<DateTime>(nullable: false),
                    RequestSearchRequestId = table.Column<int>(nullable: true),
                    SearchEngineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchResults", x => x.SearchResultId);
                    table.ForeignKey(
                        name: "FK_SearchResults_SearchRequests_RequestSearchRequestId",
                        column: x => x.RequestSearchRequestId,
                        principalTable: "SearchRequests",
                        principalColumn: "SearchRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SearchResults_SearchEngines_SearchEngineId",
                        column: x => x.SearchEngineId,
                        principalTable: "SearchEngines",
                        principalColumn: "SearchEngineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchResults_RequestSearchRequestId",
                table: "SearchResults",
                column: "RequestSearchRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchResults_SearchEngineId",
                table: "SearchResults",
                column: "SearchEngineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchResults");

            migrationBuilder.DropTable(
                name: "SearchRequests");

            migrationBuilder.DropTable(
                name: "SearchEngines");
        }
    }
}
