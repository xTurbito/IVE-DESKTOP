using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    internal class UsuariosBD
    {
        string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        public bool OK()
        {
            try
            {
                using(MySqlConnection conexion = new MySqlConnection(cnn))
                {
                    conexion.Open();
                }
            }
            catch 
            {
                return false;
            
            }
            return true;
        }

        public List<Usuarios> Get()
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            string query = "SELECT idusuario, usuario, password, nombre, tipo_usuclave, lactivo FROM usuarios";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            using (MySqlCommand command = new MySqlCommand(query, conexion))
            {
                try
                {
                    conexion.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuarios oUsuarios = new Usuarios();
                            oUsuarios.idusuario = reader.GetInt32(0);
                            oUsuarios.usuario = reader.GetString(1);
                            oUsuarios.password = reader.GetString(2);
                            oUsuarios.nombre = reader.GetString(3);
                            oUsuarios.tipo_usuclave = reader.GetInt32(4);
                            oUsuarios.lactivo = reader.GetInt32(5);
                            usuarios.Add(oUsuarios);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Hubo un error en la base de datos: " + ex.Message);
                }
            }
            return usuarios;
        }


        public Usuarios Get(int idUsuario)
        {
            string query = "SELECT idusuario,usuario, nombre, password, tipo_usuclave, lactivo FROM usuarios WHERE idusuario = @id";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            using (MySqlCommand command = new MySqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@id", idUsuario);

                try
                {
                    conexion.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                       if(reader.Read())
                        {
                            Usuarios oUsuarios = new Usuarios
                            {
                                idusuario = reader.GetInt32(0),
                                usuario = reader.GetString(1),
                                password = reader.GetString(2),
                                nombre = reader.GetString(3),
                                tipo_usuclave = reader.GetInt32(4),
                                lactivo = reader.GetInt32(5)    
                            };
                            return oUsuarios;
                        }

                    }

                    return null; // Si no se encuentra ningún usuario con ese id.
                }
                catch (Exception ex)
                {
                    throw new Exception("Hubo un error en la base de datos: " + ex.Message);
                }
            }
        }


        public void Add(string usuario, string nombre, string password, int tipo_usuclave, int lactivo)
        {
            string query = "INSERT INTO usuarios (usuario, nombre, password, tipo_usuclave, lactivo) VALUES (@usuario, @nombre, @password, @tipo_usuclave, @lactivo)";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            using (MySqlCommand command = new MySqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@tipo_usuclave", tipo_usuclave);
                command.Parameters.AddWithValue("@lactivo", lactivo);

                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hubo un error en la base de datos: " + ex.Message);
                }
            }
        }

        public void Update(string usuario, string nombre, string password, int tipo_usuclave, int lactivo, int idUsuario)
        {
            string query = "UPDATE usuarios SET usuario = @usuario, nombre = @nombre, password = @password, tipo_usuclave = @tipo_usuclave, lactivo = @lactivo WHERE idusuario = @id";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            using (MySqlCommand command = new MySqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@tipo_usuclave", tipo_usuclave);
                command.Parameters.AddWithValue("@lactivo", lactivo);
                command.Parameters.AddWithValue("@id", idUsuario);

                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hubo un error en la base de datos: " + ex.Message);
                }
            }
        }

        public void Delete(int idUsuario) 
        {
            string query = "DELETE  FROM usuarios WHERE idUsuario = @id";
            
            using(MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id", idUsuario);
                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex) 
                {
                    throw new Exception("Hubo un error en la base de datos: " + ex.Message);
                }
            }
        
        }

    }


    public class Usuarios
    {
        public int idusuario {  get; set; }

        public string usuario { get; set; }

        public string password { get; set; }

        public string nombre { get; set; }

        public int tipo_usuclave {  get; set; }

        public int lactivo {  get; set; }
    }
}
