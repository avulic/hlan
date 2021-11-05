using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HLAN.Migrations
{
    public partial class Added_potvdjenaFilen_Upisnica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Potvrdena",
                table: "Upisnice",
                nullable: false,
                defaultValue: false
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Potvrdena",
               table: "Upisnice"
            );

        }
    }
}
