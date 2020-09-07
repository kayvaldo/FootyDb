using Microsoft.EntityFrameworkCore.Migrations;

namespace FootyDb.EFCore.Migrations
{
    public partial class ClubsStadiums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Countries_CountryId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Club_LeagueSeasons_LeagueSeasonId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Club_Stadium_StadiumId",
                table: "Club");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stadium",
                table: "Stadium");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Club",
                table: "Club");

            migrationBuilder.RenameTable(
                name: "Stadium",
                newName: "Stadiums");

            migrationBuilder.RenameTable(
                name: "Club",
                newName: "Clubs");

            migrationBuilder.RenameIndex(
                name: "IX_Club_StadiumId",
                table: "Clubs",
                newName: "IX_Clubs_StadiumId");

            migrationBuilder.RenameIndex(
                name: "IX_Club_LeagueSeasonId",
                table: "Clubs",
                newName: "IX_Clubs_LeagueSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Club_CountryId",
                table: "Clubs",
                newName: "IX_Clubs_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stadiums",
                table: "Stadiums",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Countries_CountryId",
                table: "Clubs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_LeagueSeasons_LeagueSeasonId",
                table: "Clubs",
                column: "LeagueSeasonId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Stadiums_StadiumId",
                table: "Clubs",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Countries_CountryId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_LeagueSeasons_LeagueSeasonId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Stadiums_StadiumId",
                table: "Clubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stadiums",
                table: "Stadiums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.RenameTable(
                name: "Stadiums",
                newName: "Stadium");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "Club");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_StadiumId",
                table: "Club",
                newName: "IX_Club_StadiumId");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_LeagueSeasonId",
                table: "Club",
                newName: "IX_Club_LeagueSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_CountryId",
                table: "Club",
                newName: "IX_Club_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stadium",
                table: "Stadium",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Club",
                table: "Club",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Countries_CountryId",
                table: "Club",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Club_LeagueSeasons_LeagueSeasonId",
                table: "Club",
                column: "LeagueSeasonId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Stadium_StadiumId",
                table: "Club",
                column: "StadiumId",
                principalTable: "Stadium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
