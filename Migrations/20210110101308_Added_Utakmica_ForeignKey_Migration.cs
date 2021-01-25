using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Added_Utakmica_ForeignKey_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kola_Sezone_SezonaId",
                table: "Kola");

            migrationBuilder.DropIndex(
                name: "IX_Kola_SezonaId",
                table: "Kola");

            migrationBuilder.DropColumn(
                name: "SezonaId",
                table: "Kola");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SezonaId",
                table: "Kola",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kola_SezonaId",
                table: "Kola",
                column: "SezonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kola_Sezone_SezonaId",
                table: "Kola",
                column: "SezonaId",
                principalTable: "Sezone",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
