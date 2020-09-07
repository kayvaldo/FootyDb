using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootyDb.EFCore.Migrations
{
    public partial class LeagueSeasons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApiLeagueId = table.Column<int>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leagues_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeagueSeasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LeagueId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SeasonEnd = table.Column<DateTime>(nullable: false),
                    SeasonStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueSeasons_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_CountryId",
                table: "Leagues",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueSeasons_LeagueId",
                table: "LeagueSeasons",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueSeasons");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
