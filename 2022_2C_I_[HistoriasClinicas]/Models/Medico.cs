using System;
using System.ComponentModel.DataAnnotations;

public class Medico : Usuario
{
    [Required]
    [Key]
    public int MedicoId { get; set; }
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
    public string Matricula { get; set; }
    public string Especialidad { get; set; }
}
