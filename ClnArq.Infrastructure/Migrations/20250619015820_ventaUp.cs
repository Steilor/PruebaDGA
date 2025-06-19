using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClnArq.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ventaUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteNombre",
                table: "Ventas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductoNombre",
                table: "Ventas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductoPrecioUnitario",
                table: "Ventas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteNombre",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "ProductoNombre",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "ProductoPrecioUnitario",
                table: "Ventas");
        }
    }
}
