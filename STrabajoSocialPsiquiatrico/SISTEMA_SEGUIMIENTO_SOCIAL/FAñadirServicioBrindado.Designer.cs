namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FAñadirServicioBrindado
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAñadirServicioBrindado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCodigoServicio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtServicio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rTextBoxDescripciónServicio = new System.Windows.Forms.RichTextBox();
            this.gBoxDatos = new System.Windows.Forms.GroupBox();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminarSErvicio = new System.Windows.Forms.Button();
            this.btnAñadirServicio = new System.Windows.Forms.Button();
            this.btnGuardarServicio = new System.Windows.Forms.Button();
            this.btnCancelarServicio = new System.Windows.Forms.Button();
            this.btnEditarServicio = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVListadoServicios = new System.Windows.Forms.DataGridView();
            this.DGCCodigoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdSourceServicios = new System.Windows.Forms.BindingSource(this.components);
            this.gBoxDatos.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(55, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Servicio :";
            // 
            // TxtCodigoServicio
            // 
            this.TxtCodigoServicio.Location = new System.Drawing.Point(148, 22);
            this.TxtCodigoServicio.Name = "TxtCodigoServicio";
            this.TxtCodigoServicio.ReadOnly = true;
            this.TxtCodigoServicio.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigoServicio.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(51, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre Servicio :";
            // 
            // TxtServicio
            // 
            this.TxtServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtServicio.Location = new System.Drawing.Point(148, 50);
            this.TxtServicio.Name = "TxtServicio";
            this.TxtServicio.Size = new System.Drawing.Size(381, 20);
            this.TxtServicio.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(73, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción :";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Undo.png");
            this.imageList1.Images.SetKeyName(1, "Yes v3.png");
            this.imageList1.Images.SetKeyName(2, "Copia de Save file.png");
            this.imageList1.Images.SetKeyName(3, "Erase.png");
            this.imageList1.Images.SetKeyName(4, "exit.png");
            this.imageList1.Images.SetKeyName(5, "wi0062-48.gif");
            this.imageList1.Images.SetKeyName(6, "edit_add.png");
            // 
            // rTextBoxDescripciónServicio
            // 
            this.rTextBoxDescripciónServicio.Location = new System.Drawing.Point(148, 106);
            this.rTextBoxDescripciónServicio.Name = "rTextBoxDescripciónServicio";
            this.rTextBoxDescripciónServicio.Size = new System.Drawing.Size(381, 45);
            this.rTextBoxDescripciónServicio.TabIndex = 3;
            this.rTextBoxDescripciónServicio.Text = "";
            // 
            // gBoxDatos
            // 
            this.gBoxDatos.Controls.Add(this.TxtPrecio);
            this.gBoxDatos.Controls.Add(this.label7);
            this.gBoxDatos.Controls.Add(this.label8);
            this.gBoxDatos.Controls.Add(this.rTextBoxDescripciónServicio);
            this.gBoxDatos.Controls.Add(this.label1);
            this.gBoxDatos.Controls.Add(this.TxtCodigoServicio);
            this.gBoxDatos.Controls.Add(this.label2);
            this.gBoxDatos.Controls.Add(this.label3);
            this.gBoxDatos.Controls.Add(this.TxtServicio);
            this.gBoxDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDatos.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxDatos.Location = new System.Drawing.Point(0, 0);
            this.gBoxDatos.Name = "gBoxDatos";
            this.gBoxDatos.Size = new System.Drawing.Size(580, 160);
            this.gBoxDatos.TabIndex = 0;
            this.gBoxDatos.TabStop = false;
            this.gBoxDatos.Text = "Introducción de Datos :";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(148, 78);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(100, 20);
            this.TxtPrecio.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(251, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Bs.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(99, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Precio :";
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnEliminarSErvicio);
            this.pnlBotones.Controls.Add(this.btnAñadirServicio);
            this.pnlBotones.Controls.Add(this.btnGuardarServicio);
            this.pnlBotones.Controls.Add(this.btnCancelarServicio);
            this.pnlBotones.Controls.Add(this.btnEditarServicio);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 403);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(580, 40);
            this.pnlBotones.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(252, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 31);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminarSErvicio
            // 
            this.btnEliminarSErvicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarSErvicio.ImageIndex = 3;
            this.btnEliminarSErvicio.ImageList = this.imageList1;
            this.btnEliminarSErvicio.Location = new System.Drawing.Point(334, 3);
            this.btnEliminarSErvicio.Name = "btnEliminarSErvicio";
            this.btnEliminarSErvicio.Size = new System.Drawing.Size(76, 31);
            this.btnEliminarSErvicio.TabIndex = 3;
            this.btnEliminarSErvicio.Text = "&Eliminar";
            this.btnEliminarSErvicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarSErvicio.UseVisualStyleBackColor = true;
            this.btnEliminarSErvicio.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAñadirServicio
            // 
            this.btnAñadirServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirServicio.ImageIndex = 6;
            this.btnAñadirServicio.ImageList = this.imageList1;
            this.btnAñadirServicio.Location = new System.Drawing.Point(6, 3);
            this.btnAñadirServicio.Name = "btnAñadirServicio";
            this.btnAñadirServicio.Size = new System.Drawing.Size(76, 31);
            this.btnAñadirServicio.TabIndex = 0;
            this.btnAñadirServicio.Text = "&Añadir";
            this.btnAñadirServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirServicio.UseVisualStyleBackColor = true;
            this.btnAñadirServicio.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardarServicio
            // 
            this.btnGuardarServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarServicio.ImageIndex = 2;
            this.btnGuardarServicio.ImageList = this.imageList1;
            this.btnGuardarServicio.Location = new System.Drawing.Point(88, 3);
            this.btnGuardarServicio.Name = "btnGuardarServicio";
            this.btnGuardarServicio.Size = new System.Drawing.Size(76, 31);
            this.btnGuardarServicio.TabIndex = 1;
            this.btnGuardarServicio.Text = "&Guardar";
            this.btnGuardarServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarServicio.UseVisualStyleBackColor = true;
            this.btnGuardarServicio.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelarServicio
            // 
            this.btnCancelarServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarServicio.ImageIndex = 4;
            this.btnCancelarServicio.ImageList = this.imageList1;
            this.btnCancelarServicio.Location = new System.Drawing.Point(497, 3);
            this.btnCancelarServicio.Name = "btnCancelarServicio";
            this.btnCancelarServicio.Size = new System.Drawing.Size(76, 31);
            this.btnCancelarServicio.TabIndex = 5;
            this.btnCancelarServicio.Text = "&Cerrar";
            this.btnCancelarServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarServicio.UseVisualStyleBackColor = true;
            this.btnCancelarServicio.Click += new System.EventHandler(this.btnCerrarAñadirServicio_Click);
            // 
            // btnEditarServicio
            // 
            this.btnEditarServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarServicio.ImageIndex = 5;
            this.btnEditarServicio.ImageList = this.imageList1;
            this.btnEditarServicio.Location = new System.Drawing.Point(170, 3);
            this.btnEditarServicio.Name = "btnEditarServicio";
            this.btnEditarServicio.Size = new System.Drawing.Size(76, 31);
            this.btnEditarServicio.TabIndex = 2;
            this.btnEditarServicio.Text = "&Editar";
            this.btnEditarServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarServicio.UseVisualStyleBackColor = true;
            this.btnEditarServicio.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVListadoServicios);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(0, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 243);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Servicios :";
            // 
            // dtGVListadoServicios
            // 
            this.dtGVListadoServicios.AllowUserToAddRows = false;
            this.dtGVListadoServicios.AllowUserToResizeRows = false;
            this.dtGVListadoServicios.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoServicio,
            this.DGCNombreServicio,
            this.DGCPrecio,
            this.DGCDescripcion});
            this.dtGVListadoServicios.DataSource = this.bdSourceServicios;
            this.dtGVListadoServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListadoServicios.Location = new System.Drawing.Point(3, 16);
            this.dtGVListadoServicios.Name = "dtGVListadoServicios";
            this.dtGVListadoServicios.ReadOnly = true;
            this.dtGVListadoServicios.RowHeadersVisible = false;
            this.dtGVListadoServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListadoServicios.Size = new System.Drawing.Size(574, 224);
            this.dtGVListadoServicios.TabIndex = 0;
            // 
            // DGCCodigoServicio
            // 
            this.DGCCodigoServicio.DataPropertyName = "CodigoServicio";
            this.DGCCodigoServicio.HeaderText = "Cod.";
            this.DGCCodigoServicio.Name = "DGCCodigoServicio";
            this.DGCCodigoServicio.ReadOnly = true;
            this.DGCCodigoServicio.Width = 65;
            // 
            // DGCNombreServicio
            // 
            this.DGCNombreServicio.DataPropertyName = "NombreServicio";
            this.DGCNombreServicio.HeaderText = "Nombre";
            this.DGCNombreServicio.Name = "DGCNombreServicio";
            this.DGCNombreServicio.ReadOnly = true;
            this.DGCNombreServicio.Width = 230;
            // 
            // DGCPrecio
            // 
            this.DGCPrecio.DataPropertyName = "Precio";
            this.DGCPrecio.HeaderText = "Precio";
            this.DGCPrecio.MinimumWidth = 60;
            this.DGCPrecio.Name = "DGCPrecio";
            this.DGCPrecio.ReadOnly = true;
            // 
            // DGCDescripcion
            // 
            this.DGCDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCDescripcion.DataPropertyName = "Descripcion";
            this.DGCDescripcion.HeaderText = "Descripción";
            this.DGCDescripcion.Name = "DGCDescripcion";
            this.DGCDescripcion.ReadOnly = true;
            // 
            // bdSourceServicios
            // 
            this.bdSourceServicios.CurrentChanged += new System.EventHandler(this.bdSourceServicios_CurrentChanged);
            // 
            // FAñadirServicioBrindado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(580, 443);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.gBoxDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAñadirServicioBrindado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AÑADIR SERVICIOS BRINDADOS";
            this.gBoxDatos.ResumeLayout(false);
            this.gBoxDatos.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCodigoServicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtServicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardarServicio;
        private System.Windows.Forms.Button btnCancelarServicio;
        private System.Windows.Forms.RichTextBox rTextBoxDescripciónServicio;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gBoxDatos;
        private System.Windows.Forms.Button btnEditarServicio;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEliminarSErvicio;
        private System.Windows.Forms.Button btnAñadirServicio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGVListadoServicios;
        private System.Windows.Forms.BindingSource bdSourceServicios;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDescripcion;
    }
}