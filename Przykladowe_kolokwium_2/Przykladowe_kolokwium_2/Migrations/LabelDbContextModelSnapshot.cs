﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Przykladowe_kolokwium_2.Context;

#nullable disable

namespace Przykladowe_kolokwium_2.Migrations
{
    [DbContext(typeof(LabelDbContext))]
    partial class LabelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlbum"));

                    b.Property<DateTime>("DataWydania")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdWytwornia")
                        .HasColumnType("int");

                    b.Property<string>("NazwaAlbumu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdWytwornia");

                    b.ToTable("Album", (string)null);
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Muzyk", b =>
                {
                    b.Property<int>("IdMuzyk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMuzyk"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Pseudonim")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMuzyk");

                    b.ToTable("Muzyk", (string)null);
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Utwor", b =>
                {
                    b.Property<int>("IdUtwor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUtwor"));

                    b.Property<double>("CzasTrwania")
                        .HasColumnType("float");

                    b.Property<int?>("IdAlbum")
                        .HasColumnType("int");

                    b.Property<string>("NazwaUtworu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdUtwor");

                    b.HasIndex("IdAlbum");

                    b.ToTable("Utwor", (string)null);
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.WykonawcaUtworu", b =>
                {
                    b.Property<int>("IdMuzyk")
                        .HasColumnType("int");

                    b.Property<int>("IdUtwor")
                        .HasColumnType("int");

                    b.HasKey("IdMuzyk", "IdUtwor");

                    b.HasIndex("IdUtwor");

                    b.ToTable("WykonawcaUtworu", (string)null);
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Wytwornia", b =>
                {
                    b.Property<int>("IdWytwornia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdWytwornia"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdWytwornia");

                    b.ToTable("Wytwornia", (string)null);
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Album", b =>
                {
                    b.HasOne("Przykladowe_kolokwium_2.Entities.Wytwornia", "Wytwornia")
                        .WithMany("Albums")
                        .HasForeignKey("IdWytwornia")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Wytwornia_Album");

                    b.Navigation("Wytwornia");
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Utwor", b =>
                {
                    b.HasOne("Przykladowe_kolokwium_2.Entities.Album", "Album")
                        .WithMany("Utwory")
                        .HasForeignKey("IdAlbum");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.WykonawcaUtworu", b =>
                {
                    b.HasOne("Przykladowe_kolokwium_2.Entities.Muzyk", "Muzyk")
                        .WithMany("Utwory")
                        .HasForeignKey("IdMuzyk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Przykladowe_kolokwium_2.Entities.Utwor", "Utwor")
                        .WithMany("Muzycy")
                        .HasForeignKey("IdUtwor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Muzyk");

                    b.Navigation("Utwor");
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Album", b =>
                {
                    b.Navigation("Utwory");
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Muzyk", b =>
                {
                    b.Navigation("Utwory");
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Utwor", b =>
                {
                    b.Navigation("Muzycy");
                });

            modelBuilder.Entity("Przykladowe_kolokwium_2.Entities.Wytwornia", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
