﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoicingSystemMVC.Migrations
{
    public partial class AzureDbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaveDeProductoOServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaveDeUnidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDeIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    TieneIVA = table.Column<bool>(type: "bit", nullable: false),
                    TasaIVA = table.Column<float>(type: "real", nullable: false),
                    TotalIVA = table.Column<float>(type: "real", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contribuyentes",
                columns: table => new
                {
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegimenFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuyentes", x => x.RFC);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFCEmsior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFCReceptor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDeFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsoDeFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaHoraDeExpedicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormaDePago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetodoDePago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Folio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondicionesDePago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtotalFactura = table.Column<float>(type: "real", nullable: false),
                    DescuentoFactura = table.Column<float>(type: "real", nullable: true),
                    TotalIVA = table.Column<float>(type: "real", nullable: false),
                    TotalFactura = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    RFC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegimenFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContribuyenteRFC = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.RFC);
                    table.ForeignKey(
                        name: "FK_Clientes_Contribuyentes_ContribuyenteRFC",
                        column: x => x.ContribuyenteRFC,
                        principalTable: "Contribuyentes",
                        principalColumn: "RFC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ContribuyenteRFC",
                table: "Clientes",
                column: "ContribuyenteRFC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Conceptos");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Contribuyentes");
        }
    }
}
