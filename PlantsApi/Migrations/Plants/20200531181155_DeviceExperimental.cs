using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantsApi.Migrations.Plants
{
    public partial class DeviceExperimental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantState_Plant_PlantId",
                table: "PlantState");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantState_User_UserId",
                table: "PlantState");

            migrationBuilder.DropIndex(
                name: "IX_PlantState_PlantId",
                table: "PlantState");

            migrationBuilder.DropIndex(
                name: "IX_PlantState_UserId",
                table: "PlantState");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "PlantState");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PlantState");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "PlantState",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "Device",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Device",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantState_DeviceId",
                table: "PlantState",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Device_PlantId",
                table: "Device",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_UserId",
                table: "Device",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Plant_PlantId",
                table: "Device",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_User_UserId",
                table: "Device",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantState_Device_DeviceId",
                table: "PlantState",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Plant_PlantId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_User_UserId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantState_Device_DeviceId",
                table: "PlantState");

            migrationBuilder.DropIndex(
                name: "IX_PlantState_DeviceId",
                table: "PlantState");

            migrationBuilder.DropIndex(
                name: "IX_Device_PlantId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_UserId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "PlantState");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Device");

            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "PlantState",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PlantState",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlantState_PlantId",
                table: "PlantState",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantState_UserId",
                table: "PlantState",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantState_Plant_PlantId",
                table: "PlantState",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantState_User_UserId",
                table: "PlantState",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
