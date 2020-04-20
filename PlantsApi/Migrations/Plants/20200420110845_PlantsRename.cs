using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantsApi.Migrations.Plants
{
    public partial class PlantsRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTemp",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "MinTemp",
                table: "Plant");

            migrationBuilder.AddColumn<int>(
                name: "MaxTemperature",
                table: "Plant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinTemperature",
                table: "Plant",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "Plant");

            migrationBuilder.AddColumn<int>(
                name: "MaxTemp",
                table: "Plant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinTemp",
                table: "Plant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
