using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantsApi.Migrations.Plants
{
    public partial class DeviceAddedFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantAssignment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantAssignment",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantAssignment", x => new { x.UserId, x.PlantId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK_PlantAssignment_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantAssignment_Plant_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantAssignment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantAssignment_DeviceId",
                table: "PlantAssignment",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantAssignment_PlantId",
                table: "PlantAssignment",
                column: "PlantId");
        }
    }
}
