using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2022_2C_I__HistoriasClinicas_.Migrations
{
    public partial class _2022_2C_I__HistoriasClinicas_ContextM2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "Pacientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "apellido",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "direccion",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "dni",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nombreDeUsuario",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "telefono",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "Medicos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "apellido",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "direccion",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "dni",
                table: "Medicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nombreDeUsuario",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "telefono",
                table: "Medicos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "apellido",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "direccion",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "dni",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "nombreDeUsuario",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "telefono",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "apellido",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "direccion",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "dni",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "nombreDeUsuario",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "telefono",
                table: "Medicos");
        }
    }
}
