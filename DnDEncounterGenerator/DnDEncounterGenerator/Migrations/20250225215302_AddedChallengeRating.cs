using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDEncounterGenerator.Migrations
{
    /// <inheritdoc />
    public partial class AddedChallengeRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ChallengeRating",
                table: "Monsters",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 1,
                column: "ChallengeRating",
                value: 0.25);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 2,
                column: "ChallengeRating",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 3,
                column: "ChallengeRating",
                value: 2.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChallengeRating",
                table: "Monsters");
        }
    }
}
