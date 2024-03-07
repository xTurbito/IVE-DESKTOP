namespace WindowsFormsApp1
{
    partial class FrmInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel1.Controls.Add(this.btnUsuarios);
            this.flowLayoutPanel1.Controls.Add(this.btnProductos);
            this.flowLayoutPanel1.Controls.Add(this.btnProveedores);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(899, 60);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(3, 3);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(149, 52);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
           // this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Location = new System.Drawing.Point(158, 3);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(149, 52);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.White;
            this.btnProveedores.Location = new System.Drawing.Point(313, 3);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(149, 52);
            this.btnProveedores.TabIndex = 1;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = true;
        //    this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 504);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimizeBox = false;
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInicio";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnProveedores;
    }
}