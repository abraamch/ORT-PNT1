using System;
using System.ComponentModel.DataAnnotations;

public class Nota
{
    [Required]
    [Key]
    public int NotaId { get; set; }
    public int EpisodioId { get; set; } 
	public string Mensaje  { get; set; }
	public DateTime FechaYHora { get; set; }

}
