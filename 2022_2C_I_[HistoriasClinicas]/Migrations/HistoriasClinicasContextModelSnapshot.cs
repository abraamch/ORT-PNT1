﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2022_2C_I__HistoriasClinicas_.Data;

#nullable disable

namespace _2022_2C_I__HistoriasClinicas_.Migrations
{
    [DbContext(typeof(HistoriasClinicasContext))]
    partial class HistoriasClinicasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Episodio", b =>
                {
                    b.Property<int>("EpisodioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpisodioId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescripcionAtencion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoAbierto")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaYHoraAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaYHoraCierre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaYHoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("HistoriaClinicaId")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpisodioId");

                    b.HasIndex("HistoriaClinicaId");

                    b.ToTable("Episodios");
                });

            modelBuilder.Entity("HistoriaClinica", b =>
                {
                    b.Property<int>("HistoriaClinicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoriaClinicaId"), 1L, 1);

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("HistoriaClinicaId");

                    b.HasIndex("PacienteId")
                        .IsUnique();

                    b.ToTable("HistoriaClinica");
                });

            modelBuilder.Entity("Medico", b =>
                {
                    b.Property<int>("MedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicoId"), 1L, 1);

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("nombreDeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.HasKey("MedicoId");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("Nota", b =>
                {
                    b.Property<int>("NotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotaId"), 1L, 1);

                    b.Property<int>("EpisodioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaYHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotaId");

                    b.HasIndex("EpisodioId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteId"), 1L, 1);

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("ObraSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("nombreDeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.HasKey("PacienteId");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Episodio", b =>
                {
                    b.HasOne("HistoriaClinica", null)
                        .WithMany("Episodios")
                        .HasForeignKey("HistoriaClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HistoriaClinica", b =>
                {
                    b.HasOne("Paciente", "Paciente")
                        .WithOne("HistoriaClinica")
                        .HasForeignKey("HistoriaClinica", "PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Nota", b =>
                {
                    b.HasOne("Episodio", null)
                        .WithMany("Notas")
                        .HasForeignKey("EpisodioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Episodio", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("HistoriaClinica", b =>
                {
                    b.Navigation("Episodios");
                });

            modelBuilder.Entity("Paciente", b =>
                {
                    b.Navigation("HistoriaClinica");
                });
#pragma warning restore 612, 618
        }
    }
}
