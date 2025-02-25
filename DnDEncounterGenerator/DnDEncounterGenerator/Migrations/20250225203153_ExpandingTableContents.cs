using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDEncounterGenerator.Migrations
{
    /// <inheritdoc />
    public partial class ExpandingTableContents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Health",
                table: "Monsters");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Monsters",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArmorClass",
                table: "Monsters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Charisma",
                table: "Monsters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Constitution",
                table: "Monsters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dexterity",
                table: "Monsters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HitPoints",
                table: "Monsters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Intelligence",
                table: "Monsters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Speed",
                table: "Monsters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Monsters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wisdom",
                table: "Monsters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 1,
                columns: new[] { "ArmorClass", "Charisma", "Constitution", "Dexterity", "HitPoints", "Intelligence", "Speed", "Strength", "Wisdom" },
                values: new object[] { 10, 10, 10, 10, 10, 10, "20 ft", 10, 10 });

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 2,
                columns: new[] { "ArmorClass", "Charisma", "Constitution", "Dexterity", "HitPoints", "Intelligence", "Speed", "Strength", "Wisdom" },
                values: new object[] { 10, 10, 10, 10, 10, 10, "20 ft", 10, 10 });

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 3,
                columns: new[] { "ArmorClass", "Charisma", "Constitution", "Dexterity", "HitPoints", "Intelligence", "Speed", "Strength", "Wisdom" },
                values: new object[] { 10, 10, 10, 10, 10, 10, "20 ft", 10, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmorClass",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Charisma",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Constitution",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Dexterity",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "HitPoints",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Intelligence",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Wisdom",
                table: "Monsters");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Monsters",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Health",
                table: "Monsters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 1,
                column: "Health",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 2,
                column: "Health",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 3,
                column: "Health",
                value: 6);
        }
    }
}
