using Microsoft.EntityFrameworkCore.Migrations;

namespace Trowoo.Migrations
{
    public partial class AddIndicatorReferencesToPositionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HighPrices_Positions_PositionId",
                table: "HighPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_LowPrices_Positions_PositionId",
                table: "LowPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_TrailingStops_Positions_PositionId",
                table: "TrailingStops");

            migrationBuilder.DropIndex(
                name: "IX_TrailingStops_PositionId",
                table: "TrailingStops");

            migrationBuilder.DropIndex(
                name: "IX_LowPrices_PositionId",
                table: "LowPrices");

            migrationBuilder.DropIndex(
                name: "IX_HighPrices_PositionId",
                table: "HighPrices");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "TrailingStops",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ticker",
                table: "Securities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Securities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Portfolios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Portfolios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "LowPrices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "HighPrices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrailingStops_PositionId",
                table: "TrailingStops",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LowPrices_PositionId",
                table: "LowPrices",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HighPrices_PositionId",
                table: "HighPrices",
                column: "PositionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HighPrices_Positions_PositionId",
                table: "HighPrices",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LowPrices_Positions_PositionId",
                table: "LowPrices",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrailingStops_Positions_PositionId",
                table: "TrailingStops",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HighPrices_Positions_PositionId",
                table: "HighPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_LowPrices_Positions_PositionId",
                table: "LowPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_TrailingStops_Positions_PositionId",
                table: "TrailingStops");

            migrationBuilder.DropIndex(
                name: "IX_TrailingStops_PositionId",
                table: "TrailingStops");

            migrationBuilder.DropIndex(
                name: "IX_LowPrices_PositionId",
                table: "LowPrices");

            migrationBuilder.DropIndex(
                name: "IX_HighPrices_PositionId",
                table: "HighPrices");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "TrailingStops",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Ticker",
                table: "Securities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Securities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Portfolios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Portfolios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "LowPrices",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "HighPrices",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_TrailingStops_PositionId",
                table: "TrailingStops",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_LowPrices_PositionId",
                table: "LowPrices",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_HighPrices_PositionId",
                table: "HighPrices",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_HighPrices_Positions_PositionId",
                table: "HighPrices",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LowPrices_Positions_PositionId",
                table: "LowPrices",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrailingStops_Positions_PositionId",
                table: "TrailingStops",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
