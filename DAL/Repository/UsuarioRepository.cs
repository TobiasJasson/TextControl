using DomainModel;
using Services.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UsuarioRepository
    {
        private readonly ConexionLogin _conexion;

        public UsuarioRepository()
        {
            _conexion = new ConexionLogin();
        }

        public DataTable ObtenerUsuarios()
        {
            using (var con = _conexion.GetConnection()) 
            {
                con.Open();
                var query = "SELECT * FROM vw_UsuariosSimple";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public int CrearEmpleadoYUsuario(Empleado emp, Usuario usu, int idRol)
        {
            using (var conSeg = _conexion.GetConnection())
            {
                conSeg.Open();

                SqlTransaction txSeg = conSeg.BeginTransaction();

                try
                {
                    string q1 = @"INSERT INTO Empleado (Nombre, Apellido, DNI, NumeroContacto, Email, ID_Rol)
                          VALUES (@n, @a, @dni, @num, @mail, @rol);
                          SELECT SCOPE_IDENTITY();";

                    var c1 = new SqlCommand(q1, conSeg, txSeg);
                    c1.Parameters.AddWithValue("@n", emp.Nombre);
                    c1.Parameters.AddWithValue("@a", emp.Apellido);
                    c1.Parameters.AddWithValue("@dni", emp.DNI);
                    c1.Parameters.AddWithValue("@num", emp.Contacto);
                    c1.Parameters.AddWithValue("@mail", emp.Gmail);
                    c1.Parameters.AddWithValue("@rol", idRol);

                    int idEmpleadoSeg = Convert.ToInt32(c1.ExecuteScalar());

                    string q2 = @"INSERT INTO Usuario (UserName, PasswordHash, Email, ID_Empleado, Activo)
                          VALUES (@u, @p, @e, @idEmp, @ac);
                          SELECT SCOPE_IDENTITY();";

                    var c2 = new SqlCommand(q2, conSeg, txSeg);
                    c2.Parameters.AddWithValue("@u", usu.UserName);
                    c2.Parameters.AddWithValue("@p", usu.Password);
                    c2.Parameters.AddWithValue("@e", usu.EmailRecuperacion);
                    c2.Parameters.AddWithValue("@idEmp", idEmpleadoSeg);
                    c2.Parameters.AddWithValue("@ac", usu.Activo);

                    int idUsuario = Convert.ToInt32(c2.ExecuteScalar());

                    string q3 = @"INSERT INTO UsuarioFamilia (ID_Usuario, ID_Familia)
                          VALUES (@u, @f)";

                    var c3 = new SqlCommand(q3, conSeg, txSeg);
                    c3.Parameters.AddWithValue("@u", idUsuario);
                    c3.Parameters.AddWithValue("@f", idRol);
                    c3.ExecuteNonQuery();

                    txSeg.Commit();

                    return idUsuario;
                }
                catch
                {
                    txSeg.Rollback();
                    throw;
                }
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            using (var con = _conexion.GetConnection())
            {
                con.Open();

                string q1 = "SELECT ID_Empleado FROM Usuario WHERE ID_Usuario = @id";
                var cmd1 = new SqlCommand(q1, con);
                cmd1.Parameters.AddWithValue("@id", idUsuario);

                var idEmpleadoObj = cmd1.ExecuteScalar();
                if (idEmpleadoObj == null)
                    return false;

                int idEmpleado = Convert.ToInt32(idEmpleadoObj);

                var transaction = con.BeginTransaction();

                try
                {
                    string qUsu = "DELETE FROM Usuario WHERE ID_Usuario = @idUsuario";
                    var cmdUsu = new SqlCommand(qUsu, con, transaction);
                    cmdUsu.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmdUsu.ExecuteNonQuery();

                    string qEmp = "DELETE FROM Empleado WHERE ID_Empleado = @idEmpleado";
                    var cmdEmp = new SqlCommand(qEmp, con, transaction);
                    cmdEmp.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    cmdEmp.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void ActualizarEmpleadoYUsuario(Empleado emp, Usuario usu, int idRol)
        {
            using (var con = _conexion.GetConnection())
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();

                try
                {
                    string q1 = @"UPDATE Empleado
                          SET Nombre=@n, Apellido=@a, DNI=@dni,
                              NumeroContacto=@num, Email=@mail
                          WHERE ID_Empleado=@id";

                    var c1 = new SqlCommand(q1, con, tx);
                    c1.Parameters.AddWithValue("@n", emp.Nombre);
                    c1.Parameters.AddWithValue("@a", emp.Apellido);
                    c1.Parameters.AddWithValue("@dni", emp.DNI);
                    c1.Parameters.AddWithValue("@num", emp.Contacto);
                    c1.Parameters.AddWithValue("@mail", emp.Gmail);
                    c1.Parameters.AddWithValue("@id", emp.IdEmpleado);
                    c1.ExecuteNonQuery();

                    string q2 = @"UPDATE Usuario
                          SET Email=@mailUsu, Activo=@ac
                          WHERE ID_Usuario=@idUsu";

                    var c2 = new SqlCommand(q2, con, tx);
                    c2.Parameters.AddWithValue("@mailUsu", usu.EmailRecuperacion);
                    c2.Parameters.AddWithValue("@ac", usu.Activo);
                    c2.Parameters.AddWithValue("@idUsu", usu.IdUsuario);
                    c2.ExecuteNonQuery();

                    string q3 = @"UPDATE UsuarioFamilia
                          SET ID_Familia = @idRol
                          WHERE ID_Usuario = @idUsu";

                    var c3 = new SqlCommand(q3, con, tx);
                    c3.Parameters.AddWithValue("@idRol", idRol);
                    c3.Parameters.AddWithValue("@idUsu", usu.IdUsuario);
                    c3.ExecuteNonQuery();

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }
    }
}