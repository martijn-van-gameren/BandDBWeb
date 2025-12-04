using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BandDBWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Item");

            migrationBuilder.UpdateData(
                table: "SerialNumbers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "ITEM10");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Ja");

            migrationBuilder.UpdateData(
                table: "SerialNumbers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "JAAAA");
        }
    }
}
