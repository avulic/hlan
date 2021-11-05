using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class AddedSezone_Kolo_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kolo_Sezona_SezonaId",
                table: "Kolo");

            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Kolo_KoloId",
                table: "Utakmice");

            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Sezona_SezonaId",
                table: "Utakmice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sezona",
                table: "Sezona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kolo",
                table: "Kolo");

            migrationBuilder.RenameTable(
                name: "Sezona",
                newName: "Sezone");

            migrationBuilder.RenameTable(
                name: "Kolo",
                newName: "Kola");

            migrationBuilder.RenameIndex(
                name: "IX_Kolo_SezonaId",
                table: "Kola",
                newName: "IX_Kola_SezonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sezone",
                table: "Sezone",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kola",
                table: "Kola",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kola_Sezone_SezonaId",
                table: "Kola",
                column: "SezonaId",
                principalTable: "Sezone",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Kola_KoloId",
                table: "Utakmice",
                column: "KoloId",
                principalTable: "Kola",
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
                name: "FK_Kola_Sezone_SezonaId",
                table: "Kola");

            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Kola_KoloId",
                table: "Utakmice");

            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Sezone_SezonaId",
                table: "Utakmice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sezone",
                table: "Sezone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kola",
                table: "Kola");

            migrationBuilder.RenameTable(
                name: "Sezone",
                newName: "Sezona");

            migrationBuilder.RenameTable(
                name: "Kola",
                newName: "Kolo");

            migrationBuilder.RenameIndex(
                name: "IX_Kola_SezonaId",
                table: "Kolo",
                newName: "IX_Kolo_SezonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sezona",
                table: "Sezona",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kolo",
                table: "Kolo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kolo_Sezona_SezonaId",
                table: "Kolo",
                column: "SezonaId",
                principalTable: "Sezona",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Kolo_KoloId",
                table: "Utakmice",
                column: "KoloId",
                principalTable: "Kolo",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Sezona_SezonaId",
                table: "Utakmice",
                column: "SezonaId",
                principalTable: "Sezona",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
