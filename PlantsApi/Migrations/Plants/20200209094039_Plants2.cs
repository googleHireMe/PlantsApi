using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantsApi.Migrations.Plants
{
    public partial class Plants2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantAssignment_Plant_PlantID",
                table: "PlantAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantAssignment_User_UserID",
                table: "PlantAssignment");

            migrationBuilder.DropTable(
                name: "PlantStateHistory");

            migrationBuilder.RenameColumn(
                name: "PlantID",
                table: "PlantAssignment",
                newName: "PlantId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "PlantAssignment",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantAssignment_PlantID",
                table: "PlantAssignment",
                newName: "IX_PlantAssignment_PlantId");

            migrationBuilder.CreateTable(
                name: "PlantState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(nullable: false),
                    Light = table.Column<int>(nullable: false),
                    Temp = table.Column<int>(nullable: false),
                    EnvHumid = table.Column<int>(nullable: false),
                    SoilMoist = table.Column<int>(nullable: false),
                    SoilEc = table.Column<int>(nullable: false),
                    PlantId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantState_Plant_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantState_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantState_PlantId",
                table: "PlantState",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantState_UserId",
                table: "PlantState",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantAssignment_Plant_PlantId",
                table: "PlantAssignment",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantAssignment_User_UserId",
                table: "PlantAssignment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantAssignment_Plant_PlantId",
                table: "PlantAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantAssignment_User_UserId",
                table: "PlantAssignment");

            migrationBuilder.DropTable(
                name: "PlantState");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "PlantAssignment",
                newName: "PlantID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PlantAssignment",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_PlantAssignment_PlantId",
                table: "PlantAssignment",
                newName: "IX_PlantAssignment_PlantID");

            migrationBuilder.CreateTable(
                name: "PlantStateHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnvHumid = table.Column<int>(type: "int", nullable: false),
                    Light = table.Column<int>(type: "int", nullable: false),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    SoilEc = table.Column<int>(type: "int", nullable: false),
                    SoilMoist = table.Column<int>(type: "int", nullable: false),
                    Temp = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantStateHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantStateHistory_Plant_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantStateHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantStateHistory_PlantID",
                table: "PlantStateHistory",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantStateHistory_UserId",
                table: "PlantStateHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantAssignment_Plant_PlantID",
                table: "PlantAssignment",
                column: "PlantID",
                principalTable: "Plant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantAssignment_User_UserID",
                table: "PlantAssignment",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
