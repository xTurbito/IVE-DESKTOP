using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using MySql.Data.MySqlClient;
using static WindowsFormsApp1.UsuariosBD;


namespace WindowsFormsApp1
{
    internal class ProductoDB
    {
        string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        public bool OK()
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cnn))
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

        public List<Productos> Get()
        {
            List<Productos> productos = new List<Productos>();

            string query = "SELECT * FROM productos WHERE Stock > 0";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       Productos oProductos = new Productos();
                        oProductos.IDProducto = reader.GetInt32(0);
                        oProductos.Nombre = reader.GetString(1);    
                        oProductos.Descripcion = reader.GetString(2);
                        oProductos.Precio = reader.GetDecimal(3);
                        oProductos.Stock = reader.GetInt32(4);
                        oProductos.lActivo = reader.GetInt32(5);
                        productos.Add(oProductos);
                    
                    }
                    reader.Close();
                    conexion.Close();
                }
                catch(Exception ex) 
                {
                    throw new Exception("Hay un error en la bd" + ex.Message);
                }
            }

            return productos;
        }

        public Productos Get(int IDProducto)
        {

            string query = "SELECT IDProducto,Nombre,Descripcion,Precio,Stock,lActivo,fotoproducto FROM productos WHERE IDProducto = @id";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id", IDProducto);
                try 
                {
                    conexion.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                   if(reader.Read()) 
                    {

                        Productos oProductos = new Productos();
                        oProductos.IDProducto = reader.GetInt32(0);
                        oProductos.Nombre = reader.GetString(1);
                        oProductos.Descripcion = reader.GetString(2);
                        oProductos.Precio = reader.GetDecimal(3);
                        oProductos.Stock = reader.GetInt32(4);
                        oProductos.lActivo = reader.GetInt32(5);

                        // Verificamos si hay datos de imagen disponibles en la base de datos
                        if (!reader.IsDBNull(6))
                        {
                            string base64Image = reader.GetString(6);
                            oProductos.fotoproducto = base64Image; // Asignamos la cadena Base64 directamente
                        }

                        reader.Close();
                        conexion.Close();
                        return oProductos;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }  
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd" + ex.Message);
                }
            }

         
        }

        public void Add(string Nombre, string Descripcion, string Precio, int Stock, int lActivo, string fotoproducto)
        {
            string query = "INSERT into productos(Nombre, Descripcion, Precio, Stock, lActivo, fotoproducto) values" +
                           "(@nombre, @descripcion, @precio, @stock, @lactivo, @fotoproducto)";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@precio", Precio);
                command.Parameters.AddWithValue("@stock", Stock);
                command.Parameters.AddWithValue("@lactivo", lActivo);

                byte[] fotoproductoBytes = Convert.FromBase64String(fotoproducto);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                    {
                        gZipStream.Write(fotoproductoBytes, 0, fotoproductoBytes.Length);
                    } // Se cierra aquí el GZipStream, pero no se cierra el memoryStream

                    string base64Image = Convert.ToBase64String(memoryStream.ToArray());
                    command.Parameters.AddWithValue("@fotoproducto", base64Image);
                }


                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();

                    conexion.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd" + ex.Message);
                }
            }
        }

        public void Update(string Nombre, string Descripcion, string Precio, int Stock, int lActivo,string fotoproducto, int IDProducto)
        {
            string query;
            if (!string.IsNullOrEmpty(fotoproducto))
            {
                query = "UPDATE productos SET Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Stock = @stock, lActivo = @lactivo, fotoproducto = @fotoproducto WHERE IDProducto = @id";
            }
            else
            {
                query = "UPDATE productos SET Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Stock = @stock, lActivo = @lactivo WHERE IDProducto = @id";
            }

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@precio", Precio);
                command.Parameters.AddWithValue("@stock", Stock);
                command.Parameters.AddWithValue("@lactivo", lActivo);
                command.Parameters.AddWithValue("@fotoproducto", fotoproducto);
                command.Parameters.AddWithValue("@id", IDProducto);

               

                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd: " + ex.Message);
                }
            }
        }

        public void Delete(int IDProducto)
        {
            string query = "DELETE FROM productos WHERE IDProducto = @id ";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id", IDProducto);

                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd: " + ex.Message);
                }
            }
        }


    }

    public class Productos
    {
        public int IDProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int lActivo { get; set; }

        public string fotoproducto { get; set; }

    }
}

            

          
    
  


