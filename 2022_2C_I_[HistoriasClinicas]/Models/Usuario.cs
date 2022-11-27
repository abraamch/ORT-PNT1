using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


[Index(nameof(email), IsUnique = true)]
public class Usuario

{
   
    public string nombreDeUsuario { get; set; }
    [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "ingrese un correo electronico valido.")]
    public string email { get; set; }
    public DateTime FechaAlta { get; set; }
    [PasswordPropertyText]
    [Required]
    public string password { get; set; }
    [Required]
    public string apellido { get; set; }
    [Required]
    public int dni { get; set; }
    
    public int telefono { get; set; }
    
    public string direccion { get; set; }
   
}
public static class UsuarioLog {
    public static Usuario? UsuarioLogueado { get; set; }
    public static int? UsuarioLogueadoId { get; set; }
    public static int? HCId { get; set; }
}
