using System.ComponentModel.DataAnnotations;

namespace Miwebapi.Models
{
    public class Usuario
    {
        [Key]
        public required string Cedula { get; set; }  // Esto establece Cedula como la clave primaria
        public required string Nombre { get; set; }        
        public required string Correo { get; set; }        
        public required string Contraseña { get; set; }   
        public int Edad { get; set; }                       
        public bool Estado { get; set; }                    
    }
}
