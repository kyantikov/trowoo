using Microsoft.EntityFrameworkCore.Migrations;

namespace backendSharp.Migrations
{
    public partial class AllRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "TrailingStop",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SecurityId",
                table: "Quote",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Position",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "LowPrice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "HighPrice",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrailingStop_PositionId",
                table: "TrailingStop",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_SecurityId",
                table: "Quote",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PortfolioId",
                table: "Position",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_LowPrice_PositionId",
                table: "LowPrice",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_HighPrice_PositionId",
                table: "HighPrice",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_HighPrice_Position_PositionId",
                table: "HighPrice",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LowPrice_Position_PositionId",
                table: "LowPrice",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Portfolio_PortfolioId",
                table: "Position",
                column: "PortfolioId",
                principalTable: "Portfolio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_Security_SecurityId",
                table: "Quote",
                column: "SecurityId",
                principalTable: "Security",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrailingStop_Position_PositionId",
                table: "TrailingStop",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HighPrice_Position_PositionId",
                table: "HighPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_LowPrice_Position_PositionId",
                table: "LowPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_Position_Portfolio_PortfolioId",
                table: "Position");

            migrationBuilder.DropForeignKey(
                name: "FK_Quote_Security_SecurityId",
                table: "Quote");

            migrationBuilder.DropForeignKey(
                name: "FK_TrailingStop_Position_PositionId",
                table: "TrailingStop");

            migrationBuilder.DropIndex(
                name: "IX_TrailingStop_PositionId",
                table: "TrailingStop");

            migrationBuilder.DropIndex(
                name: "IX_Quote_SecurityId",
                table: "Quote");

            migrationBuilder.DropIndex(
                name: "IX_Position_PortfolioId",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_LowPrice_PositionId",
                table: "LowPrice");

            migrationBuilder.DropIndex(
                name: "IX_HighPrice_PositionId",
                table: "HighPrice");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "TrailingStop");

            migrationBuilder.DropColumn(
                name: "SecurityId",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "LowPrice");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "HighPrice");
        }
    }
}
