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
    public partial class FrmNuevoProducto : Form
    {
        private int? IDProducto;
        Bitmap image;
        private string base64Text;
        public FrmNuevoProducto(int? iDProducto = null)
        {
            InitializeComponent();
           this.IDProducto = iDProducto;
            if(this.IDProducto != null)
                LoadData();
        }

        private void LoadData()
        {
            ProductoDB oProductoDb = new ProductoDB();
            Productos oProducto = oProductoDb.Get((int)IDProducto);
            txtNombre.Text = oProducto.Nombre;
            txtDescripcion.Text = oProducto.Descripcion;
            txtPrecio.Text = oProducto.Precio.ToString();
            txtStock.Text = oProducto.Stock.ToString();
            txtActivo.Text = oProducto.lActivo.ToString();

            if(!string.IsNullOrEmpty(oProducto.fotoproducto))
            {
                try
                {
                    byte[] imageData = Convert.FromBase64String(oProducto.fotoproducto);
                    using(MemoryStream ms = new MemoryStream(imageData))
                    {
                        pbfotoProducto.Image = Image.FromStream(ms);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                }

            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            ProductoDB oProductoDB = new ProductoDB();  
            try
            {
                if (IDProducto == null)
                    oProductoDB.Add(txtNombre.Text, txtDescripcion.Text, txtPrecio.Text, int.Parse(txtStock.Text), int.Parse(txtActivo.Text), base64Text);
                else
                {
                    string fotoProducto = string.IsNullOrEmpty(base64Text) ? null : base64Text; 
                    oProductoDB.Update(txtNombre.Text, txtDescripcion.Text, txtPrecio.Text, int.Parse(txtStock.Text), int.Parse(txtActivo.Text),base64Text, (int) IDProducto);
                   
                }
                this.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Ocurrio un erro al guardar: " + ex.Message);
            }
        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg;*.png)|*.jpg;*.png|All files(*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string NombreFoto = System.IO.Path.GetFileName(dialog.FileName);
                string Ext = System.IO.Path.GetExtension(dialog.FileName);
                string Archivo = NombreFoto + Ext;
                image = new Bitmap(dialog.FileName);
                pbfotoProducto.Image = (Image) image;
                byte[] imageArray = System.IO.File.ReadAllBytes(dialog.FileName);
                base64Text = Convert.ToBase64String(imageArray);    
            }
        }
    }
}
