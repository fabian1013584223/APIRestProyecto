using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIRestProyecto.Migrations
{
    /// <inheritdoc />
    public partial class Base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Cantidad = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Productos_ProductoId1",
                        column: x => x.ProductoId1,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadReal = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CantidadIdeal = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CantidadMinima = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadAlarma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Stocks_StockId1",
                        column: x => x.StockId1,
                        principalTable: "Stocks",
                        principalColumn: "StockId");
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Cantidad", "Estado", "Lugar", "Nombre", "Precio", "ProductoId1" },
                values: new object[,]
                {
                    { 1, "1", "Activo", "Estante 2", "Computador Samsung 2018", "2600000", null },
                    { 2, "1", "Activo", "Estante 1", "Audifonos inalambricos", "250000", null },
                    { 3, "1", "Activo", "Estante 3", "Mouse inalambrico", "50000", null }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "CantidadAlarma", "CantidadIdeal", "CantidadMinima", "CantidadReal", "FechaIngreso", "StockId1" },
                values: new object[,]
                {
                    { 1, "5", "50", "20", "150", "2023-06-14", null },
                    { 2, "5", "100", "30", "250", "2023-06-15", null },
                    { 3, "5", "40", "10", "80", "2023-06-16", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProductoId1",
                table: "Productos",
                column: "ProductoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockId1",
                table: "Stocks",
                column: "StockId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
