using Autores_Libros.DaraAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autores_Libros.Application.Configuraciones
{
    public interface IConfig
    {
        public Task<ApiRespuesta<IEnumerable<Configuracione>>> ObtenerConfiguracionesAPP();
        public Task<ApiRespuesta<bool>> CrearConfiguracionAPP(Configuracione configuracione);
        public Task<ApiRespuesta<bool>> ActualizarConfiguracionAPP(Configuracione configuracione);

    }
}
