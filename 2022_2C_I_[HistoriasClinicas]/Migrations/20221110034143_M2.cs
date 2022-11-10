using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2022_2C_I__HistoriasClinicas_.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Pacientes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Medicos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_email",
                table: "Pacientes",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_email",
                table: "Medicos",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pacientes_email",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_email",
                table: "Medicos");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
