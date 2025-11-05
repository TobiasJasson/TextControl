using BLL.Interfaces;
using BLL.Servicios;
using DAL.Repository;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public UsuarioService() : this(new UsuarioRepository())
        {
        }

        public Usuario Login(string username, string password)
        {
            string passwordEnBase64 = PasswordHelper.ConvertirABase64(password);
            var user = _repo.GetByUserAndPassword(username, passwordEnBase64);
            return user;
        }

        public Usuario RecuperarClave(string userName)
        {
            return _repo.GetByName(userName);
        }

        public void SaveRecoveryToken(string username, string token, DateTime expiry)
        {
            _repo.SaveRecoveryToken(username, token, expiry);
        }

        public static string GenerateToken(int length = 32)
        {
            byte[] bytes = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes)
                          .Replace("+", "")
                          .Replace("/", "")
                          .Replace("=", "");
        }

        public bool CambiarClave(string username, string nuevaClave)
        {
            string passwordBase64 = PasswordHelper.ConvertirABase64(nuevaClave);
            return _repo.ActualizarClave(username, passwordBase64);
        }
    }
}