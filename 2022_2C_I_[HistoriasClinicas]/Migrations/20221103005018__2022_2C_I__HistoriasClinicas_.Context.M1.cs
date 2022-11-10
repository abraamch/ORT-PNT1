using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2022_2C_I__HistoriasClinicas_.Migrations
{
    public partial class _2022_2C_I__HistoriasClinicas_ContextM1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraSocial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                });

            migrationBuilder.CreateTable(
                name: "HistoriaClinica",
                columns: table => new
                {
                    HistoriaClinicaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaClinica", x => x.HistoriaClinicaId);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodios",
                columns: table => new
                {
                    EpisodioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoriaClinicaId = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaYHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaYHoraAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaYHoraCierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoAbierto = table.Column<bool>(type: "bit", nullable: false),
                    DescripcionAtencion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodios", x => x.EpisodioId);
                    table.ForeignKey(
                        name: "FK_Episodios_HistoriaClinica_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "HistoriaClinica",
                        principalColumn: "HistoriaClinicaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodioId = table.Column<int>(type: "int", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaYHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.NotaId);
                    table.ForeignKey(
                        name: "FK_Notas_Episodios_EpisodioId",
                        column: x => x.EpisodioId,
                        principalTable: "Episodios",
                        principalColumn: "EpisodioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodios_HistoriaClinicaId",
                table: "Episodios",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_PacienteId",
                table: "HistoriaClinica",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_EpisodioId",
                table: "Notas",
                column: "EpisodioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Episodios");

            migrationBuilder.DropTable(
                name: "HistoriaClinica");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
