using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
            
        }


        //Trae la conexion del App.Config
        public void logins()
        {
           
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using(MySqlConnection conexion = new MySqlConnection(cnn))
                {
                    conexion.Open();
                    
                    string query = "SELECT usuario, password, lActivo FROM usuarios WHERE usuario = @Usuario AND password = @Password";

                    using (MySqlCommand cmd = new MySqlCommand(query,  conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", txtUser.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text); 

                       using(MySqlDataReader dr =  cmd.ExecuteReader())
                        {
                            if(dr.Read()) 
                            {
                                object lActivo = dr["lActivo"];

                                if (lActivo != null && lActivo != DBNull.Value && (int)lActivo == 0)
                                {
                                    MessageBox.Show("La cuenta está inactiva, consulte a su administrador");
                                }
                                else
                                {
                                    FrmInicio frmInicio = new FrmInicio();
                                    frmInicio.Show();

                                    this.Hide();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Datos Incorrectos");
                                txtUser.Clear();
                                txtPassword.Clear();
                            }
                        }
                     }
                       
                    }
                     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnJoin_Click(object sender, EventArgs e)
        {

            logins();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
