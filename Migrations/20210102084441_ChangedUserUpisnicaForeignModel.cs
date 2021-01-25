using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class ChangedUserUpisnicaForeignModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upisnice_AspNetUsers_UserId1",
                table: "Upisnice");

            migrationBuilder.DropIndex(
                name: "IX_Upisnice_UserId1",
                table: "Upisnice");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Upisnice");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Upisnice",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Upisnice_UserId",
                table: "Upisnice",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Upisnice_AspNetUsers_UserId",
                table: "Upisnice",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upisnice_AspNetUsers_UserId",
                table: "Upisnice");

            migrationBuilder.DropIndex(
                name: "IX_Upisnice_UserId",
                table: "Upisnice");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Upisnice",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Upisnice",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Upisnice_UserId1",
                table: "Upisnice",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Upisnice_AspNetUsers_UserId1",
                table: "Upisnice",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
