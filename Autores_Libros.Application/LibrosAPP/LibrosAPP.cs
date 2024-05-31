using Autores_Libros.DaraAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autores_Libros.Application.LibrosAPP
{
    public class LibrosAPP : ILibrosAPP
    {
        private readonly AutoresLibrosContext _context;
        public LibrosAPP(AutoresLibrosContext context)
        {
            _context = context;
        }

        public async Task<ApiRespuesta<bool>> ActualizarLibroAPP(Libro libro)
        {
            ApiRespuesta<bool> respuesta = new();

            try
            {
                #region Valida autor
                Autore autor = await _context.Autores.FindAsync(libro.IdAutor);
                if (autor is null)
                {
                    respuesta.Model = false;
                    respuesta.Mensaje = "El autor no está registrado";
                    respuesta.StatusCode = HttpStatusCode.Conflict;
                    return respuesta;
                }
                #endregion

                #region Valida libro
                Libro libroSeleccionado = await _context.Libros.FindAsync(libro.Titulo);

                if (libroSeleccionado is null)
                {
                    respuesta.Mensaje = "Libro no existe";
                    respuesta.StatusCode = HttpStatusCode.BadRequest;
                    respuesta.Model = false;
                    return respuesta;
                }
                #endregion

                libroSeleccionado.Año = libro.Año;
                libroSeleccionado.IdAutor = libro.IdAutor;
                libroSeleccionado.NumeroPaginas = libro.NumeroPaginas;
                libroSeleccionado.Género = libro.Género;
                _context.Entry(libroSeleccionado).State = EntityState.Modified;

                if (await _context.SaveChangesAsync() > 0)
                {
                    respuesta.Mensaje = "Libro actualizado";
                    respuesta.StatusCode = HttpStatusCode.OK;
                    respuesta.Model = true;
                }
                else
                {
                    respuesta.Mensaje = "Libro no actualizado";
                    respuesta.StatusCode = HttpStatusCode.InternalServerError;
                    respuesta.Model = false;
                }

            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Libro no actualizado {e.Message} - {e.InnerException?.Message}";
                respuesta.StatusCode = HttpStatusCode.InternalServerError;
                respuesta.Model = false;
            }

            return respuesta;
        }

        public async Task<ApiRespuesta<bool>> AdicionarLibroAPP(Libro libro)
        {
            ApiRespuesta<bool> respuesta = new();

            try
            {
                #region Valida máximo de ingresos
                Configuracione configuracion = await _context.Configuraciones.FindAsync(1);
                if (configuracion is not null)
                {
                    if (Convert.ToInt32(configuracion.ValorConfiguracion) < (await _context.Libros.CountAsync() + 1))
                    {
                        respuesta.Mensaje = $"No es posible registrar el libro, se alcanzó el máximo permitido {configuracion.ValorConfiguracion}.";
                        respuesta.StatusCode = HttpStatusCode.Conflict;
                        respuesta.Model = false;

                        return respuesta;
                    }
                }
                #endregion

                #region Valida autor
                Autore autor = await _context.Autores.FindAsync(libro.IdAutor);
                if (autor is null)
                {
                    respuesta.Model = false;
                    respuesta.Mensaje = "El autor no está registrado";
                    respuesta.StatusCode = HttpStatusCode.Conflict;
                    return respuesta;
                }
                #endregion

                await _context.Libros.AddAsync(libro);
                if (await _context.SaveChangesAsync() > 0)
                {
                    respuesta.Mensaje = "Libro creado";
                    respuesta.StatusCode = HttpStatusCode.OK;
                    respuesta.Model = true;
                }
                else
                {
                    respuesta.Mensaje = "Libro no creado";
                    respuesta.StatusCode = HttpStatusCode.InternalServerError;
                    respuesta.Model = false;
                }
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Libro no creado {e.Message} - {e.InnerException?.Message}";
                respuesta.StatusCode = HttpStatusCode.InternalServerError;
                respuesta.Model = false;
            }

            return respuesta;
        }

        public async Task<ApiRespuesta<IEnumerable<Libro>>> ObtenerLibrosAPP()
        {
            ApiRespuesta<IEnumerable<Libro>> respuesta = new();

            try
            {
                var listaLibros = _context.Libros.ToList();

                if (listaLibros.Count > 0)
                {
                    respuesta.Model = listaLibros;
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
