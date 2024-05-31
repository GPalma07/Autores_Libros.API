using Autores_Libros.Application.LibrosAPP;
using Autores_Libros.DaraAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autores_Libros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibrosAPP _libro;
        public LibrosController(ILibrosAPP libros)
        {
            _libro = libros;
        }


        /// <summary>
        /// Obtiene listado de libros guardados
        /// </summary>
        /// <returns></returns>
        [HttpGet("/v1/Libros")]
        public async Task<ApiRespuesta<IEnumerable<Libro>>> ObtenerLibros() => await _libro.ObtenerLibrosAPP();

        /// <summary>
        /// Adiciona un nuevo libro
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        [HttpPost("/v1/AdicionarLibro")]
        public async Task<ApiRespuesta<bool>> CrearLibro(Libro libro) => await _libro.AdicionarLibroAPP(libro);


        /// <summary>
        /// Actualiza un libro previamente guardado
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        [HttpPut("/v1/ActualizarLibro")]
        public async Task<ApiRespuesta<bool>> ActualizarLibro(Libro libro) => await _libro.ActualizarLibroAPP(libro);
    }
}
