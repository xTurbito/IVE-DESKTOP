using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmInfoUsuario : Form
    {
        private int? IDUsuario;
        public FrmInfoUsuario(int? IDUsuario = null)
        {
            InitializeComponent();
            this.IDUsuario = IDUsuario;
            if (this.IDUsuario != null)
                LoadData();
        }

        private void LoadData()
        {
            UsuariosBD oUsuarioBD = new UsuariosBD();
            Usuarios oUsuario = oUsuarioBD.Get((int)IDUsuario);
            txtUsuario.Text = oUsuario.usuario;
            txtPassword.Text = oUsuario.password;
            txtNombre.Text = oUsuario.nombre;
            txtTipoUsuario.Text = oUsuario.idPerfil.ToString();  
           txtActivo.Text = oUsuario.lactivo.ToString();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            UsuariosBD oUsuariosBD = new UsuariosBD();
            try
            {   if(IDUsuario == null)
                oUsuariosBD.Add(txtUsuario.Text, txtPassword.Text, txtNombre.Text, int.Parse(txtTipoUsuario.Text), int.Parse(txtActivo.Text));
                else
                   oUsuariosBD.Update(txtUsuario.Text, txtPassword.Text, txtNombre.Text, int.Parse(txtTipoUsuario.Text), int.Parse(txtActivo.Text), (int)IDUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }
            this.Close();
        }
    }
}
