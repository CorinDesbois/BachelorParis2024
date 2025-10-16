using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BachelorParis2024.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "UserId",
        table: "Carts",
        type: "nvarchar(450)",   // taille adaptée aux clés Identity
        nullable: false,
        oldClrType: typeof(int),
        oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
               name: "UserId",
               table: "Carts",
               type: "int",
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nvarchar(450)");
        }
    }
}
