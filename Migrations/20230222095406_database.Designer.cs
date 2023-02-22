﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poj.Context;

#nullable disable

namespace Poj.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230222095406_database")]
    partial class database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Poj.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Projecto_vendas.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Projecto_vendas.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CategoriaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Projecto_vendas.Models.Venda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<int>("NumVenda")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Projecto_vendas.Models.Produto", b =>
                {
                    b.HasOne("Poj.Models.Categoria", null)
                        .WithMany("vendas")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("Projecto_vendas.Models.Venda", b =>
                {
                    b.HasOne("Projecto_vendas.Models.Cliente", null)
                        .WithMany("vendas")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Projecto_vendas.Models.Produto", null)
                        .WithMany("vendas")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("Poj.Models.Categoria", b =>
                {
                    b.Navigation("vendas");
                });

            modelBuilder.Entity("Projecto_vendas.Models.Cliente", b =>
                {
                    b.Navigation("vendas");
                });

            modelBuilder.Entity("Projecto_vendas.Models.Produto", b =>
                {
                    b.Navigation("vendas");
                });
#pragma warning restore 612, 618
        }
    }
}