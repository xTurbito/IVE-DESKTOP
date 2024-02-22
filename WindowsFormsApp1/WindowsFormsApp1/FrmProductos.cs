using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
          
        }

        

        private void btnVer_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVerProductos_Click(object sender, EventArgs e)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (MySqlConnection conexion = new MySqlConnection(cnn))
                {
                    conexion.Open();

                    string Tabla = "Productos";

                    string query = $"SELECT * FROM {Tabla} WHERE stock > 0";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        dtProductos.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
