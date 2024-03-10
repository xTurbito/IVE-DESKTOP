using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
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

        private void Refresh()
        {
            ProductoBD oProductoDB = new ProductoBD();
            dtProductos.DataSource = oProductoDB.Get();
            dtProductos.Columns[0].Visible = false;
            dtProductos.Columns[7].Visible = false;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            
            Refresh();
        }

       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FrmInfoProducto frm = new FrmInfoProducto();
            frm.ShowDialog();
            Refresh();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? ID = GetId();
            if (ID != null)
            {
                FrmInfoProducto frmEdit = new FrmInfoProducto(ID);
                frmEdit.ShowDialog();
                Refresh();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? ID = GetId();
            try
            {

            
            if (ID != null)
            {
                ProductoBD oProductoDB = new ProductoBD();
                oProductoDB.Delete((int)ID);
                Refresh();
            }

            }
            catch (Exception ex)
            { 
              MessageBox.Show("Ocurrio un error al eliminiar : "+ ex.Message);
            
            }

        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dtProductos.Rows[dtProductos.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch 
            {
                return null;
              }
        }

        
    }
}
