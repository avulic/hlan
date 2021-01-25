using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class AddedUser_KlubId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Klubovi_KlubId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "KlubId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Klubovi_KlubId",
                table: "AspNetUsers",
                column: "KlubId",
                principalTable: "Klubovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Klubovi_KlubId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "KlubId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Klubovi_KlubId",
                table: "AspNetUsers",
                column: "KlubId",
                principalTable: "Klubovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
