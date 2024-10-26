using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickingRoute.Migrations
{
    /// <inheritdoc />
    public partial class AddProductItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    strangeLocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    strangeLocationY = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.ProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItems");
        }
    }
}
