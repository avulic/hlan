using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Added_Statistika_Utkamice_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatistikaKluba");

            migrationBuilder.AddColumn<int>(
                name: "UtakmicaId",
                table: "StatistikaIgraca",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StatistikaIgraca_UtakmicaId",
                table: "StatistikaIgraca",
                column: "UtakmicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatistikaIgraca_Utakmice_UtakmicaId",
                table: "StatistikaIgraca",
                column: "UtakmicaId",
                principalTable: "Utakmice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatistikaIgraca_Utakmice_UtakmicaId",
                table: "StatistikaIgraca");

            migrationBuilder.DropIndex(
                name: "IX_StatistikaIgraca_UtakmicaId",
                table: "StatistikaIgraca");

            migrationBuilder.DropColumn(
                name: "UtakmicaId",
                table: "StatistikaIgraca");

            migrationBuilder.CreateTable(
                name: "StatistikaKluba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Behinds = table.Column<int>(type: "int", nullable: false),
                    Disposals = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Hitouts = table.Column<int>(type: "int", nullable: false),
                    KlubId = table.Column<int>(type: "int", nullable: true),
                    Marks = table.Column<int>(type: "int", nullable: false),
                    Spoils = table.Column<int>(type: "int", nullable: false),
                    Tackles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatistikaKluba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatistikaKluba_Klubovi_KlubId",
                        column: x => x.KlubId,
                        principalTable: "Klubovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatistikaKluba_KlubId",
                table: "StatistikaKluba",
                column: "KlubId");
        }
    }
}
