using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class AddeUpisnicaEntitie_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Upisnice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(nullable: false),
                    IgracId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upisnice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upisnice_AspNetUsers_IgracId",
                        column: x => x.IgracId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Upisnice_IgracId",
                table: "Upisnice",
                column: "IgracId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Upisnice");
        }
    }
}
