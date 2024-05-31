using Autores_Libros.DaraAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autores_Libros.Application.LibrosAPP
{
    public interface ILibrosAPP
    {
        public Task<ApiRespuesta<IEnumerable<Libro>>> ObtenerLibrosAPP();
        public Task<ApiRespuesta<bool>> AdicionarLibroAPP(Libro libro);
        public Task<ApiRespuesta<bool>> ActualizarLibroAPP(Libro libro);
    }
}
