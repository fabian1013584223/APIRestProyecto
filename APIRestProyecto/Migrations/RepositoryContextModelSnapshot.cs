﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace APIRestProyecto.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cantidad")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Precio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("Productos", t =>
                        {
                            t.Property("ProductoId")
                                .HasColumnName("ProductoId1");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cantidad = "1",
                            Estado = "Activo",
                            Lugar = "Estante 2",
                            Nombre = "Computador Samsung 2018",
                            Precio = "2600000"
                        },
                        new
                        {
                            Id = 2,
                            Cantidad = "1",
                            Estado = "Activo",
                            Lugar = "Estante 1",
                            Nombre = "Audifonos inalambricos",
                            Precio = "250000"
                        },
                        new
                        {
                            Id = 3,
                            Cantidad = "1",
                            Estado = "Activo",
                            Lugar = "Estante 3",
                            Nombre = "Mouse inalambrico",
                            Precio = "50000"
                        });
                });

            modelBuilder.Entity("Entities.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StockId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CantidadAlarma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CantidadIdeal")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("CantidadMinima")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CantidadReal")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("FechaIngreso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Stocks", t =>
                        {
                            t.Property("StockId")
                                .HasColumnName("StockId1");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CantidadAlarma = "5",
                            CantidadIdeal = "50",
                            CantidadMinima = "20",
                            CantidadReal = "150",
                            FechaIngreso = "2023-06-14"
                        },
                        new
                        {
                            Id = 2,
                            CantidadAlarma = "5",
                            CantidadIdeal = "100",
                            CantidadMinima = "30",
                            CantidadReal = "250",
                            FechaIngreso = "2023-06-15"
                        },
                        new
                        {
                            Id = 3,
                            CantidadAlarma = "5",
                            CantidadIdeal = "40",
                            CantidadMinima = "10",
                            CantidadReal = "80",
                            FechaIngreso = "2023-06-16"
                        });
                });

            modelBuilder.Entity("Entities.Models.Producto", b =>
                {
                    b.HasOne("Entities.Models.Producto", null)
                        .WithMany("Productos")
                        .HasForeignKey("ProductoId");
                });

            modelBuilder.Entity("Entities.Models.Stock", b =>
                {
                    b.HasOne("Entities.Models.Stock", null)
                        .WithMany("Stocks")
                        .HasForeignKey("StockId");
                });

            modelBuilder.Entity("Entities.Models.Producto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Entities.Models.Stock", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
