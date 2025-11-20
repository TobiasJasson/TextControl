using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUsuarioRepository
    {
        Usuario GetByUserAndPassword(string username, string passwordBase64);
        Usuario GetByName(string userName);
        bool ActualizarClave(string username, string nuevaClaveBase64);

        bool ActualizarNameUser(string username, int idUser);
        void SaveRecoveryToken(string username, string token, DateTime expiry);
    }
}
