using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Trowoo.Migrations
{
    public partial class AddPositionPerformanceMetricsClassAndRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PositionPerformanceMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PositionId = table.Column<int>(nullable: false),
                    OneDayChange = table.Column<decimal>(nullable: false),
                    SevenDayChange = table.Column<decimal>(nullable: false),
                    OneMonthChange = table.Column<decimal>(nullable: false),
                    ThreeMonthChange = table.Column<decimal>(nullable: false),
                    SixMonthChange = table.Column<decimal>(nullable: false),
                    NineMonthChange = table.Column<decimal>(nullable: false),
                    OneYearChange = table.Column<decimal>(nullable: false),
                    TwoYearChange = table.Column<decimal>(nullable: false),
                    ThreeYearChange = table.Column<decimal>(nullable: false),
                    FiveYearChange = table.Column<decimal>(nullable: false),
                    TenYearChange = table.Column<decimal>(nullable: false),
                    MonthToDateChange = table.Column<decimal>(nullable: false),
                    QuarterToDateChange = table.Column<decimal>(nullable: false),
                    YearToDateChange = table.Column<decimal>(nullable: false),
                    InceptionToDateChange = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionPerformanceMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionPerformanceMetrics_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionPerformanceMetrics_PositionId",
                table: "PositionPerformanceMetrics",
                column: "PositionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionPerformanceMetrics");
        }
    }
}
