using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDEncounterGenerator.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixingEncounterTableV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monster_Encounter_EncounterId",
                table: "Monster");

            migrationBuilder.DropIndex(
                name: "IX_Monster_EncounterId",
                table: "Monster");

            migrationBuilder.DropColumn(
                name: "EncounterId",
                table: "Monster");

            migrationBuilder.CreateTable(
                name: "EncounterMonster",
                columns: table => new
                {
                    EncountersEncounterId = table.Column<int>(type: "INTEGER", nullable: false),
                    MonstersMonsterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncounterMonster", x => new { x.EncountersEncounterId, x.MonstersMonsterId });
                    table.ForeignKey(
                        name: "FK_EncounterMonster_Encounter_EncountersEncounterId",
                        column: x => x.EncountersEncounterId,
                        principalTable: "Encounter",
                        principalColumn: "EncounterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncounterMonster_Monster_MonstersMonsterId",
                        column: x => x.MonstersMonsterId,
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncounterMonster_MonstersMonsterId",
                table: "EncounterMonster",
                column: "MonstersMonsterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncounterMonster");

            migrationBuilder.AddColumn<int>(
                name: "EncounterId",
                table: "Monster",
                type: "INTEGER",
                nullable: true);

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
    }
}
