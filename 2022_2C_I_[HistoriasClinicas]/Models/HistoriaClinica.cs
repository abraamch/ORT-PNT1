using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class HistoriaClinica
{
    [Required]
    [Key]
    public int HistoriaClinicaId { get; set; }
    [Required]
    public int PacienteId { get; set; }
    public Paciente Paciente { get; set; }
    public List<Episodio> Episodios { get; set; }

    public HistoriaClinica() {
        Episodios = new List<Episodio>();
        
    }
}

