﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prj_RestaurantApi.Dao;

#nullable disable

namespace prj_RestaurantApi.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("prj_RestaurantApi.Models.Commande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateCommande")
                        .HasColumnType("datetime2");

                    b.Property<int>("employeIdId")
                        .HasColumnType("int");

                    b.Property<int>("jours")
                        .HasColumnType("int");

                    b.Property<int>("platIdId")
                        .HasColumnType("int");

                    b.Property<double>("prix")
                        .HasColumnType("float");

                    b.Property<int>("quantite")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("employeIdId");

                    b.HasIndex("platIdId");

                    b.ToTable("Commande");
                });

            modelBuilder.Entity("prj_RestaurantApi.Models.Employe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employes");
                });

            modelBuilder.Entity("prj_RestaurantApi.Models.Plat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("prix")
                        .HasColumnType("float");

                    b.Property<int>("tempspreparation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plats");
                });

            modelBuilder.Entity("prj_RestaurantApi.Models.Commande", b =>
                {
                    b.HasOne("prj_RestaurantApi.Models.Employe", "employeId")
                        .WithMany("Commandes")
                        .HasForeignKey("employeIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("prj_RestaurantApi.Models.Plat", "platId")
                        .WithMany("Commandes")
                        .HasForeignKey("platIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employeId");

                    b.Navigation("platId");
                });

            modelBuilder.Entity("prj_RestaurantApi.Models.Employe", b =>
                {
                    b.Navigation("Commandes");
                });

            modelBuilder.Entity("prj_RestaurantApi.Models.Plat", b =>
                {
                    b.Navigation("Commandes");
                });
#pragma warning restore 612, 618
        }
    }
}
