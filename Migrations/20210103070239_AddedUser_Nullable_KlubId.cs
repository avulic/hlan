using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class AddedUser_Nullable_KlubId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Klubovi_KlubId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "KlubId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
