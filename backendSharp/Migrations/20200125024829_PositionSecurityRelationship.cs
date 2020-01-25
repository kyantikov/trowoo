using Microsoft.EntityFrameworkCore.Migrations;

namespace backendSharp.Migrations
{
    public partial class PositionSecurityRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SecurityId",
                table: "Position",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Position_SecurityId",
                table: "Position",
                column: "SecurityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Security_SecurityId",
                table: "Position",
                column: "SecurityId",
                principalTable: "Security",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_Security_SecurityId",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Position_SecurityId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "SecurityId",
                table: "Position");
        }
    }
}
