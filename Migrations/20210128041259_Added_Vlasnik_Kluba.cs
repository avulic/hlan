using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Added_Vlasnik_Kluba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VlasnikId",
                table: "Klubovi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klubovi_VlasnikId",
                table: "Klubovi",
                column: "VlasnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klubovi_AspNetUsers_VlasnikId",
                table: "Klubovi",
                column: "VlasnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klubovi_AspNetUsers_VlasnikId",
                table: "Klubovi");

            migrationBuilder.DropIndex(
                name: "IX_Klubovi_VlasnikId",
                table: "Klubovi");

            migrationBuilder.DropColumn(
                name: "VlasnikId",
                table: "Klubovi");
        }
    }
}
