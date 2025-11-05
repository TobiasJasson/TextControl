using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Login(string username, string password);
        Usuario RecuperarClave(string userName);
        void SaveRecoveryToken(string username, string token, DateTime expiry);
        bool CambiarClave(string username, string nuevaClave);
    }
}
