using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class User_Klub_FF_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Klub_Id",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "KlubId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Klubovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klubovi", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KlubId",
                table: "AspNetUsers",
                column: "KlubId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Klubovi_KlubId",
                table: "AspNetUsers",
                column: "KlubId",
                principalTable: "Klubovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Klubovi_KlubId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Klubovi");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_KlubId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KlubId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Klub_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
