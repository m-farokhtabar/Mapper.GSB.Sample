using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mapper.GSB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GSBDatabase13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "personIdentifier",
                table: "PersonInsuranceDataCoordinator",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "personIdentifier",
                table: "PersonInsuranceDataCoordinator");
        }
    }
}
