namespace WindowsFormsApp1
{
    partial class FrmNuevoProducto
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
            this.lbNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lbPrecio = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lbStock = new System.Windows.Forms.Label();
            this.txtActivo = new System.Windows.Forms.TextBox();
            this.lbActivo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btGuardar = new FontAwesome.Sharp.IconButton();
            this.pbfotoProducto = new System.Windows.Forms.PictureBox();
            this.btnSubirFoto = new FontAwesome.Sharp.IconButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbfotoProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.Location = new System.Drawing.Point(24, 73);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(65, 20);
            this.lbNombre.TabIndex = 0;
            this.lbNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(162, 73);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(229, 26);
            this.txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(162, 111);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(229, 26);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescripcion.Location = new System.Drawing.Point(24, 111);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(92, 20);
            this.lbDescripcion.TabIndex = 2;
            this.lbDescripcion.Text = "Descripcion";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(162, 201);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(229, 26);
            this.txtPrecio.TabIndex = 5;
            // 
            // lbPrecio
            // 
            this.lbPrecio.AutoSize = true;
            this.lbPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecio.Location = new System.Drawing.Point(24, 209);
            this.lbPrecio.Name = "lbPrecio";
            this.lbPrecio.Size = new System.Drawing.Size(53, 20);
            this.lbPrecio.TabIndex = 4;
            this.lbPrecio.Text = "Precio";
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(162, 253);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(229, 26);
            this.txtStock.TabIndex = 7;
            // 
            // lbStock
            // 
            this.lbStock.AutoSize = true;
            this.lbStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStock.Location = new System.Drawing.Point(24, 253);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(50, 20);
            this.lbStock.TabIndex = 6;
            this.lbStock.Text = "Stock";
            // 
            // txtActivo
            // 
            this.txtActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivo.Location = new System.Drawing.Point(162, 299);
            this.txtActivo.Name = "txtActivo";
            this.txtActivo.Size = new System.Drawing.Size(229, 26);
            this.txtActivo.TabIndex = 9;
            // 
            // lbActivo
            // 
            this.lbActivo.AutoSize = true;
            this.lbActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActivo.Location = new System.Drawing.Point(24, 299);
            this.lbActivo.Name = "lbActivo";
            this.lbActivo.Size = new System.Drawing.Size(52, 20);
            this.lbActivo.TabIndex = 8;
            this.lbActivo.Text = "Activo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Alta de Producto";
            // 
            // btGuardar
            // 
            this.btGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btGuardar.IconColor = System.Drawing.Color.Black;
            this.btGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btGuardar.Location = new System.Drawing.Point(193, 351);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(125, 23);
            this.btGuardar.TabIndex = 11;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // pbfotoProducto
            // 
            this.pbfotoProducto.Location = new System.Drawing.Point(447, 24);
            this.pbfotoProducto.Name = "pbfotoProducto";
            this.pbfotoProducto.Size = new System.Drawing.Size(204, 255);
            this.pbfotoProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbfotoProducto.TabIndex = 28;
            this.pbfotoProducto.TabStop = false;
            // 
            // btnSubirFoto
            // 
            this.btnSubirFoto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSubirFoto.IconColor = System.Drawing.Color.Black;
            this.btnSubirFoto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSubirFoto.Location = new System.Drawing.Point(493, 298);
            this.btnSubirFoto.Name = "btnSubirFoto";
            this.btnSubirFoto.Size = new System.Drawing.Size(125, 23);
            this.btnSubirFoto.TabIndex = 29;
            this.btnSubirFoto.Text = "Subir Foto";
            this.btnSubirFoto.UseVisualStyleBackColor = true;
            this.btnSubirFoto.Click += new System.EventHandler(this.btnSubirFoto_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(162, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 26);
            this.textBox1.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Precio";
            // 
            // FrmNuevoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 392);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSubirFoto);
            this.Controls.Add(this.pbfotoProducto);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActivo);
            this.Controls.Add(this.lbActivo);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lbStock);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lbPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lbDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbNombre);
            this.Name = "FrmNuevoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevoProducto1";
            ((System.ComponentModel.ISupportInitialize)(this.pbfotoProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lbPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lbStock;
        private System.Windows.Forms.TextBox txtActivo;
        private System.Windows.Forms.Label lbActivo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btGuardar;
        private System.Windows.Forms.PictureBox pbfotoProducto;
        private FontAwesome.Sharp.IconButton btnSubirFoto;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}