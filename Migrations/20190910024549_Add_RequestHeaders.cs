using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySearch.Migrations
{
    public partial class Add_RequestHeaders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestHeaders",
                columns: table => new
                {
                    RequestHeaderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeaderName = table.Column<string>(nullable: true),
                    HeaderValue = table.Column<string>(nullable: true),
                    engineSearchEngineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHeaders", x => x.RequestHeaderId);
                    table.ForeignKey(
                        name: "FK_RequestHeaders_SearchEngines_engineSearchEngineId",
                        column: x => x.engineSearchEngineId,
                        principalTable: "SearchEngines",
                        principalColumn: "SearchEngineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestHeaders_engineSearchEngineId",
                table: "RequestHeaders",
                column: "engineSearchEngineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestHeaders");

            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "SearchEngines",
                nullable: true);
        }
    }
}
