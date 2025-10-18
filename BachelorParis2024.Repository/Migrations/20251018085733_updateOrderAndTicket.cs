using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BachelorParis2024.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderAndTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEvent",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IdOffer",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "IdEvent",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdOffer",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
