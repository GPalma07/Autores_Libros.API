using Autores_Libros.DaraAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autores_Libros.Application.Configuraciones
{
    public class Config : IConfig
    {
        private readonly AutoresLibrosContext _context;

        public Config(AutoresLibrosContext context)
        {
            _context = context;
        }

        public async Task<ApiRespuesta<bool>> ActualizarConfiguracionAPP(Configuracione configuracione)
        {
            ApiRespuesta<bool> respuesta = new();

            try
            {
                #region Valida configuración
                Configuracione configSeleccionada = await _context.Configuraciones.FindAsync(configuracione.IdConfig);

                if (configSeleccionada is null)
                {
                    respuesta.Mensaje = "Configuración no existe";
                    respuesta.StatusCode = HttpStatusCode.BadRequest;
                    respuesta.Model = false;
                    return respuesta;
                }
                #endregion

                configSeleccionada.DescripcionConfiguracion = configuracione.DescripcionConfiguracion;
                configSeleccionada.ValorConfiguracion = configuracione.ValorConfiguracion;
                configSeleccionada.NombreConfiguracion = configuracione.NombreConfiguracion;
                _context.Entry(configSeleccionada).State = EntityState.Modified;

                if (await _context.SaveChangesAsync() > 0)
                {
                    respuesta.Mensaje = "Configuración actualizada";
                    respuesta.StatusCode = HttpStatusCode.OK;
                    respuesta.Model = true;
                }
                else
                {
                    respuesta.Mensaje = "Configuración no actualizada";
                    respuesta.StatusCode = HttpStatusCode.InternalServerError;
                    respuesta.Model = false;
                }

            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Configuración no actualizada {e.Message} - {e.InnerException?.Message}";
                respuesta.StatusCode = HttpStatusCode.InternalServerError;
                respuesta.Model = false;
            }

            return respuesta;
        }

        public async Task<ApiRespuesta<bool>> CrearConfiguracionAPP(Configuracione configuracione)
        {
            ApiRespuesta<bool> respuesta = new();

            try
            {
                await _context.Configuraciones.AddAsync(configuracione);
                if (await _context.SaveChangesAsync() > 0)
                {
                    respuesta.Mensaje = "Configuración creada";
                    respuesta.StatusCode = HttpStatusCode.OK;
                    respuesta.Model = true;
                }
                else
                {
                    respuesta.Mensaje = "Configuración no creada";
                    respuesta.StatusCode = HttpStatusCode.InternalServerError;
                    respuesta.Model = false;
                }
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Configuración no creada {e.Message} - {e.InnerException?.Message}";
                respuesta.StatusCode = HttpStatusCode.InternalServerError;
                respuesta.Model = false;
            }

            return respuesta;
        }

        public async Task<ApiRespuesta<IEnumerable<Configuracione>>> ObtenerConfiguracionesAPP()
        {
            ApiRespuesta<IEnumerable<Configuracione>> respuesta = new();

            try
            {
                var listaConfiguraciones = _context.Configuraciones.ToList();

                if (listaConfiguraciones.Count > 0)
                {
                    respuesta.Model = listaConfiguraciones;
                    respuesta.Mensaje = "Listado cargado";
                    respuesta.StatusCode = HttpStatusCode.OK;
                }
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"{e.Message} - {e.InnerException?.Message}";
                respuesta.StatusCode = HttpStatusCode.InternalServerError;
            }

            return respuesta;
        }
    }
}
