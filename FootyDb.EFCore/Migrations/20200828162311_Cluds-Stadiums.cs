using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootyDb.EFCore.Migrations
{
    public partial class CludsStadiums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadium",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surface = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApiTeamId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    YearFounded = table.Column<int>(nullable: false),
                    StadiumId = table.Column<Guid>(nullable: false),
                    LeagueSeasonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Club_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Club_LeagueSeasons_LeagueSeasonId",
                        column: x => x.LeagueSeasonId,
                        principalTable: "LeagueSeasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Club_Stadium_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Club_CountryId",
                table: "Club",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_LeagueSeasonId",
                table: "Club",
                column: "LeagueSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_StadiumId",
                table: "Club",
                column: "StadiumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Stadium");
        }
    }
}
