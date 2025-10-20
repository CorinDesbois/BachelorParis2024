using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BachelorParis2024.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddQRContentToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QrContent",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrContent",
                table: "Ticket");
        }
    }
}
