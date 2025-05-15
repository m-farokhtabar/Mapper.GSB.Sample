using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mapper.GSB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GSBDatabase11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventModel",
                table: "EventModel");

            migrationBuilder.RenameTable(
                name: "EventModel",
                newName: "Event");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "EventModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventModel",
                table: "EventModel",
                column: "Id");
        }
    }
}
