using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Added_TrenerKlub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KlubTreneri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlubId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlubTreneri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KlubTreneri_Klubovi_KlubId",
                        column: x => x.KlubId,
                        principalTable: "Klubovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KlubTreneri_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KlubTreneri_KlubId",
                table: "KlubTreneri",
                column: "KlubId");

            migrationBuilder.CreateIndex(
                name: "IX_KlubTreneri_UserId",
                table: "KlubTreneri",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KlubTreneri");
        }
    }
}
