using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootyDb.EFCore.Migrations
{
    public partial class ClubLeagueSeasonDislocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_LeagueSeasons_LeagueSeasonId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_LeagueSeasonId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "LeagueSeasonId",
                table: "Clubs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LeagueSeasonId",
                table: "Clubs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_LeagueSeasonId",
                table: "Clubs",
                column: "LeagueSeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_LeagueSeasons_LeagueSeasonId",
                table: "Clubs",
                column: "LeagueSeasonId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
