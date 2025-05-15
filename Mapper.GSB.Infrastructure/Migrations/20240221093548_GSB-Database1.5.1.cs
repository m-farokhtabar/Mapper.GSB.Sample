using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mapper.GSB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GSBDatabase151 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Event_AggregateId",
                table: "Event",
                column: "AggregateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Event_AggregateId",
                table: "Event");
        }
    }
}
