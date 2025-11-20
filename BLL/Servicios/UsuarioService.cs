using BLL.Interfaces;
using BLL.Servicios;
using DAL.Repository;
using DomainModel;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly UsuarioRepository _repo2;

        public UsuarioService() : this(new UsuarioRepositorySeguridad()) {  }

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
            _repo2 = new UsuarioRepository();
        }

        public Usuario Login(string username, string password)
        {
            string passwordEnBase64 = PasswordHelper.ConvertirABase64(password);
            return _repo.GetByUserAndPassword(username, passwordEnBase64);
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
                rng.GetBytes(bytes);

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

        public bool CambiarNameUser(string username, int idUser)
        {
            return _repo.ActualizarNameUser(username, idUser);
        }
        public DataTable ObtenerGrid()
        {
            return _repo2.ObtenerUsuarios();
        }

        public int CrearEmpleado(Empleado emp, Usuario usu, int rol)
        {
            return _repo2.CrearEmpleadoYUsuario(emp, usu, rol);
        }
        public void Eliminar(int idUsuario)
        {
            _repo2.EliminarUsuario(idUsuario);
        }

        public void ActualizarEmpleado(int idUsuario, Empleado emp, int idRol, bool activo, Usuario usuario)
        {
            var dt = _repo2.ObtenerUsuarios();
            var row = dt.AsEnumerable().FirstOrDefault(r =>
                r.Field<int>("ID_Usuario") == idUsuario);

            if (row == null)
            {
                _repo2.CrearEmpleadoYUsuario(emp, usuario, idRol);
                return;
            }

            int idEmpleado = row.Field<int>("ID_Empleado");
            emp.IdEmpleado = idEmpleado;

            var usu = new Usuario
            {
                IdUsuario = idUsuario,
                EmailRecuperacion = emp.Gmail,
                Activo = activo
            };

            _repo2.ActualizarEmpleadoYUsuario(emp, usu, idRol);
        }
    }
}