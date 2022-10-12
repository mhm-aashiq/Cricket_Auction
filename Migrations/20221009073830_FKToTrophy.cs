using Microsoft.EntityFrameworkCore.Migrations;

namespace Cricket_Auction.Migrations
{
    public partial class FKToTrophy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "trophies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trophies_PlayerID",
                table: "trophies",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_trophies_Player_PlayerID",
                table: "trophies",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trophies_Player_PlayerID",
                table: "trophies");

            migrationBuilder.DropIndex(
                name: "IX_trophies_PlayerID",
                table: "trophies");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "trophies");
        }
    }
}
