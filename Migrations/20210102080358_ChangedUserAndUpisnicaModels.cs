using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class ChangedUserAndUpisnicaModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Upisnice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uvjeti",
                table: "Upisnice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "AspNetUsers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Uvjeti",
                table: "Upisnice");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Upisnice",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
