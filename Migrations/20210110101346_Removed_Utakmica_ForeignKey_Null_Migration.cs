using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Removed_Utakmica_ForeignKey_Null_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Klubovi_DomaciId",
                table: "Utakmice");

            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Klubovi_GostiId",
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
                name: "GostiId",
                table: "Utakmice",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DomaciId",
                table: "Utakmice",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Klubovi_DomaciId",
                table: "Utakmice",
                column: "DomaciId",
                principalTable: "Klubovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Klubovi_GostiId",
                table: "Utakmice",
                column: "GostiId",
                principalTable: "Klubovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Sezone_SezonaId",
                table: "Utakmice",
                column: "SezonaId",
                principalTable: "Sezone",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Klubovi_DomaciId",
                table: "Utakmice");

            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Klubovi_GostiId",
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
                name: "GostiId",
                table: "Utakmice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DomaciId",
                table: "Utakmice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Klubovi_DomaciId",
                table: "Utakmice",
                column: "DomaciId",
                principalTable: "Klubovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Klubovi_GostiId",
                table: "Utakmice",
                column: "GostiId",
                principalTable: "Klubovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Sezone_SezonaId",
                table: "Utakmice",
                column: "SezonaId",
                principalTable: "Sezone",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
