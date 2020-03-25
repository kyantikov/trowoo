using Microsoft.EntityFrameworkCore.Migrations;

namespace Trowoo.Migrations
{
    public partial class AddUniqueConstraintsToQuoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "UniqueDailyQuote", 
                table: "Quotes",
                columns: new[]{"QuoteDate","SecurityId"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UniqueDailyQuote", 
                table: "Quotes");
        }
    }
}
