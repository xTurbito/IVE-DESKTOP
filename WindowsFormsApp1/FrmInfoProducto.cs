﻿using System;
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
        Bitmap image;
        private string base64Text;
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
            txtPrecio.Text = oProducto.Precio.ToString();
            txtStock.Text = oProducto.Stock.ToString();
            txtActivo.Text = oProducto.lActivo.ToString();
            txtPrecio_cost.Text = oProducto.precio_cost.ToString();

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
            ProductoBD oProductoBD = new ProductoBD();
            try
            {
                if (IDProducto == null)
                    oProductoBD.Add(txtNombre.Text, txtDescripcion.Text, Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtStock.Text), Convert.ToInt32(txtActivo.Text), base64Text, Convert.ToDecimal(txtPrecio_cost.Text));
                else
                {
                    string fotoProducto = string.IsNullOrEmpty(base64Text) ? null : base64Text;
                    oProductoBD.Update(txtNombre.Text, txtDescripcion.Text, Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtStock.Text), Convert.ToInt32(txtActivo.Text), fotoProducto, (int)IDProducto, Convert.ToDecimal(txtPrecio_cost.Text)); // Cambio en el orden de los parámetros

                }
                this.Close();
            }
            catch (Exception ex)
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