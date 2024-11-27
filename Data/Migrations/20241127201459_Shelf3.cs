using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingRoute.Data.Migrations
{
    /// <inheritdoc />
    public partial class Shelf3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelfs",
                table: "Shelfs");

            migrationBuilder.RenameTable(
                name: "Shelfs",
                newName: "Shelves");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelves",
                table: "Shelves",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelves",
                table: "Shelves");

            migrationBuilder.RenameTable(
                name: "Shelves",
                newName: "Shelfs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelfs",
                table: "Shelfs",
                column: "Id");
        }
    }
}
