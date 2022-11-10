using System;
using System.ComponentModel.DataAnnotations;

public class Episodio
{
    [Required]
    [Key]
    public int EpisodioId { get; set; }
    public int HistoriaClinicaId { get; set; }
    [Required]
    public String? Motivo { get; set; }
    [Required]
    public String? Descripcion { get; set; }
    public DateTime FechaYHoraInicio { get; set; }
    public DateTime FechaYHoraAlta { get; set; }
    public DateTime FechaYHoraCierre { get; set; }
    public bool EstadoAbierto { get; set; }
    public String? DescripcionAtencion { get; set; }
    
    public List<Nota>? Notas { get; set; }

    public Episodio() {
        FechaYHoraInicio = DateTime.Now;
        FechaYHoraCierre = DateTime.MaxValue;
        FechaYHoraAlta = DateTime.Now;
        EstadoAbierto = true;
    }

}
