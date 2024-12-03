using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingRoute.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_WarehousePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartX = table.Column<double>(type: "REAL", nullable: false),
                    StartY = table.Column<double>(type: "REAL", nullable: false),
                    EndX = table.Column<double>(type: "REAL", nullable: false),
                    EndY = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paths", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paths");
        }
    }
}
