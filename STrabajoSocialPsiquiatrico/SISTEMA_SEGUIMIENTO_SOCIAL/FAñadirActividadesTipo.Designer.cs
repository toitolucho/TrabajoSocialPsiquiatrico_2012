namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FAñadirActividadesTipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAñadirActividadesTipo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gBoxDetalle = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cBoxClaseActividad = new System.Windows.Forms.ComboBox();
            this.rTextBoxDescripcionActividad = new System.Windows.Forms.RichTextBox();
            this.TxtNombreActividad = new System.Windows.Forms.TextBox();
            this.TxtCodigoTipoActividad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAñadirActividad = new System.Windows.Forms.Button();
            this.btnGuardarActividad = new System.Windows.Forms.Button();
            this.btnEliminarActividad = new System.Windows.Forms.Button();
            this.btnCerrarAñadirActividad = new System.Windows.Forms.Button();
            this.btnEditarActividad = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVListadoACtividades = new System.Windows.Forms.DataGridView();
            this.DGCCodigoActividadTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreActividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdSourceActividadesTipos = new System.Windows.Forms.BindingSource(this.components);
            this.gBoxDetalle.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoACtividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceActividadesTipos)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxDetalle
            // 
            this.gBoxDetalle.Controls.Add(this.label4);
            this.gBoxDetalle.Controls.Add(this.cBoxClaseActividad);
            this.gBoxDetalle.Controls.Add(this.rTextBoxDescripcionActividad);
            this.gBoxDetalle.Controls.Add(this.TxtNombreActividad);
            this.gBoxDetalle.Controls.Add(this.TxtCodigoTipoActividad);
            this.gBoxDetalle.Controls.Add(this.label3);
            this.gBoxDetalle.Controls.Add(this.label2);
            this.gBoxDetalle.Controls.Add(this.label1);
            this.gBoxDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDetalle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxDetalle.Location = new System.Drawing.Point(0, 0);
            this.gBoxDetalle.Name = "gBoxDetalle";
            this.gBoxDetalle.Size = new System.Drawing.Size(614, 177);
            this.gBoxDetalle.TabIndex = 0;
            this.gBoxDetalle.TabStop = false;
            this.gBoxDetalle.Text = "Introducción Datos :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(78, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Clase Actividad :";
            // 
            // cBoxClaseActividad
            // 
            this.cBoxClaseActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxClaseActividad.FormattingEnabled = true;
            this.cBoxClaseActividad.Location = new System.Drawing.Point(169, 81);
            this.cBoxClaseActividad.Name = "cBoxClaseActividad";
            this.cBoxClaseActividad.Size = new System.Drawing.Size(399, 21);
            this.cBoxClaseActividad.TabIndex = 6;
            // 
            // rTextBoxDescripcionActividad
            // 
            this.rTextBoxDescripcionActividad.Location = new System.Drawing.Point(170, 111);
            this.rTextBoxDescripcionActividad.Name = "rTextBoxDescripcionActividad";
            this.rTextBoxDescripcionActividad.Size = new System.Drawing.Size(398, 52);
            this.rTextBoxDescripcionActividad.TabIndex = 5;
            this.rTextBoxDescripcionActividad.Text = "";
            // 
            // TxtNombreActividad
            // 
            this.TxtNombreActividad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombreActividad.Location = new System.Drawing.Point(169, 52);
            this.TxtNombreActividad.Name = "TxtNombreActividad";
            this.TxtNombreActividad.Size = new System.Drawing.Size(399, 20);
            this.TxtNombreActividad.TabIndex = 4;
            // 
            // TxtCodigoTipoActividad
            // 
            this.TxtCodigoTipoActividad.Location = new System.Drawing.Point(169, 23);
            this.TxtCodigoTipoActividad.Name = "TxtCodigoTipoActividad";
            this.TxtCodigoTipoActividad.ReadOnly = true;
            this.TxtCodigoTipoActividad.Size = new System.Drawing.Size(90, 20);
            this.TxtCodigoTipoActividad.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(95, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(67, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Actividad :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(47, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Tipo Actividad :";
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnAñadirActividad);
            this.pnlBotones.Controls.Add(this.btnGuardarActividad);
            this.pnlBotones.Controls.Add(this.btnEliminarActividad);
            this.pnlBotones.Controls.Add(this.btnCerrarAñadirActividad);
            this.pnlBotones.Controls.Add(this.btnEditarActividad);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 433);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(614, 40);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 4;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(232, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 32);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "edit_add.png");
            this.imageList1.Images.SetKeyName(1, "Erase.png");
            this.imageList1.Images.SetKeyName(2, "Floppy.png");
            this.imageList1.Images.SetKeyName(3, "Shutdown.png");
            this.imageList1.Images.SetKeyName(4, "Undo.png");
            this.imageList1.Images.SetKeyName(5, "web.png");
            this.imageList1.Images.SetKeyName(6, "wi0062-48.gif");
            // 
            // btnAñadirActividad
            // 
            this.btnAñadirActividad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirActividad.ImageIndex = 0;
            this.btnAñadirActividad.ImageList = this.imageList1;
            this.btnAñadirActividad.Location = new System.Drawing.Point(7, 3);
            this.btnAñadirActividad.Name = "btnAñadirActividad";
            this.btnAñadirActividad.Size = new System.Drawing.Size(72, 32);
            this.btnAñadirActividad.TabIndex = 15;
            this.btnAñadirActividad.Text = "&Añadir";
            this.btnAñadirActividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirActividad.UseVisualStyleBackColor = true;
            this.btnAñadirActividad.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardarActividad
            // 
            this.btnGuardarActividad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarActividad.ImageIndex = 2;
            this.btnGuardarActividad.ImageList = this.imageList1;
            this.btnGuardarActividad.Location = new System.Drawing.Point(82, 3);
            this.btnGuardarActividad.Name = "btnGuardarActividad";
            this.btnGuardarActividad.Size = new System.Drawing.Size(72, 32);
            this.btnGuardarActividad.TabIndex = 14;
            this.btnGuardarActividad.Text = "&Guardar";
            this.btnGuardarActividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarActividad.UseVisualStyleBackColor = true;
            this.btnGuardarActividad.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnEliminarActividad
            // 
            this.btnEliminarActividad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarActividad.ImageIndex = 1;
            this.btnEliminarActividad.ImageList = this.imageList1;
            this.btnEliminarActividad.Location = new System.Drawing.Point(307, 3);
            this.btnEliminarActividad.Name = "btnEliminarActividad";
            this.btnEliminarActividad.Size = new System.Drawing.Size(72, 32);
            this.btnEliminarActividad.TabIndex = 13;
            this.btnEliminarActividad.Text = "&Eliminar";
            this.btnEliminarActividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarActividad.UseVisualStyleBackColor = true;
            this.btnEliminarActividad.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrarAñadirActividad
            // 
            this.btnCerrarAñadirActividad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarAñadirActividad.ImageIndex = 3;
            this.btnCerrarAñadirActividad.ImageList = this.imageList1;
            this.btnCerrarAñadirActividad.Location = new System.Drawing.Point(533, 3);
            this.btnCerrarAñadirActividad.Name = "btnCerrarAñadirActividad";
            this.btnCerrarAñadirActividad.Size = new System.Drawing.Size(72, 32);
            this.btnCerrarAñadirActividad.TabIndex = 12;
            this.btnCerrarAñadirActividad.Text = "&Cerrar";
            this.btnCerrarAñadirActividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarAñadirActividad.UseVisualStyleBackColor = true;
            this.btnCerrarAñadirActividad.Click += new System.EventHandler(this.btnCerrarAñadirActividad_Click);
            // 
            // btnEditarActividad
            // 
            this.btnEditarActividad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarActividad.ImageIndex = 6;
            this.btnEditarActividad.ImageList = this.imageList1;
            this.btnEditarActividad.Location = new System.Drawing.Point(157, 3);
            this.btnEditarActividad.Name = "btnEditarActividad";
            this.btnEditarActividad.Size = new System.Drawing.Size(72, 32);
            this.btnEditarActividad.TabIndex = 11;
            this.btnEditarActividad.Text = "&Editar";
            this.btnEditarActividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarActividad.UseVisualStyleBackColor = true;
            this.btnEditarActividad.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVListadoACtividades);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(0, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 256);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Actividades :";
            // 
            // dtGVListadoACtividades
            // 
            this.dtGVListadoACtividades.AllowUserToAddRows = false;
            this.dtGVListadoACtividades.AllowUserToResizeColumns = false;
            this.dtGVListadoACtividades.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoACtividades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoACtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoACtividades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoActividadTipo,
            this.DGCNombreActividad,
            this.DGCDescripcion});
            this.dtGVListadoACtividades.DataSource = this.bdSourceActividadesTipos;
            this.dtGVListadoACtividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListadoACtividades.Location = new System.Drawing.Point(3, 16);
            this.dtGVListadoACtividades.Name = "dtGVListadoACtividades";
            this.dtGVListadoACtividades.ReadOnly = true;
            this.dtGVListadoACtividades.RowHeadersVisible = false;
            this.dtGVListadoACtividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListadoACtividades.Size = new System.Drawing.Size(608, 237);
            this.dtGVListadoACtividades.TabIndex = 0;
            // 
            // DGCCodigoActividadTipo
            // 
            this.DGCCodigoActividadTipo.DataPropertyName = "CodigoActividadTipo";
            this.DGCCodigoActividadTipo.HeaderText = "Código";
            this.DGCCodigoActividadTipo.Name = "DGCCodigoActividadTipo";
            this.DGCCodigoActividadTipo.ReadOnly = true;
            this.DGCCodigoActividadTipo.Width = 80;
            // 
            // DGCNombreActividad
            // 
            this.DGCNombreActividad.DataPropertyName = "NombreActividad";
            this.DGCNombreActividad.HeaderText = "Nombre de la Actividad";
            this.DGCNombreActividad.Name = "DGCNombreActividad";
            this.DGCNombreActividad.ReadOnly = true;
            this.DGCNombreActividad.Width = 550;
            // 
            // DGCDescripcion
            // 
            this.DGCDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCDescripcion.DataPropertyName = "Descripcion";
            this.DGCDescripcion.HeaderText = "Descripción";
            this.DGCDescripcion.Name = "DGCDescripcion";
            this.DGCDescripcion.ReadOnly = true;
            this.DGCDescripcion.Visible = false;
            // 
            // bdSourceActividadesTipos
            // 
            this.bdSourceActividadesTipos.CurrentChanged += new System.EventHandler(this.bdSourceActividadesTipos_CurrentChanged);
            // 
            // FAñadirActividadesTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(614, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.gBoxDetalle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAñadirActividadesTipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AÑADIR ACTIVIDADES";
            this.gBoxDetalle.ResumeLayout(false);
            this.gBoxDetalle.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoACtividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceActividadesTipos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxDetalle;
        private System.Windows.Forms.RichTextBox rTextBoxDescripcionActividad;
        private System.Windows.Forms.TextBox TxtNombreActividad;
        private System.Windows.Forms.TextBox TxtCodigoTipoActividad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCerrarAñadirActividad;
        private System.Windows.Forms.Button btnEditarActividad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGVListadoACtividades;
        private System.Windows.Forms.Button btnEliminarActividad;
        private System.Windows.Forms.Button btnGuardarActividad;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAñadirActividad;
        private System.Windows.Forms.BindingSource bdSourceActividadesTipos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBoxClaseActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoActividadTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDescripcion;
    }
}