 using System;
using System.ComponentModel.DataAnnotations;

public class Paciente : Usuario
{
    [Required]
    [Key]
    public int PacienteId { get; set; }
    /* Ya estan en Persona: 
     * 
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string DNI { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public dateTime FechaAlta { get; set; }
    public string Email { get; set; }
    */
    public string ObraSocial { get; set; }

     
    public HistoriaClinica? HistoriaClinica { get; set; }
    
    
        //= new List<Episodio>(); Para crear la lista.

  
}
