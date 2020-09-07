using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootyDb.EFCore.Migrations
{
    public partial class NullableStadia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Stadiums_StadiumId",
                table: "Clubs");

            migrationBuilder.AlterColumn<Guid>(
                name: "StadiumId",
                table: "Clubs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Stadiums_StadiumId",
                table: "Clubs",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Stadiums_StadiumId",
                table: "Clubs");

            migrationBuilder.AlterColumn<Guid>(
                name: "StadiumId",
                table: "Clubs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Stadiums_StadiumId",
                table: "Clubs",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
