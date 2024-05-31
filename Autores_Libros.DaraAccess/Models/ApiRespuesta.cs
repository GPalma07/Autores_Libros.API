using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autores_Libros.DaraAccess.Models
{
    public class ApiRespuesta<T>
    {
        public T Model { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Mensaje { get; set; }
    }
}
