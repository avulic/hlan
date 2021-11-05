using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Removed_Nullable_Kolo_On_Utakmica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Kola_KoloId",
                table: "Utakmice");

            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Sezone_SezonaId",
                table: "Utakmice");

            migrationBuilder.AlterColumn<int>(
                name: "SezonaId",
                table: "Utakmice",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KoloId",
                table: "Utakmice",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Kola_KoloId",
                table: "Utakmice",
                column: "KoloId",
                principalTable: "Kola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Sezone_SezonaId",
                table: "Utakmice",
                column: "SezonaId",
                principalTable: "Sezone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Kola_KoloId",
                table: "Utakmice");

            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Sezone_SezonaId",
                table: "Utakmice");

            migrationBuilder.AlterColumn<int>(
                name: "SezonaId",
                table: "Utakmice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "KoloId",
                table: "Utakmice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Kola_KoloId",
                table: "Utakmice",
                column: "KoloId",
                principalTable: "Kola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Sezone_SezonaId",
                table: "Utakmice",
                column: "SezonaId",
                principalTable: "Sezone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
