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
using System.Drawing;
using System.Drawing.Imaging;
using static WindowsFormsApp1.UsuariosBD;


namespace WindowsFormsApp1
{
    internal class ProductoBD
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
                        oProductos.precio_cost = reader.GetDecimal(9);  
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
            string query = "SELECT IDProducto, Nombre, Descripcion,Precio,Stock, lActivo, fotoproducto, precio_cost FROM productos WHERE IDProducto = @id";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            using (MySqlCommand command = new MySqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@id", IDProducto);

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Productos oProductos = new Productos
                            {
                                IDProducto = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Precio = reader.GetDecimal(3),
                                precio_cost = reader.GetDecimal(7),
                                Stock = reader.GetInt32(4),
                                lActivo = reader.GetInt32(5),
                                
                            };

                          
                            if (!reader.IsDBNull(6))
                            {
                                // Leer la imagen como una cadena Base64
                                string base64Image = reader.GetString(6);

                                if (base64Image.StartsWith("data:image/jpeg;base64,"))
                                {
                                    // Eliminar el encabezado
                                    base64Image = base64Image.Substring("data:image/jpeg;base64,".Length);

                                    // Convertir la cadena Base64 en bytes
                                    byte[] imageBytes = Convert.FromBase64String(base64Image);

                                    // Asignar los bytes de la imagen convertidos a cadena Base64
                                    oProductos.fotoproducto = Convert.ToBase64String(imageBytes);
                                }
                                else
                                {
                                    // Si no hay encabezado, asignar la cadena Base64 directamente
                                    oProductos.fotoproducto = base64Image;
                                }
                            }

                            return oProductos;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Hubo un error en la base de datos: " + ex.Message);
                }
            }

           
            return null;
        }


        public void Add(string Nombre, string Descripcion, decimal Precio, int Stock, int lActivo, string fotoproducto, decimal precio_cost)
        {
            string query = "INSERT into productos(Nombre, Descripcion, Precio,precio_cost, Stock, lActivo, fotoproducto) values" +
                           "(@nombre, @descripcion, @precio, @stock, @lactivo, @fotoproducto,@precio_cost)";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@precio", Precio);
                command.Parameters.AddWithValue("@stock", Stock);
                command.Parameters.AddWithValue("@lactivo", lActivo);
                command.Parameters.AddWithValue("@precio_cost", precio_cost);

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

        public void Update(string Nombre, string Descripcion, decimal Precio, int Stock, int lActivo, string fotoproducto, int IDProducto, decimal precio_cost)
        {
            string query;
            if (!string.IsNullOrEmpty(fotoproducto))
            {
                // Agregar el encabezado si se proporciona una imagen
                fotoproducto = "data:image/jpeg;base64," + fotoproducto;
                query = "UPDATE productos SET Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Stock = @stock, lActivo = @lactivo, fotoproducto = @fotoproducto, precio_cost = @precio_cost WHERE IDProducto = @id";
            }
            else
            {
                // No incluir el campo fotoproducto si no se proporciona una imagen
                query = "UPDATE productos SET Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Stock = @stock,precio_cost = @precio_cost, lActivo = @lactivo WHERE IDProducto = @id";
            }

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@precio", Precio);
                command.Parameters.AddWithValue("@stock", Stock);
                command.Parameters.AddWithValue("@lactivo", lActivo);
                command.Parameters.AddWithValue("@precio_cost", precio_cost);
                // Solo se agrega el parámetro si se proporciona una imagen
                if (!string.IsNullOrEmpty(fotoproducto))
                {
                    command.Parameters.AddWithValue("@fotoproducto", fotoproducto);
                }
                command.Parameters.AddWithValue("@id", IDProducto);

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
        public decimal precio_cost {  get; set; }
        public int Stock { get; set; }
        public int lActivo { get; set; }

        public string fotoproducto { get; set; }

    }
}

            

          
    
  


