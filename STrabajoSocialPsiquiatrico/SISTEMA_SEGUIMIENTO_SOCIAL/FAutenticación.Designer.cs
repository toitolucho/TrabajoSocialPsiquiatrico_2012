namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FAutenticación
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAutenticación));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNombreUsuarioIngresarSistema = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtContraseñaIngresarSistema = new System.Windows.Forms.TextBox();
            this.btnAceptarIngresoSistema = new System.Windows.Forms.Button();
            this.btnCancelarIngresoSistema = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proporcione el Nombre de Usuario y Contraseña ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 198);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SISTEMA_SEGUIMIENTO_SOCIAL.Properties.Resources.password;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "para utilizar el Sistema";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre de Usuario";
            // 
            // TxtNombreUsuarioIngresarSistema
            // 
            this.TxtNombreUsuarioIngresarSistema.Location = new System.Drawing.Point(26, 74);
            this.TxtNombreUsuarioIngresarSistema.Name = "TxtNombreUsuarioIngresarSistema";
            this.TxtNombreUsuarioIngresarSistema.Size = new System.Drawing.Size(245, 20);
            this.TxtNombreUsuarioIngresarSistema.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contraseña";
            // 
            // TxtContraseñaIngresarSistema
            // 
            this.TxtContraseñaIngresarSistema.Location = new System.Drawing.Point(26, 118);
            this.TxtContraseñaIngresarSistema.Name = "TxtContraseñaIngresarSistema";
            this.TxtContraseñaIngresarSistema.PasswordChar = '*';
            this.TxtContraseñaIngresarSistema.Size = new System.Drawing.Size(165, 20);
            this.TxtContraseñaIngresarSistema.TabIndex = 7;
            this.TxtContraseñaIngresarSistema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContraseñaIngresarSistema_KeyPress);
            // 
            // btnAceptarIngresoSistema
            // 
            this.btnAceptarIngresoSistema.Location = new System.Drawing.Point(98, 160);
            this.btnAceptarIngresoSistema.Name = "btnAceptarIngresoSistema";
            this.btnAceptarIngresoSistema.Size = new System.Drawing.Size(85, 31);
            this.btnAceptarIngresoSistema.TabIndex = 8;
            this.btnAceptarIngresoSistema.Text = "&Aceptar";
            this.btnAceptarIngresoSistema.UseVisualStyleBackColor = true;
            this.btnAceptarIngresoSistema.Click += new System.EventHandler(this.btnAceptarIngresoSistema_Click);
            // 
            // btnCancelarIngresoSistema
            // 
            this.btnCancelarIngresoSistema.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarIngresoSistema.Location = new System.Drawing.Point(200, 160);
            this.btnCancelarIngresoSistema.Name = "btnCancelarIngresoSistema";
            this.btnCancelarIngresoSistema.Size = new System.Drawing.Size(85, 31);
            this.btnCancelarIngresoSistema.TabIndex = 9;
            this.btnCancelarIngresoSistema.Text = "&Cancelar";
            this.btnCancelarIngresoSistema.UseVisualStyleBackColor = true;
            this.btnCancelarIngresoSistema.Click += new System.EventHandler(this.btnCancelarIngresoSistema_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.TxtNombreUsuarioIngresarSistema);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnCancelarIngresoSistema);
            this.panel2.Controls.Add(this.btnAceptarIngresoSistema);
            this.panel2.Controls.Add(this.TxtContraseñaIngresarSistema);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(128, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 201);
            this.panel2.TabIndex = 10;
            // 
            // FAutenticación
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnCancelarIngresoSistema;
            this.ClientSize = new System.Drawing.Size(429, 212);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FAutenticación";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autenticación de Ususario...";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNombreUsuarioIngresarSistema;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtContraseñaIngresarSistema;
        private System.Windows.Forms.Button btnAceptarIngresoSistema;
        private System.Windows.Forms.Button btnCancelarIngresoSistema;
        private System.Windows.Forms.Panel panel2;
    }
}