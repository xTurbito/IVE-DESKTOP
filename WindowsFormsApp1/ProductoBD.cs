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
                        oProductos.IDProducto = reader.GetInt32("IDProducto");
                        oProductos.Nombre = reader.GetString(1);    
                        oProductos.Descripcion = reader.GetString(2);
                        oProductos.precio_venta = reader.GetDecimal(3);
                        oProductos.precio_costo = reader.GetDecimal(7);  
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
            string query = "SELECT IDProducto, Nombre, Descripcion,precio_venta,Stock, lActivo, precio_costo FROM productos WHERE IDProducto = @id";

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
                                IDProducto = reader.GetInt32("IDProducto"),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                precio_venta = reader.GetDecimal(3),
                                precio_costo = reader.GetDecimal(6),
                                Stock = reader.GetInt32(4),
                                lActivo = reader.GetInt32(5),
                                
                            };

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


        public void Add(string Nombre, string Descripcion, decimal precio_venta, int Stock, int lActivo, decimal precio_costo)
        {
            string query = "INSERT into productos(Nombre, Descripcion, precio_venta,precio_costo, Stock, lActivo) values" +
                           "(@nombre, @descripcion, @precio_venta, @stock, @lactivo,@precio_costo)";

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@precio_venta", precio_venta);
                command.Parameters.AddWithValue("@stock", Stock);
                command.Parameters.AddWithValue("@lactivo", lActivo);
                command.Parameters.AddWithValue("@precio_costo", precio_costo);

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

        public void Update(string Nombre, string Descripcion, decimal precio_venta, int Stock, int lActivo, int IDProducto, decimal precio_costo)
        {
            string query;
            query = "UPDATE productos SET Nombre = @nombre, Descripcion = @descripcion, precio_venta = @precio_venta, Stock = @stock,precio_costo = @precio_costo, lActivo = @lactivo WHERE IDProducto = @id";
            

            using (MySqlConnection conexion = new MySqlConnection(cnn))
            {
                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@precio_venta", precio_venta);
                command.Parameters.AddWithValue("@stock", Stock);
                command.Parameters.AddWithValue("@lactivo", lActivo);
                command.Parameters.AddWithValue("@precio_costo", precio_costo);

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
        public decimal precio_venta { get; set; }
        public decimal precio_costo {  get; set; }
        public int Stock { get; set; }
        public int lActivo { get; set; }
        public string idDepartamento { get; set; }

    }
}

            

          
    
  


