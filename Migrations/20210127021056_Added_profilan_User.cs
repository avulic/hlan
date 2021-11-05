using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Added_profilan_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Profilna",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profilna",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
