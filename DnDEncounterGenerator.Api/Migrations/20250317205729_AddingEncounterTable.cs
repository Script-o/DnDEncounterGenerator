using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DnDEncounterGenerator.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddingEncounterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EncounterId",
                table: "Monster",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Encounter",
                columns: table => new
                {
                    EncounterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encounter", x => x.EncounterId);
                });

            migrationBuilder.InsertData(
                table: "Encounter",
                columns: new[] { "EncounterId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This is an encounter with some goblins.", "There Be Goblins" },
                    { 2, "This is an encounter with some orcs.", "Big Ol Orcs" },
                    { 3, "This is an encounter with some kobolds.", "Fearsom Kobolds" }
                });

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "MonsterId",
                keyValue: 1,
                column: "EncounterId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "MonsterId",
                keyValue: 2,
                column: "EncounterId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Monster",
                keyColumn: "MonsterId",
                keyValue: 3,
                column: "EncounterId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Monster_EncounterId",
                table: "Monster",
                column: "EncounterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monster_Encounter_EncounterId",
                table: "Monster",
                column: "EncounterId",
                principalTable: "Encounter",
                principalColumn: "EncounterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monster_Encounter_EncounterId",
                table: "Monster");

            migrationBuilder.DropTable(
                name: "Encounter");

            migrationBuilder.DropIndex(
                name: "IX_Monster_EncounterId",
                table: "Monster");

            migrationBuilder.DropColumn(
                name: "EncounterId",
                table: "Monster");
        }
    }
}
