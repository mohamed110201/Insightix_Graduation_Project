using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Graduation_Project.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "AlertRuleSequence");

            migrationBuilder.CreateTable(
                name: "CurrentMonitoringAttributesValues",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    MonitoringAttributeId = table.Column<int>(type: "int", nullable: false),
                    MonitoringAttributeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FailurePredictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailurePredictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineMonitoringData",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    MonitoringAttributeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MachineResourceConsumptionData",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    ResourceConsumptionAttributeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MachineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AIModelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "MachineTypeResourceConsumptionAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceConsumptionAttributeId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypeResourceConsumptionAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineTypeResourceConsumptionAttributes_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineTypeResourceConsumptionAttributes_ResourceConsumptionAttributes_ResourceConsumptionAttributeId",
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
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailurePredictionCheckPoint = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "MonitorAttributeAlertRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [AlertRuleSequence]"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineTypeMonitoringAttributeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitorAttributeAlertRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonitorAttributeAlertRules_MachineTypeMonitoringAttributes_MachineTypeMonitoringAttributeId",
                        column: x => x.MachineTypeMonitoringAttributeId,
                        principalTable: "MachineTypeMonitoringAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceConsumptionAttributeAlertRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [AlertRuleSequence]"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineTypeResourceConsumptionAttributeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceConsumptionAttributeAlertRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceConsumptionAttributeAlertRules_MachineTypeResourceConsumptionAttributes_MachineTypeResourceConsumptionAttributeId",
                        column: x => x.MachineTypeResourceConsumptionAttributeId,
                        principalTable: "MachineTypeResourceConsumptionAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Failure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Failure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Failure_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
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
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
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
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    MonitorAttributeAlertRuleId = table.Column<int>(type: "int", nullable: true),
                    ResourceConsumptionAttributeAlertRuleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alerts_MonitorAttributeAlertRules_MonitorAttributeAlertRuleId",
                        column: x => x.MonitorAttributeAlertRuleId,
                        principalTable: "MonitorAttributeAlertRules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alerts_ResourceConsumptionAttributeAlertRules_ResourceConsumptionAttributeAlertRuleId",
                        column: x => x.ResourceConsumptionAttributeAlertRuleId,
                        principalTable: "ResourceConsumptionAttributeAlertRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlertChangeLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertChangeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertChangeLogs_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MachineTypes",
                columns: new[] { "Id", "AIModelName", "Model", "Name" },
                values: new object[] { 1001, "best_model_overall.h5", "Wr001", "Wrapper Machine" });

            migrationBuilder.InsertData(
                table: "MonitoringAttributes",
                columns: new[] { "Id", "Name", "Unit" },
                values: new object[,]
                {
                    { 1001, "Flag roping", "None" },
                    { 1002, "Platform Position", "degree" },
                    { 1003, "Platform Motor frequency", "HZ" },
                    { 1004, "Temperature platform drive", "degree" },
                    { 1005, "Temperature slave drive", "degree" },
                    { 1006, "Temperature hoist drive", "degree" },
                    { 1007, "Tensione totale film", "%" },
                    { 1008, "Current speed cart", "%" },
                    { 1009, "Platform motor speed", "%" },
                    { 1010, "Lifting motor speed", "RPM" },
                    { 1011, "Platform rotation speed", "RPM" },
                    { 1012, "Slave rotation speed", "M/MIN" },
                    { 1013, "Lifting speed rotation", "M/MIN" }
                });

            migrationBuilder.InsertData(
                table: "Systems",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1001, "Wrapping System" });

            migrationBuilder.InsertData(
                table: "MachineTypeMonitoringAttributes",
                columns: new[] { "Id", "MachineTypeId", "MonitoringAttributeId" },
                values: new object[,]
                {
                    { 1, 1001, 1001 },
                    { 2, 1001, 1002 },
                    { 3, 1001, 1003 },
                    { 4, 1001, 1004 },
                    { 5, 1001, 1005 },
                    { 6, 1001, 1006 },
                    { 7, 1001, 1007 },
                    { 8, 1001, 1008 },
                    { 9, 1001, 1009 },
                    { 10, 1001, 1010 },
                    { 11, 1001, 1011 },
                    { 12, 1001, 1012 },
                    { 13, 1001, 1013 }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "FailurePredictionCheckPoint", "MachineTypeId", "SerialNumber", "SystemId" },
                values: new object[] { 1001, null, 1001, "WSN001", 1001 });

            migrationBuilder.CreateIndex(
                name: "IX_AlertChangeLogs_AlertId",
                table: "AlertChangeLogs",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_MachineId",
                table: "Alerts",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_MonitorAttributeAlertRuleId",
                table: "Alerts",
                column: "MonitorAttributeAlertRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_ResourceConsumptionAttributeAlertRuleId",
                table: "Alerts",
                column: "ResourceConsumptionAttributeAlertRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Failure_MachineId",
                table: "Failure",
                column: "MachineId");

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
                name: "IX_MachineTypeResourceConsumptionAttributes_MachineTypeId",
                table: "MachineTypeResourceConsumptionAttributes",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTypeResourceConsumptionAttributes_ResourceConsumptionAttributeId",
                table: "MachineTypeResourceConsumptionAttributes",
                column: "ResourceConsumptionAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitorAttributeAlertRules_MachineTypeMonitoringAttributeId",
                table: "MonitorAttributeAlertRules",
                column: "MachineTypeMonitoringAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringData_MachineId",
                table: "MonitoringData",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringData_MonitoringAttributeId",
                table: "MonitoringData",
                column: "MonitoringAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceConsumptionAttributeAlertRules_MachineTypeResourceConsumptionAttributeId",
                table: "ResourceConsumptionAttributeAlertRules",
                column: "MachineTypeResourceConsumptionAttributeId");

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
                name: "AlertChangeLogs");

            migrationBuilder.DropTable(
                name: "CurrentMonitoringAttributesValues");

            migrationBuilder.DropTable(
                name: "Failure");

            migrationBuilder.DropTable(
                name: "FailurePredictions");

            migrationBuilder.DropTable(
                name: "MachineMonitoringData");

            migrationBuilder.DropTable(
                name: "MachineResourceConsumptionData");

            migrationBuilder.DropTable(
                name: "MonitoringData");

            migrationBuilder.DropTable(
                name: "ResourceConsumptionData");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "MonitorAttributeAlertRules");

            migrationBuilder.DropTable(
                name: "ResourceConsumptionAttributeAlertRules");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "MachineTypeMonitoringAttributes");

            migrationBuilder.DropTable(
                name: "MachineTypeResourceConsumptionAttributes");

            migrationBuilder.DropTable(
                name: "MonitoringAttributes");

            migrationBuilder.DropTable(
                name: "MachineTypes");

            migrationBuilder.DropTable(
                name: "ResourceConsumptionAttributes");

            migrationBuilder.DropSequence(
                name: "AlertRuleSequence");
        }
    }
}
