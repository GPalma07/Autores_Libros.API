using Autores_Libros.Application.AutoresAPP;
using Autores_Libros.DaraAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autores_Libros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        IAutoresAPP _autoresApp { get; set; }
        public AutoresController(IAutoresAPP autores)
        {
            _autoresApp = autores;
        }


        /// <summary>
        /// Obtiene listado de autores
        /// </summary>
        /// <returns></returns>
        [HttpGet("/v1/Autores")]
        public async Task<ApiRespuesta<IEnumerable<Autore>>> Autores() => await _autoresApp.ObtenerAutoresAPP();


        /// <summary>
        /// Adiciona un nuevo autor
        /// </summary>
        /// <param name="autore"></param>
        /// <returns></returns>
        [HttpPost("/v1/AdicionarAutor")]
        public async Task<ApiRespuesta<bool>> CrearAutor(Autore autore) => await _autoresApp.AdicionarAutorAPP(autore);


        /// <summary>
        /// Actualiza un autor previamente guardado
        /// </summary>
        /// <param name="autore"></param>
        /// <returns></returns>
        [HttpPut("/v1/ActualizarAutor")]
        public async Task<ApiRespuesta<bool>> ActualizarAutor(Autore autore) => await _autoresApp.ActualizarAutorAPP(autore);
    }
}
