namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FAñadirServicioSolicitado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAñadirServicioSolicitado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCodigoEspecialidad = new System.Windows.Forms.TextBox();
            this.TxtNombreEspecialidad = new System.Windows.Forms.TextBox();
            this.gBoxDatos = new System.Windows.Forms.GroupBox();
            this.TxtDescripcion = new System.Windows.Forms.RichTextBox();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCerrarEspecialidad = new System.Windows.Forms.Button();
            this.btnEliminarEspecialidad = new System.Windows.Forms.Button();
            this.btnAñadirEspecialidad = new System.Windows.Forms.Button();
            this.btnEditarESpecialidad = new System.Windows.Forms.Button();
            this.btnGuardarEspecidalidad = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVListadoEspecialidad = new System.Windows.Forms.DataGridView();
            this.DGCCodigoEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdSourceEspecialidades = new System.Windows.Forms.BindingSource(this.components);
            this.gBoxDatos.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoEspecialidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceEspecialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(122, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(28, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Servicio Solicitado :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(99, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción :";
            // 
            // TxtCodigoEspecialidad
            // 
            this.TxtCodigoEspecialidad.Location = new System.Drawing.Point(173, 20);
            this.TxtCodigoEspecialidad.Name = "TxtCodigoEspecialidad";
            this.TxtCodigoEspecialidad.ReadOnly = true;
            this.TxtCodigoEspecialidad.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigoEspecialidad.TabIndex = 3;
            // 
            // TxtNombreEspecialidad
            // 
            this.TxtNombreEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNombreEspecialidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombreEspecialidad.Location = new System.Drawing.Point(173, 50);
            this.TxtNombreEspecialidad.Name = "TxtNombreEspecialidad";
            this.TxtNombreEspecialidad.Size = new System.Drawing.Size(353, 20);
            this.TxtNombreEspecialidad.TabIndex = 4;
            // 
            // gBoxDatos
            // 
            this.gBoxDatos.Controls.Add(this.TxtDescripcion);
            this.gBoxDatos.Controls.Add(this.label1);
            this.gBoxDatos.Controls.Add(this.label2);
            this.gBoxDatos.Controls.Add(this.TxtNombreEspecialidad);
            this.gBoxDatos.Controls.Add(this.label3);
            this.gBoxDatos.Controls.Add(this.TxtCodigoEspecialidad);
            this.gBoxDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDatos.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxDatos.Location = new System.Drawing.Point(0, 0);
            this.gBoxDatos.Name = "gBoxDatos";
            this.gBoxDatos.Size = new System.Drawing.Size(553, 126);
            this.gBoxDatos.TabIndex = 6;
            this.gBoxDatos.TabStop = false;
            this.gBoxDatos.Text = "Introducción de Datos :";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDescripcion.Location = new System.Drawing.Point(173, 80);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(353, 35);
            this.TxtDescripcion.TabIndex = 5;
            this.TxtDescripcion.Text = "";
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnCerrarEspecialidad);
            this.pnlBotones.Controls.Add(this.btnEliminarEspecialidad);
            this.pnlBotones.Controls.Add(this.btnAñadirEspecialidad);
            this.pnlBotones.Controls.Add(this.btnEditarESpecialidad);
            this.pnlBotones.Controls.Add(this.btnGuardarEspecidalidad);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 432);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(553, 39);
            this.pnlBotones.TabIndex = 8;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 5;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(243, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Copia de Save file.png");
            this.imageList1.Images.SetKeyName(1, "edit_add.png");
            this.imageList1.Images.SetKeyName(2, "Erase.png");
            this.imageList1.Images.SetKeyName(3, "exit.png");
            this.imageList1.Images.SetKeyName(4, "wi0062-48.gif");
            this.imageList1.Images.SetKeyName(5, "Undo.png");
            // 
            // btnCerrarEspecialidad
            // 
            this.btnCerrarEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarEspecialidad.ImageIndex = 3;
            this.btnCerrarEspecialidad.ImageList = this.imageList1;
            this.btnCerrarEspecialidad.Location = new System.Drawing.Point(473, 2);
            this.btnCerrarEspecialidad.Name = "btnCerrarEspecialidad";
            this.btnCerrarEspecialidad.Size = new System.Drawing.Size(75, 32);
            this.btnCerrarEspecialidad.TabIndex = 13;
            this.btnCerrarEspecialidad.Text = "&Cerrar";
            this.btnCerrarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarEspecialidad.UseVisualStyleBackColor = true;
            this.btnCerrarEspecialidad.Click += new System.EventHandler(this.btnCerrarAñadirActividad_Click);
            // 
            // btnEliminarEspecialidad
            // 
            this.btnEliminarEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarEspecialidad.ImageIndex = 2;
            this.btnEliminarEspecialidad.ImageList = this.imageList1;
            this.btnEliminarEspecialidad.Location = new System.Drawing.Point(322, 2);
            this.btnEliminarEspecialidad.Name = "btnEliminarEspecialidad";
            this.btnEliminarEspecialidad.Size = new System.Drawing.Size(75, 32);
            this.btnEliminarEspecialidad.TabIndex = 12;
            this.btnEliminarEspecialidad.Text = "&Eliminar";
            this.btnEliminarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarEspecialidad.UseVisualStyleBackColor = true;
            this.btnEliminarEspecialidad.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAñadirEspecialidad
            // 
            this.btnAñadirEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirEspecialidad.ImageIndex = 1;
            this.btnAñadirEspecialidad.ImageList = this.imageList1;
            this.btnAñadirEspecialidad.Location = new System.Drawing.Point(6, 2);
            this.btnAñadirEspecialidad.Name = "btnAñadirEspecialidad";
            this.btnAñadirEspecialidad.Size = new System.Drawing.Size(75, 32);
            this.btnAñadirEspecialidad.TabIndex = 11;
            this.btnAñadirEspecialidad.Text = "&Añadir";
            this.btnAñadirEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirEspecialidad.UseVisualStyleBackColor = true;
            this.btnAñadirEspecialidad.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditarESpecialidad
            // 
            this.btnEditarESpecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarESpecialidad.ImageIndex = 4;
            this.btnEditarESpecialidad.ImageList = this.imageList1;
            this.btnEditarESpecialidad.Location = new System.Drawing.Point(164, 2);
            this.btnEditarESpecialidad.Name = "btnEditarESpecialidad";
            this.btnEditarESpecialidad.Size = new System.Drawing.Size(75, 32);
            this.btnEditarESpecialidad.TabIndex = 10;
            this.btnEditarESpecialidad.Text = "&Editar";
            this.btnEditarESpecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarESpecialidad.UseVisualStyleBackColor = true;
            this.btnEditarESpecialidad.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardarEspecidalidad
            // 
            this.btnGuardarEspecidalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarEspecidalidad.ImageIndex = 0;
            this.btnGuardarEspecidalidad.ImageList = this.imageList1;
            this.btnGuardarEspecidalidad.Location = new System.Drawing.Point(85, 2);
            this.btnGuardarEspecidalidad.Name = "btnGuardarEspecidalidad";
            this.btnGuardarEspecidalidad.Size = new System.Drawing.Size(75, 32);
            this.btnGuardarEspecidalidad.TabIndex = 9;
            this.btnGuardarEspecidalidad.Text = "&Guardar";
            this.btnGuardarEspecidalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarEspecidalidad.UseVisualStyleBackColor = true;
            this.btnGuardarEspecidalidad.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVListadoEspecialidad);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(0, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 306);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Servicios Solicitados :";
            // 
            // dtGVListadoEspecialidad
            // 
            this.dtGVListadoEspecialidad.AllowUserToAddRows = false;
            this.dtGVListadoEspecialidad.AllowUserToResizeRows = false;
            this.dtGVListadoEspecialidad.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoEspecialidad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoEspecialidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoEspecialidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoEspecialidad,
            this.DGCNombreEspecialidad,
            this.DGCDescripcion});
            this.dtGVListadoEspecialidad.DataSource = this.bdSourceEspecialidades;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVListadoEspecialidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVListadoEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListadoEspecialidad.Location = new System.Drawing.Point(3, 16);
            this.dtGVListadoEspecialidad.Name = "dtGVListadoEspecialidad";
            this.dtGVListadoEspecialidad.ReadOnly = true;
            this.dtGVListadoEspecialidad.RowHeadersVisible = false;
            this.dtGVListadoEspecialidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListadoEspecialidad.Size = new System.Drawing.Size(547, 287);
            this.dtGVListadoEspecialidad.TabIndex = 0;
            // 
            // DGCCodigoEspecialidad
            // 
            this.DGCCodigoEspecialidad.DataPropertyName = "CodigoEspecialidad";
            this.DGCCodigoEspecialidad.HeaderText = "Código";
            this.DGCCodigoEspecialidad.Name = "DGCCodigoEspecialidad";
            this.DGCCodigoEspecialidad.ReadOnly = true;
            this.DGCCodigoEspecialidad.Width = 80;
            // 
            // DGCNombreEspecialidad
            // 
            this.DGCNombreEspecialidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombreEspecialidad.DataPropertyName = "NombreEspecialidad";
            this.DGCNombreEspecialidad.HeaderText = "Motivo Referencia";
            this.DGCNombreEspecialidad.Name = "DGCNombreEspecialidad";
            this.DGCNombreEspecialidad.ReadOnly = true;
            // 
            // DGCDescripcion
            // 
            this.DGCDescripcion.DataPropertyName = "Descripcion";
            this.DGCDescripcion.HeaderText = "Descripción";
            this.DGCDescripcion.Name = "DGCDescripcion";
            this.DGCDescripcion.ReadOnly = true;
            this.DGCDescripcion.Visible = false;
            // 
            // bdSourceEspecialidades
            // 
            this.bdSourceEspecialidades.CurrentChanged += new System.EventHandler(this.bdSourceEspecialidades_CurrentChanged);
            // 
            // FAñadirServicioSolicitado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(553, 471);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.gBoxDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAñadirServicioSolicitado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AÑADIR SERVICIOS SOLICITADOS";
            this.gBoxDatos.ResumeLayout(false);
            this.gBoxDatos.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoEspecialidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceEspecialidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCodigoEspecialidad;
        private System.Windows.Forms.TextBox TxtNombreEspecialidad;
        private System.Windows.Forms.GroupBox gBoxDatos;
        private System.Windows.Forms.RichTextBox TxtDescripcion;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCerrarEspecialidad;
        private System.Windows.Forms.Button btnEliminarEspecialidad;
        private System.Windows.Forms.Button btnAñadirEspecialidad;
        private System.Windows.Forms.Button btnEditarESpecialidad;
        private System.Windows.Forms.Button btnGuardarEspecidalidad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGVListadoEspecialidad;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource bdSourceEspecialidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDescripcion;
    }
}