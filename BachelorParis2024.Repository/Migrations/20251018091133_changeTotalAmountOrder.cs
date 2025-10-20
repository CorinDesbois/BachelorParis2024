using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BachelorParis2024.Repository.Migrations
{
    /// <inheritdoc />
    public partial class changeTotalAmountOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Order");
        }
    }
}
