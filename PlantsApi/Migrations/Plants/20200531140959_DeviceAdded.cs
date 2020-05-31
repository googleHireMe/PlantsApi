using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantsApi.Migrations.Plants
{
    public partial class DeviceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantAssignment",
                table: "PlantAssignment");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "PlantAssignment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantAssignment",
                table: "PlantAssignment",
                columns: new[] { "UserId", "PlantId", "DeviceId" });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantAssignment_DeviceId",
                table: "PlantAssignment",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantAssignment_Device_DeviceId",
                table: "PlantAssignment",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantAssignment_Device_DeviceId",
                table: "PlantAssignment");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantAssignment",
                table: "PlantAssignment");

            migrationBuilder.DropIndex(
                name: "IX_PlantAssignment_DeviceId",
                table: "PlantAssignment");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "PlantAssignment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantAssignment",
                table: "PlantAssignment",
                columns: new[] { "UserId", "PlantId" });
        }
    }
}
