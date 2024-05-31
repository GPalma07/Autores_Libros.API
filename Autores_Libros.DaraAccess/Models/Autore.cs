using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autores_Libros.DaraAccess.Models
{
    public partial class Autore
    {
     
        [Required(ErrorMessage = "Campo es requerido")]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "Campo es requerido")]
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "Campo es requerido")]
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "Campo es requerido")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo es requerido")]
        public string CiudadNacimiento { get; set; } = null!;
        public string? Correo { get; set; }

    }
}
