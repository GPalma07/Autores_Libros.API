using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autores_Libros.DaraAccess.Models
{
    public partial class Libro
    {
        [Required(ErrorMessage = "Campo es requerido")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "Campo es requerido")]
        public int Año { get; set; }

        [Required(ErrorMessage = "Campo es requerido")]
        public string Género { get; set; } = null!;

        public int NumeroPaginas { get; set; }

        [Required(ErrorMessage = "Campo es requerido")]
        public int IdAutor { get; set; }

        //public virtual Autore IdAutorNavigation { get; set; } = null!;
    }
}
