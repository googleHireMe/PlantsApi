using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantsApi.Migrations.Plants
{
    public partial class PlantsInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Bloom = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Soil = table.Column<string>(nullable: true),
                    Sunlight = table.Column<string>(nullable: true),
                    Water = table.Column<string>(nullable: true),
                    Fertility = table.Column<string>(nullable: true),
                    MaxLightMmol = table.Column<int>(nullable: false),
                    MinLightMmol = table.Column<int>(nullable: false),
                    MaxLightLux = table.Column<int>(nullable: false),
                    MinLightLux = table.Column<int>(nullable: false),
                    MaxTemp = table.Column<int>(nullable: false),
                    MinTemp = table.Column<int>(nullable: false),
                    MaxEnvHumid = table.Column<int>(nullable: false),
                    MinEnvHumid = table.Column<int>(nullable: false),
                    MaxSoilMoist = table.Column<int>(nullable: false),
                    MinSoilMoist = table.Column<int>(nullable: false),
                    MaxSoilEc = table.Column<int>(nullable: false),
                    MinSoilEc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Passport = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantAssignment",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantAssignment", x => new { x.UserId, x.PlantId });
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
                    UserId = table.Column<int>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantAssignment_PlantId",
                table: "PlantAssignment",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantState_PlantId",
                table: "PlantState",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantState_UserId",
                table: "PlantState",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantAssignment");

            migrationBuilder.DropTable(
                name: "PlantState");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
