using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logging
{
    public static class LoggerAdapter
    {
        private static readonly BitacoraService service = new BitacoraService();

        public static void RegistrarCreate(string entidad, string entidadId, string descripcion)
            => service.Registrar("CREATE", entidad, entidadId, descripcion);

        public static void RegistrarUpdate(string entidad, string entidadId, string descripcion)
            => service.Registrar("UPDATE", entidad, entidadId, descripcion);

        public static void RegistrarDelete(string entidad, string entidadId, string descripcion)
            => service.Registrar("DELETE", entidad, entidadId, descripcion);

        public static void RegistrarInfo(string entidad, string descripcion)
            => service.Registrar("INFO", entidad, null, descripcion);
    }
}
