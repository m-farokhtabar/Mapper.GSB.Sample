using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mapper.GSB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GSBDatabase10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AggregateName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    CorrelationId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonInsuranceDataCoordinator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    openEHRPartyId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    openEHRPartyRelationshipId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PersonId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    PersonIdType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PolicyUniqueCode = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    InsurerId = table.Column<int>(type: "int", nullable: false),
                    insurer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    insuranceExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    policyType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DomainModel = table.Column<int>(type: "int", nullable: false),
                    PatientUID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompositionUID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShebadId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GSBResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    PersonInsuranceCreatedEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonInsuranceVersion = table.Column<int>(type: "int", nullable: false),
                    GSBIgin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GSBRegisterID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    error = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shebad = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInsuranceDataCoordinator", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInsuranceDataCoordinator_CreatedDate_InsurerId",
                table: "PersonInsuranceDataCoordinator",
                columns: new[] { "CreatedDate", "InsurerId" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInsuranceDataCoordinator_CreatedDate_Status_InsurerId",
                table: "PersonInsuranceDataCoordinator",
                columns: new[] { "CreatedDate", "Status", "InsurerId" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInsuranceDataCoordinator_PersonId_InsurerId_AccountID",
                table: "PersonInsuranceDataCoordinator",
                columns: new[] { "PersonId", "InsurerId", "AccountID" })
                .Annotation("SqlServer:Include", new[] { "RegisterUID", "MessageUID", "Version" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInsuranceDataCoordinator_PersonId_InsurerId_PolicyUniqueCode",
                table: "PersonInsuranceDataCoordinator",
                columns: new[] { "PersonId", "InsurerId", "PolicyUniqueCode" })
                .Annotation("SqlServer:Include", new[] { "RegisterUID", "MessageUID", "Version" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInsuranceDataCoordinator_PersonId_PersonIdType",
                table: "PersonInsuranceDataCoordinator",
                columns: new[] { "PersonId", "PersonIdType" },
                filter: "[Status]>=4")
                .Annotation("SqlServer:Include", new[] { "openEHRPartyId", "openEHRPartyRelationshipId", "Status", "RegisterUID" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInsuranceDataCoordinator_RegisterUID",
                table: "PersonInsuranceDataCoordinator",
                column: "RegisterUID",
                filter: "[Status]>=4")
                .Annotation("SqlServer:Include", new[] { "PersonIdType", "openEHRPartyId", "openEHRPartyRelationshipId", "Status", "PersonId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventModel");

            migrationBuilder.DropTable(
                name: "PersonInsuranceDataCoordinator");
        }
    }
}
