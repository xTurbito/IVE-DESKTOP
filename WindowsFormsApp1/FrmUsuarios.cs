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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            UsuariosBD oUsuariosBD = new UsuariosBD();
            dtUsuarios.DataSource = oUsuariosBD.Get();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            FrmInfoUsuario frmAdd = new FrmInfoUsuario();
            frmAdd.ShowDialog();
            Refresh();  
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
          int? ID = GetId();
           if(ID != null)
            {
               FrmInfoUsuario frmEdit = new FrmInfoUsuario(ID);
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
                    UsuariosBD oUsuarioBD = new UsuariosBD();
                    oUsuarioBD.Delete((int)ID);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar: " + ex.Message);

            }
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dtUsuarios.Rows[dtUsuarios.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            { return null; }
        }

      
    }
}
