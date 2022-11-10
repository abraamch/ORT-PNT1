using Microsoft.EntityFrameworkCore;
namespace _2022_2C_I__HistoriasClinicas_.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Options;






    public class HistoriasClinicasContext : DbContext
    {
        public HistoriasClinicasContext(DbContextOptions<HistoriasClinicasContext> options)
       : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\Servidor;Database=HistoriaClinica2");






        }
       
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
    public DbSet<Episodio> Episodios { get; set; }
    public DbSet<Nota> Notas { get; set; }
    public DbSet<HistoriaClinica> HistoriaClinica { get; set; }
}

