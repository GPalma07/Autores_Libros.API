using Autores_Libros.Application.Configuraciones;
using Autores_Libros.DaraAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autores_Libros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionesController : ControllerBase
    {
        private readonly IConfig _config;
        public ConfiguracionesController(IConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Obtiene lista de configuraciones
        /// </summary>
        /// <returns></returns>
        [HttpGet("/v1/Configuraciones")]
        public async Task<ApiRespuesta<IEnumerable<Configuracione>>> ObtenerListaConfiguraciones() => await _config.ObtenerConfiguracionesAPP();

        /// <summary>
        /// Crea un nuevo registro de configuración
        /// </summary>
        /// <param name="configuracione"></param>
        /// <returns></returns>
        [HttpPost("/v1/Configuracion")]
        public async Task<ApiRespuesta<bool>> CrearConfiguracion(Configuracione configuracione) => await _config.CrearConfiguracionAPP(configuracione);

        /// <summary>
        /// Actualiza datos de una configuración
        /// </summary>
        /// <param name="configuracione"></param>
        /// <returns></returns>
        [HttpPut("/v1/Configuracion")]
        public async Task<ApiRespuesta<bool>> ActualizarConfiguracion(Configuracione configuracione) => await _config.ActualizarConfiguracionAPP(configuracione);
    }
}
