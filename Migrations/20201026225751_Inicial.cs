using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DROrdenes.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true),
                    Costo = table.Column<decimal>(nullable: false),
                    Inventario = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidorId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    SuplidorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Ordenes_Suplidores_SuplidorId",
                        column: x => x.SuplidorId,
                        principalTable: "Suplidores",
                        principalColumn: "SuplidorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(nullable: false),
                    Servicio = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdenId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<double>(nullable: false),
                    SuplidorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 1, 70m, "Pan", 150.0 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 2, 20m, "Jugos Ya", 230.0 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 3, 50m, "Coca Cola", 110.0 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 4, 42m, "Chocolate Cortes", 197.0 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 5, 317m, "Arroz Campo", 215.0 });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 1, "PapiGreza" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 2, "Nesttle" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 3, "La Sirena" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 4, "Porvenir" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 5, "Palmares" });

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_SuplidorId",
                table: "Ordenes",
                column: "SuplidorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_OrdenId",
                table: "OrdenesDetalle",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_ProductoId",
                table: "OrdenesDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaId",
                table: "VentasDetalle",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Suplidores");
        }
    }
}
