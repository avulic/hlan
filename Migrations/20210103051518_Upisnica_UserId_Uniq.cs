using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Upisnica_UserId_Uniq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Upisnice_UserId",
                table: "Upisnice");

            migrationBuilder.DropColumn(
                name: "Uvjeti",
                table: "Upisnice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Upisnice_UserId",
                table: "Upisnice");

            migrationBuilder.AddColumn<string>(
                name: "Uvjeti",
                table: "Upisnice",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
