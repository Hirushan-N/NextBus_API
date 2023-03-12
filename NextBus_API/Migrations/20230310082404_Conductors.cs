using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextBus_API.Migrations
{
    /// <inheritdoc />
    public partial class Conductors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConductorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusOwnerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conductors_BusOwners_BusOwnerId",
                        column: x => x.BusOwnerId,
                        principalTable: "BusOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_BusOwnerId",
                table: "Conductors",
                column: "BusOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conductors");
        }
    }
}
