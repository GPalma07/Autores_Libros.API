using Autores_Libros.DaraAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autores_Libros.Application.AutoresAPP
{
    public class AutoresAPP : IAutoresAPP
    {
        private readonly AutoresLibrosContext _context;
        public AutoresAPP(AutoresLibrosContext context)
        {
            _context = context;
        }

        public async Task<ApiRespuesta<bool>> ActualizarAutorAPP(Autore autore)
        {
            ApiRespuesta<bool> respuesta = new();
            try
            {
                Autore autor = await _context.Autores.FindAsync(autore.IdAutor);

                if (autor is null)
                {
                    respuesta.Mensaje = "Autor no existe";
                    respuesta.StatusCode = HttpStatusCode.BadRequest;
                    respuesta.Model = false;
                    return respuesta;
                }

                autor.PrimerNombre = autore.PrimerNombre;
                autor.SegundoNombre = autore.SegundoNombre;
                autor.PrimerApellido = autore.PrimerApellido;
                autor.SegundoApellido = autore.SegundoApellido;
                autor.CiudadNacimiento = autore.CiudadNacimiento;
                autor.FechaNacimiento = autore.FechaNacimiento;
                autor.Correo = autore.Correo;
                _context.Entry(autor).State = EntityState.Modified;

                if (await _context.SaveChangesAsync() > 0)
                {
                    respuesta.Mensaje = "Autor actualizado";
                    respuesta.StatusCode = HttpStatusCode.OK;
                    respuesta.Model = true;
                }
                else
                {
                    respuesta.Mensaje = "Autor no actualizado";
                    respuesta.StatusCode = HttpStatusCode.InternalServerError;
                    respuesta.Model = false;
                }
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Autor no actualizado {e.Message} - {e.InnerException?.Message}";
                respuesta.StatusCode = HttpStatusCode.InternalServerError;
                respuesta.Model = false;
            }

            return respuesta;
        }

        public async Task<ApiRespuesta<bool>> AdicionarAutorAPP(Autore autore)
        {
            ApiRespuesta<bool> respuesta = new();

            try
            {
                await _context.Autores.AddAsync(autore);

                if (await _context.SaveChangesAsync() > 0)
                {
                    respuesta.Mensaje = "Autor creado";
                    respuesta.StatusCode = HttpStatusCode.OK;
                    respuesta.Model = true;
                }
                else
                {
                    respuesta.Mensaje = "Autor no creado";
                    respuesta.StatusCode = HttpStatusCode.InternalServerError;
                    respuesta.Model = false;
                }
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Autor no creado {e.Message} - {e.InnerException?.Message}";
                respuesta.StatusCode = HttpStatusCode.InternalServerError;
                respuesta.Model = false;
            }

            return respuesta;
        }

        public async Task<ApiRespuesta<IEnumerable<Autore>>> ObtenerAutoresAPP()
        {
            ApiRespuesta<IEnumerable<Autore>> respuesta = new();

            try
            {
                var listaAutores = _context.Autores.ToList();

                if (listaAutores.Count > 0)
                {
                    respuesta.Model = listaAutores;
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
