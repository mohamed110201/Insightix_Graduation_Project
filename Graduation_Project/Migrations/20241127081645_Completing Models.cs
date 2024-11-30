using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation_Project.Migrations
{
    /// <inheritdoc />
    public partial class CompletingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonitoringAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceConsumptionAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceConsumptionAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypeMonitoringAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonitorAttributeId = table.Column<int>(type: "int", nullable: false),
                    MonitoringAttributeId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeId = table.Column<int>(type: "int", nullable: false),
                    LowerRange = table.Column<int>(type: "int", nullable: false),
                    UpperRange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypeMonitoringAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineTypeMonitoringAttribute_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineTypeMonitoringAttribute_MonitoringAttributes_MonitoringAttributeId",
                        column: x => x.MonitoringAttributeId,
                        principalTable: "MonitoringAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypeResourceConsumptionAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceConsumptionAttributeId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeId = table.Column<int>(type: "int", nullable: false),
                    LowerRange = table.Column<int>(type: "int", nullable: false),
                    UpperRange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypeResourceConsumptionAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineTypeResourceConsumptionAttribute_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineTypeResourceConsumptionAttribute_ResourceConsumptionAttributes_ResourceConsumptionAttributeId",
                        column: x => x.ResourceConsumptionAttributeId,
                        principalTable: "ResourceConsumptionAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonitoringData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeMonitoringAttributeId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonitoringData_MachineTypeMonitoringAttribute_MachineTypeMonitoringAttributeId",
                        column: x => x.MachineTypeMonitoringAttributeId,
                        principalTable: "MachineTypeMonitoringAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonitoringData_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceConsumptionData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeResourceConsumptionAttributeId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceConsumptionData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceConsumptionData_MachineTypeResourceConsumptionAttribute_MachineTypeResourceConsumptionAttributeId",
                        column: x => x.MachineTypeResourceConsumptionAttributeId,
                        principalTable: "MachineTypeResourceConsumptionAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceConsumptionData_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineTypeMonitoringAttribute_MachineTypeId",
                table: "MachineTypeMonitoringAttribute",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTypeMonitoringAttribute_MonitoringAttributeId",
                table: "MachineTypeMonitoringAttribute",
                column: "MonitoringAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTypeResourceConsumptionAttribute_MachineTypeId",
                table: "MachineTypeResourceConsumptionAttribute",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTypeResourceConsumptionAttribute_ResourceConsumptionAttributeId",
                table: "MachineTypeResourceConsumptionAttribute",
                column: "ResourceConsumptionAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringData_MachineId",
                table: "MonitoringData",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringData_MachineTypeMonitoringAttributeId",
                table: "MonitoringData",
                column: "MachineTypeMonitoringAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceConsumptionData_MachineId",
                table: "ResourceConsumptionData",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceConsumptionData_MachineTypeResourceConsumptionAttributeId",
                table: "ResourceConsumptionData",
                column: "MachineTypeResourceConsumptionAttributeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitoringData");

            migrationBuilder.DropTable(
                name: "ResourceConsumptionData");

            migrationBuilder.DropTable(
                name: "MachineTypeMonitoringAttribute");

            migrationBuilder.DropTable(
                name: "MachineTypeResourceConsumptionAttribute");

            migrationBuilder.DropTable(
                name: "MonitoringAttributes");

            migrationBuilder.DropTable(
                name: "ResourceConsumptionAttributes");
        }
    }
}
