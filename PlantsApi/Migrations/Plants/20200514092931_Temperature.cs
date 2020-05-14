using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantsApi.Migrations.Plants
{
    public partial class Temperature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temp",
                table: "PlantState");

            migrationBuilder.AddColumn<int>(
                name: "Temperature",
                table: "PlantState",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "PlantState");

            migrationBuilder.AddColumn<int>(
                name: "Temp",
                table: "PlantState",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
