using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoicingSystemMVC.Migrations
{
    public partial class InitPrincipalEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    RFC = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.RFC);
                });

            migrationBuilder.CreateTable(
                name: "Contribuyentes",
                columns: table => new
                {
                    RFC = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuyentes", x => x.RFC);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RFCEmsior = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    RFCReceptor = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    TipoDeFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsoDeFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaYHoraDeExpedicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormaDePago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetodoDePago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Folio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondicionesDePago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaveDeProductoOServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaveDeUnidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDeIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    TieneIVA = table.Column<bool>(type: "bit", nullable: false),
                    TasaIVA = table.Column<float>(type: "real", nullable: false),
                    TotalIVA = table.Column<float>(type: "real", nullable: false),
                    SubtotalFactura = table.Column<float>(type: "real", nullable: false),
                    DescuentoFactura = table.Column<float>(type: "real", nullable: true),
                    TotalFactura = table.Column<float>(type: "real", nullable: false),
                    StatusDeFactura = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_RFCReceptor",
                        column: x => x.RFCReceptor,
                        principalTable: "Clientes",
                        principalColumn: "RFC",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_Contribuyentes_RFCEmsior",
                        column: x => x.RFCEmsior,
                        principalTable: "Contribuyentes",
                        principalColumn: "RFC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_RFCEmsior",
                table: "Facturas",
                column: "RFCEmsior");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_RFCReceptor",
                table: "Facturas",
                column: "RFCReceptor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Contribuyentes");
        }
    }
}
