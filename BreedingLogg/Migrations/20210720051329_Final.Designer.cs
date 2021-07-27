﻿// <auto-generated />
using System;
using BreedingLogg.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BreedingLogg.Migrations
{
    [DbContext(typeof(ContextoBD))]
    [Migration("20210720051329_Final")]
    partial class Final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BreedingLogg.Modelos.Ciudad", b =>
                {
                    b.Property<int>("CiudadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCiudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CiudadId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("BreedingLogg.Modelos.Criador", b =>
                {
                    b.Property<int>("CriadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidosCriador")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ContraseñaCriador")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("CorreoC")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("DireccionCriadero")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("EspecieQC")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("FotoCriadero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoCriador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelCriador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCriador")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RedSocialC")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("StatusCriador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCriador")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("CriadorId");

                    b.ToTable("Criadores");
                });

            modelBuilder.Entity("BreedingLogg.Modelos.Cruce", b =>
                {
                    b.Property<int>("CruceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CriadorId")
                        .HasColumnType("int");

                    b.Property<int>("CriasFallecidas")
                        .HasColumnType("int");

                    b.Property<int>("CriasHembras")
                        .HasColumnType("int");

                    b.Property<int>("CriasMachos")
                        .HasColumnType("int");

                    b.Property<int>("CriasNacidas")
                        .HasColumnType("int");

                    b.Property<int>("EjemplarHembraId")
                        .HasColumnType("int");

                    b.Property<int>("EjemplarMachoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEmparejamientoCria")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimientoCria")
                        .HasColumnType("datetime2");

                    b.Property<string>("GeneroCria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCria")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("StatusCruce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CruceId");

                    b.HasIndex("CriadorId");

                    b.HasIndex("EjemplarHembraId");

                    b.HasIndex("EjemplarMachoId");

                    b.ToTable("Cruces");
                });

            modelBuilder.Entity("BreedingLogg.Modelos.EjemplarHembra", b =>
                {
                    b.Property<int>("EjemplarHembraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<int>("CodigoPostalEjemplarHembra")
                        .HasColumnType("int");

                    b.Property<string>("ColorEjemplarHembra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CriadorId")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionEjemplarHembra")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimientoEjemplarHembra")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoEjemplarHembra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneroEjemplarHembra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEjemplarHembra")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PedegreeEjemplarHembra")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("RazaEjemplarHembra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusEjemplarHembra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariedadEjemplarHembra")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("EjemplarHembraId");

                    b.HasIndex("CiudadId");

                    b.HasIndex("CriadorId");

                    b.HasIndex("EstadoId");

                    b.ToTable("EjemplarHembras");
                });

            modelBuilder.Entity("BreedingLogg.Modelos.EjemplarMacho", b =>
                {
                    b.Property<int>("EjemplarMachoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<int>("CodigoPostalEjemplarMacho")
                        .HasColumnType("int");

                    b.Property<string>("ColorEjemplarMacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CriadorId")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionEjemplarMacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimientoEjemplarMacho")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoEjemplarMacho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneroEjemplarMacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEjemplarMacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PedegreeEjemplarMacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("RazaEjemplarMacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusEjemplarMacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariedadEjemplarMacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("EjemplarMachoId");

                    b.HasIndex("CiudadId");

                    b.HasIndex("CriadorId");

                    b.HasIndex("EstadoId");

                    b.ToTable("EjemplaresMachos");
                });

            modelBuilder.Entity("BreedingLogg.Modelos.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("BreedingLogg.Modelos.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidosUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ContraseñaUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("CorreoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("NivelUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UsuarioUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BreedingLogg.Modelos.Ciudad", b =>
                {
                    b.HasOne("BreedingLogg.Modelos.Estado", "Estado")
                        .WithMany("Ciudades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BreedingLogg.Modelos.Cruce", b =>
                {
                    b.HasOne("BreedingLogg.Modelos.Criador", "Criador")
                        .WithMany("Cruces")
                        .HasForeignKey("CriadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BreedingLogg.Modelos.EjemplarHembra", "EjemplarHembra")
                        .WithMany("Cruces")
                        .HasForeignKey("EjemplarHembraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BreedingLogg.Modelos.EjemplarMacho", "EjemplarMacho")
                        .WithMany("Cruces")
                        .HasForeignKey("EjemplarMachoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BreedingLogg.Modelos.EjemplarHembra", b =>
                {
                    b.HasOne("BreedingLogg.Modelos.Ciudad", "Ciudad")
                        .WithMany("EjemplarHembras")
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BreedingLogg.Modelos.Criador", "Criador")
                        .WithMany("EjemplarHembras")
                        .HasForeignKey("CriadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BreedingLogg.Modelos.Estado", "Estado")
                        .WithMany("EjemplarHembras")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BreedingLogg.Modelos.EjemplarMacho", b =>
                {
                    b.HasOne("BreedingLogg.Modelos.Ciudad", "Ciudad")
                        .WithMany("EjemplarMachos")
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BreedingLogg.Modelos.Criador", "Criador")
                        .WithMany("EjemplarMachos")
                        .HasForeignKey("CriadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BreedingLogg.Modelos.Estado", "Estado")
                        .WithMany("EjemplarMachos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}