using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2022_2C_I__HistoriasClinicas_.Migrations
{
    public partial class Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HCId",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HCId",
                table: "Pacientes");
        }
    }
}
