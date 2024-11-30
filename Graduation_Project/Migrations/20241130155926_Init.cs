using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation_Project.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypes", x => x.Id);
                });

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
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypeMonitoringAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowerRange = table.Column<int>(type: "int", nullable: false),
                    UpperRange = table.Column<int>(type: "int", nullable: false),
                    MonitoringAttributeId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypeMonitoringAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineTypeMonitoringAttributes_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineTypeMonitoringAttributes_MonitoringAttributes_MonitoringAttributeId",
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
                    LowerRange = table.Column<int>(type: "int", nullable: false),
                    UpperRange = table.Column<int>(type: "int", nullable: false),
                    ResourceConsumptionAttributeId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeId = table.Column<int>(type: "int", nullable: false)
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
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machines_Systems_SystemId",
                        column: x => x.SystemId,
                        principalTable: "Systems",
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
                    MonitoringAttributeId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonitoringData_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonitoringData_MonitoringAttributes_MonitoringAttributeId",
                        column: x => x.MonitoringAttributeId,
                        principalTable: "MonitoringAttributes",
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
                    ResourceConsumptionAttributeId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceConsumptionData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceConsumptionData_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceConsumptionData_ResourceConsumptionAttributes_ResourceConsumptionAttributeId",
                        column: x => x.ResourceConsumptionAttributeId,
                        principalTable: "ResourceConsumptionAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineTypeId",
                table: "Machines",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_SystemId",
                table: "Machines",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTypeMonitoringAttributes_MachineTypeId",
                table: "MachineTypeMonitoringAttributes",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTypeMonitoringAttributes_MonitoringAttributeId",
                table: "MachineTypeMonitoringAttributes",
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
                name: "IX_MonitoringData_MonitoringAttributeId",
                table: "MonitoringData",
                column: "MonitoringAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceConsumptionData_MachineId",
                table: "ResourceConsumptionData",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceConsumptionData_ResourceConsumptionAttributeId",
                table: "ResourceConsumptionData",
                column: "ResourceConsumptionAttributeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineTypeMonitoringAttributes");

            migrationBuilder.DropTable(
                name: "MachineTypeResourceConsumptionAttribute");

            migrationBuilder.DropTable(
                name: "MonitoringData");

            migrationBuilder.DropTable(
                name: "ResourceConsumptionData");

            migrationBuilder.DropTable(
                name: "MonitoringAttributes");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "ResourceConsumptionAttributes");

            migrationBuilder.DropTable(
                name: "MachineTypes");

            migrationBuilder.DropTable(
                name: "Systems");
        }
    }
}
