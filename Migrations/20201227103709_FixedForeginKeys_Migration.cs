using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class FixedForeginKeys_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upisnice_AspNetUsers_IgracId",
                table: "Upisnice");

            migrationBuilder.DropIndex(
                name: "IX_Upisnice_IgracId",
                table: "Upisnice");

            migrationBuilder.DropColumn(
                name: "IgracId",
                table: "Upisnice");

            migrationBuilder.DropColumn(
                name: "User_id",
                table: "Upisnice");

            migrationBuilder.DropColumn(
                name: "Klub_Id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Upisnice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sezona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Godina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sezona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kolo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Br = table.Column<int>(nullable: false),
                    SezonaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kolo_Sezona_SezonaId",
                        column: x => x.SezonaId,
                        principalTable: "Sezona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipId = table.Column<int>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Utakmice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: true),
                    KoloId = table.Column<int>(nullable: true),
                    DomaciId = table.Column<int>(nullable: true),
                    GostiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utakmice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utakmice_Klubovi_DomaciId",
                        column: x => x.DomaciId,
                        principalTable: "Klubovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Utakmice_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Utakmice_Klubovi_GostiId",
                        column: x => x.GostiId,
                        principalTable: "Klubovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Utakmice_Kolo_KoloId",
                        column: x => x.KoloId,
                        principalTable: "Kolo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Upisnice_UserId",
                table: "Upisnice",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TipId",
                table: "Event",
                column: "TipId");

            migrationBuilder.CreateIndex(
                name: "IX_Kolo_SezonaId",
                table: "Kolo",
                column: "SezonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_DomaciId",
                table: "Utakmice",
                column: "DomaciId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_EventId",
                table: "Utakmice",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_GostiId",
                table: "Utakmice",
                column: "GostiId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_KoloId",
                table: "Utakmice",
                column: "KoloId");

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

            migrationBuilder.DropTable(
                name: "Utakmice");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Kolo");

            migrationBuilder.DropTable(
                name: "TipEvent");

            migrationBuilder.DropTable(
                name: "Sezona");

            migrationBuilder.DropIndex(
                name: "IX_Upisnice_UserId",
                table: "Upisnice");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Upisnice");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "IgracId",
                table: "Upisnice",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_id",
                table: "Upisnice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Klub_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Upisnice_IgracId",
                table: "Upisnice",
                column: "IgracId");

            migrationBuilder.AddForeignKey(
                name: "FK_Upisnice_AspNetUsers_IgracId",
                table: "Upisnice",
                column: "IgracId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
