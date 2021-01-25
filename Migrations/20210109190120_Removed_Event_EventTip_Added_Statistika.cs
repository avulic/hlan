using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Removed_Event_EventTip_Added_Statistika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Event_EventId",
                table: "Utakmice");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "TipEvent");

            migrationBuilder.DropIndex(
                name: "IX_Utakmice_EventId",
                table: "Utakmice");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Utakmice");

            migrationBuilder.AddColumn<int>(
                name: "RezDomaci",
                table: "Utakmice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RezGosti",
                table: "Utakmice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SezonaId",
                table: "Utakmice",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Godina",
                table: "Sezona",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "StatistikaIgraca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Disposals = table.Column<int>(nullable: false),
                    Marks = table.Column<int>(nullable: false),
                    Tackles = table.Column<int>(nullable: false),
                    Spoils = table.Column<int>(nullable: false),
                    Hitouts = table.Column<int>(nullable: false),
                    Goals = table.Column<int>(nullable: false),
                    Behinds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatistikaIgraca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatistikaIgraca_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StatistikaKluba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlubId = table.Column<int>(nullable: true),
                    Disposals = table.Column<int>(nullable: false),
                    Marks = table.Column<int>(nullable: false),
                    Tackles = table.Column<int>(nullable: false),
                    Spoils = table.Column<int>(nullable: false),
                    Hitouts = table.Column<int>(nullable: false),
                    Goals = table.Column<int>(nullable: false),
                    Behinds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatistikaKluba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatistikaKluba_Klubovi_KlubId",
                        column: x => x.KlubId,
                        principalTable: "Klubovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_SezonaId",
                table: "Utakmice",
                column: "SezonaId");

            migrationBuilder.CreateIndex(
                name: "IX_StatistikaIgraca_UserId",
                table: "StatistikaIgraca",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatistikaKluba_KlubId",
                table: "StatistikaKluba",
                column: "KlubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Sezona_SezonaId",
                table: "Utakmice",
                column: "SezonaId",
                principalTable: "Sezona",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utakmice_Sezona_SezonaId",
                table: "Utakmice");

            migrationBuilder.DropTable(
                name: "StatistikaIgraca");

            migrationBuilder.DropTable(
                name: "StatistikaKluba");

            migrationBuilder.DropIndex(
                name: "IX_Utakmice_SezonaId",
                table: "Utakmice");

            migrationBuilder.DropColumn(
                name: "RezDomaci",
                table: "Utakmice");

            migrationBuilder.DropColumn(
                name: "RezGosti",
                table: "Utakmice");

            migrationBuilder.DropColumn(
                name: "SezonaId",
                table: "Utakmice");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Utakmice",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Godina",
                table: "Sezona",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TipEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_TipEvent_TipId",
                        column: x => x.TipId,
                        principalTable: "TipEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_EventId",
                table: "Utakmice",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TipId",
                table: "Event",
                column: "TipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utakmice_Event_EventId",
                table: "Utakmice",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
