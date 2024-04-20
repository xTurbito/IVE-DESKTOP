using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class FrmInfoProducto : Form
    {
        private int? IDProducto;
        public FrmInfoProducto(int? iDProducto = null)
        {
            InitializeComponent();
           this.IDProducto = iDProducto;
            if(this.IDProducto != null)
                LoadData();
        }

        private void LoadData()
        {
            ProductoBD oProductoDb = new ProductoBD();
            Productos oProducto = oProductoDb.Get((int)IDProducto);
            txtNombre.Text = oProducto.Nombre;
            txtDescripcion.Text = oProducto.Descripcion;
            txtPrecio.Text = oProducto.precio_venta.ToString();
            txtStock.Text = oProducto.Stock.ToString();
            txtActivo.Text = oProducto.lActivo.ToString();
            txtPrecio_cost.Text = oProducto.precio_costo.ToString();

        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            ProductoBD oProductoBD = new ProductoBD();
            try
            {
                if (IDProducto == null)
                    oProductoBD.Add(txtNombre.Text, txtDescripcion.Text, Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtStock.Text), Convert.ToInt32(txtActivo.Text), Convert.ToDecimal(txtPrecio_cost.Text));
                else
                {
                    oProductoBD.Update(txtNombre.Text, txtDescripcion.Text, Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtStock.Text), Convert.ToInt32(txtActivo.Text), (int)IDProducto, Convert.ToDecimal(txtPrecio_cost.Text)); //
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un erro al guardar: " + ex.Message);
            }
        }
    }
}
