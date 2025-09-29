using DAL;
using DAL.ScriptsSQL;
using DomainModel;
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
    public class UsuarioService
    {
        private readonly UsuarioRepository _repo;

        public UsuarioService()
        {
            _repo = new UsuarioRepository();
        }

        public Usuario Login(string username, string password)
        {
            // Convertir la contraseña ingresada a Base64
            string passwordEnBase64 = Servicios.PasswordHelper.ConvertirABase64(password);

            // Buscar el usuario validando también la contraseña
            var user = _repo.GetByUserAndPassword(username, passwordEnBase64);
            if (user == null) return null;

            return user;
        }

        public Usuario RecuperarClave(string userName)
        {
            var user = _repo.GetByName(userName);
            if (user == null) return null;

            return user;
        }

        public void SaveRecoveryToken(string username, string token, DateTime expiry)
        {
            string sql = @"UPDATE dbo.Usuario
                   SET RecoveryToken = @token, RecoveryTokenExpiry = @expiry
                   WHERE UserName_Usuario = @username";

            // Usar la misma conexión dinámica que todo el sistema
            string connectionString = DAL.ScriptsSQL.DatabaseInitializer.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@expiry", expiry);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }
            }
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
    }
}
