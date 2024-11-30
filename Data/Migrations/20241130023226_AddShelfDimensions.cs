using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingRoute.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddShelfDimensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Shelves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Shelves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Shelves");
        }
    }
}
