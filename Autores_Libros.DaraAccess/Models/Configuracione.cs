using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autores_Libros.DaraAccess.Models
{
    public partial class Configuracione
    {
        [Required(ErrorMessage = "Campo es requerido")]
        public int IdConfig { get; set; }

        [Required(ErrorMessage = "Campo es requerido")]
        public string NombreConfiguracion { get; set; } = null!;
        public string? DescripcionConfiguracion { get; set; }

        [Required(ErrorMessage = "Campo es requerido")]
        public string ValorConfiguracion { get; set; } = null!;
    }
}
