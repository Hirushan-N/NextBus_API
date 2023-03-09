using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextBus_API.Migrations
{
    /// <inheritdoc />
    public partial class BusOwner02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BusOwners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BusOwners",
                type: "bit",
                nullable: true);
        }
    }
}
