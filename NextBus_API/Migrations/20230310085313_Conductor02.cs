using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextBus_API.Migrations
{
    /// <inheritdoc />
    public partial class Conductor02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conductors_BusOwners_BusOwnerId",
                table: "Conductors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conductors",
                table: "Conductors");

            migrationBuilder.DropIndex(
                name: "IX_Conductors_BusOwnerId",
                table: "Conductors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusOwners",
                table: "BusOwners");

            migrationBuilder.DropColumn(
                name: "BusOwnerId",
                table: "Conductors");

            migrationBuilder.AlterColumn<string>(
                name: "ConductorCode",
                table: "Conductors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusOwnerCode",
                table: "Conductors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusOwnerCode",
                table: "BusOwners",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conductors",
                table: "Conductors",
                column: "ConductorCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusOwners",
                table: "BusOwners",
                column: "BusOwnerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_BusOwnerCode",
                table: "Conductors",
                column: "BusOwnerCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Conductors_BusOwners_BusOwnerCode",
                table: "Conductors",
                column: "BusOwnerCode",
                principalTable: "BusOwners",
                principalColumn: "BusOwnerCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conductors_BusOwners_BusOwnerCode",
                table: "Conductors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conductors",
                table: "Conductors");

            migrationBuilder.DropIndex(
                name: "IX_Conductors_BusOwnerCode",
                table: "Conductors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusOwners",
                table: "BusOwners");

            migrationBuilder.AlterColumn<string>(
                name: "BusOwnerCode",
                table: "Conductors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConductorCode",
                table: "Conductors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "BusOwnerId",
                table: "Conductors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "BusOwnerCode",
                table: "BusOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conductors",
                table: "Conductors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusOwners",
                table: "BusOwners",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Conductors_BusOwnerId",
                table: "Conductors",
                column: "BusOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conductors_BusOwners_BusOwnerId",
                table: "Conductors",
                column: "BusOwnerId",
                principalTable: "BusOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
