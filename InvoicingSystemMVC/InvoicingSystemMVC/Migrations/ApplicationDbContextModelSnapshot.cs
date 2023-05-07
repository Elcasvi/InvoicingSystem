﻿// <auto-generated />
using System;
using InvoicingSystemMVC.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoicingSystemMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InvoicingSystemMVC.Models.Entities.Cliente", b =>
                {
                    b.Property<string>("RFC")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContribuyenteRFC")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegimenFiscal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RFC");

                    b.HasIndex("ContribuyenteRFC");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("InvoicingSystemMVC.Models.Entities.Concepto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("ClaveDeProductoOServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaveDeUnidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroDeIdentificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TasaIVA")
                        .HasColumnType("real");

                    b.Property<bool>("TieneIVA")
                        .HasColumnType("bit");

                    b.Property<float>("TotalIVA")
                        .HasColumnType("real");

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ValorUnitario")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.ToTable("Conceptos");
                });

            modelBuilder.Entity("InvoicingSystemMVC.Models.Entities.Contribuyente", b =>
                {
                    b.Property<string>("RFC")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("CP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegimenFiscal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RFC");

                    b.ToTable("Contribuyentes");
                });

            modelBuilder.Entity("InvoicingSystemMVC.Models.Entities.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CondicionesDePago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("DescuentoFactura")
                        .HasColumnType("real");

                    b.Property<string>("FechaHoraDeExpedicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Folio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormaDePago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetodoDePago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moneda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RFCEmsior")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RFCReceptor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Serie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SubtotalFactura")
                        .HasColumnType("real");

                    b.Property<string>("TipoDeFactura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalFactura")
                        .HasColumnType("real");

                    b.Property<float>("TotalIVA")
                        .HasColumnType("real");

                    b.Property<string>("UsoDeFactura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("InvoicingSystemMVC.Models.Entities.Cliente", b =>
                {
                    b.HasOne("InvoicingSystemMVC.Models.Entities.Contribuyente", "Contribuyente")
                        .WithMany()
                        .HasForeignKey("ContribuyenteRFC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contribuyente");
                });

            modelBuilder.Entity("InvoicingSystemMVC.Models.Entities.Concepto", b =>
                {
                    b.HasOne("InvoicingSystemMVC.Models.Entities.Factura", "Factura")
                        .WithMany()
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");
                });
#pragma warning restore 612, 618
        }
    }
}
