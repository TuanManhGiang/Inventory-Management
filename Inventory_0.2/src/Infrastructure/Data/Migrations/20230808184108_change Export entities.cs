using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_0._2.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeExportentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ExportInvoice",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ExportInvoice");
        }
    }
}
