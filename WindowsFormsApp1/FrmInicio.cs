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
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            
        }


      

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.ShowDialog();

           
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();    
            frmUsuarios.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
           FrmProveedores frmProveedores = new FrmProveedores();    
            frmProveedores.ShowDialog();
        }
    }
}
