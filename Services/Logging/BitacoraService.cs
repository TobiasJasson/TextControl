using DomainModel;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logging
{
    public class BitacoraService
    {
        private readonly BitacoraDAO _dao = new BitacoraDAO();

        public void Registrar(string accion, string entidad, string entidadId, string descripcion)
        {
            var usuario = SessionManager.Instance.UsuarioActual;

            var entry = new BitacoraEntry
            {
                IdUsuario = usuario?.IdUsuario,
                UserName = usuario?.UserName,
                Accion = accion,
                Entidad = entidad,
                EntidadId = entidadId,
                Descripcion = descripcion
            };

            _dao.Registrar(entry);
        }
    }
}
