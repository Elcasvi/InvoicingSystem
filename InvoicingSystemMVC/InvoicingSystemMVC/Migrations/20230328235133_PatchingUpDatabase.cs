using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoicingSystemMVC.Migrations
{
    public partial class PatchingUpDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_RFCReceptor",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Contribuyentes_RFCEmsior",
                table: "Facturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes");

            migrationBuilder.RenameColumn(
                name: "CP",
                table: "Facturas",
                newName: "RegimenFiscalReceptor");

            migrationBuilder.AlterColumn<string>(
                name: "RFCReceptor",
                table: "Facturas",
                type: "nvarchar(13)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)");

            migrationBuilder.AlterColumn<string>(
                name: "RFCEmsior",
                table: "Facturas",
                type: "nvarchar(13)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)");

            migrationBuilder.AddColumn<string>(
                name: "CPEmisor",
                table: "Facturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CPReceptor",
                table: "Facturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RFC",
                table: "Contribuyentes",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Contribuyentes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Contribuyentes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegimenFiscal",
                table: "Contribuyentes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RFC",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddColumn<int>(
                name: "ContribuyenteId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegimenFiscal",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContribuyentesEmisores",
                columns: table => new
                {
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegimenFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContribuyentesEmisores", x => x.RFC);
                });

            migrationBuilder.CreateTable(
                name: "ContribuyentesReceptores",
                columns: table => new
                {
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegimenFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContribuyentesReceptores", x => x.RFC);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ContribuyenteId",
                table: "Clientes",
                column: "ContribuyenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Contribuyentes_ContribuyenteId",
                table: "Clientes",
                column: "ContribuyenteId",
                principalTable: "Contribuyentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_ContribuyentesEmisores_RFCEmsior",
                table: "Facturas",
                column: "RFCEmsior",
                principalTable: "ContribuyentesEmisores",
                principalColumn: "RFC",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_ContribuyentesReceptores_RFCReceptor",
                table: "Facturas",
                column: "RFCReceptor",
                principalTable: "ContribuyentesReceptores",
                principalColumn: "RFC",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Contribuyentes_ContribuyenteId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_ContribuyentesEmisores_RFCEmsior",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_ContribuyentesReceptores_RFCReceptor",
                table: "Facturas");

            migrationBuilder.DropTable(
                name: "ContribuyentesEmisores");

            migrationBuilder.DropTable(
                name: "ContribuyentesReceptores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ContribuyenteId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CPEmisor",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "CPReceptor",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Contribuyentes");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Contribuyentes");

            migrationBuilder.DropColumn(
                name: "RegimenFiscal",
                table: "Contribuyentes");

            migrationBuilder.DropColumn(
                name: "ContribuyenteId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "RegimenFiscal",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "RegimenFiscalReceptor",
                table: "Facturas",
                newName: "CP");

            migrationBuilder.AlterColumn<string>(
                name: "RFCReceptor",
                table: "Facturas",
                type: "nvarchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)");

            migrationBuilder.AlterColumn<string>(
                name: "RFCEmsior",
                table: "Facturas",
                type: "nvarchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)");

            migrationBuilder.AlterColumn<string>(
                name: "RFC",
                table: "Contribuyentes",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "RFC",
                table: "Clientes",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes",
                column: "RFC");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_RFCReceptor",
                table: "Facturas",
                column: "RFCReceptor",
                principalTable: "Clientes",
                principalColumn: "RFC",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Contribuyentes_RFCEmsior",
                table: "Facturas",
                column: "RFCEmsior",
                principalTable: "Contribuyentes",
                principalColumn: "RFC",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
