namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FAñadirDocumentosTipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAñadirDocumentosTipo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCodigoTipoDocumento = new System.Windows.Forms.TextBox();
            this.TxtNombreDocumento = new System.Windows.Forms.TextBox();
            this.gBoxDetalle = new System.Windows.Forms.GroupBox();
            this.rTextBoxDescripcionDocumento = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCerrarDocumento = new System.Windows.Forms.Button();
            this.btnEliminarDocumento = new System.Windows.Forms.Button();
            this.btnAñadirDocumento = new System.Windows.Forms.Button();
            this.btnEditarDocumento = new System.Windows.Forms.Button();
            this.btnGuardarDocumento = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVListadoDocumentos = new System.Windows.Forms.DataGridView();
            this.DGCCodigoDocumentoTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdSourceDocumentosTipos = new System.Windows.Forms.BindingSource(this.components);
            this.gBoxDetalle.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceDocumentosTipos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(62, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cod. Tipo Documento :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(71, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Documento :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(110, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción :";
            // 
            // TxtCodigoTipoDocumento
            // 
            this.TxtCodigoTipoDocumento.Location = new System.Drawing.Point(185, 25);
            this.TxtCodigoTipoDocumento.Name = "TxtCodigoTipoDocumento";
            this.TxtCodigoTipoDocumento.ReadOnly = true;
            this.TxtCodigoTipoDocumento.Size = new System.Drawing.Size(64, 20);
            this.TxtCodigoTipoDocumento.TabIndex = 3;
            // 
            // TxtNombreDocumento
            // 
            this.TxtNombreDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombreDocumento.Location = new System.Drawing.Point(185, 55);
            this.TxtNombreDocumento.Name = "TxtNombreDocumento";
            this.TxtNombreDocumento.Size = new System.Drawing.Size(296, 20);
            this.TxtNombreDocumento.TabIndex = 4;
            // 
            // gBoxDetalle
            // 
            this.gBoxDetalle.Controls.Add(this.rTextBoxDescripcionDocumento);
            this.gBoxDetalle.Controls.Add(this.TxtCodigoTipoDocumento);
            this.gBoxDetalle.Controls.Add(this.label1);
            this.gBoxDetalle.Controls.Add(this.TxtNombreDocumento);
            this.gBoxDetalle.Controls.Add(this.label2);
            this.gBoxDetalle.Controls.Add(this.label3);
            this.gBoxDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDetalle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxDetalle.Location = new System.Drawing.Point(0, 0);
            this.gBoxDetalle.Name = "gBoxDetalle";
            this.gBoxDetalle.Size = new System.Drawing.Size(565, 151);
            this.gBoxDetalle.TabIndex = 6;
            this.gBoxDetalle.TabStop = false;
            this.gBoxDetalle.Text = "Introducción de Datos";
            // 
            // rTextBoxDescripcionDocumento
            // 
            this.rTextBoxDescripcionDocumento.Location = new System.Drawing.Point(185, 85);
            this.rTextBoxDescripcionDocumento.Name = "rTextBoxDescripcionDocumento";
            this.rTextBoxDescripcionDocumento.Size = new System.Drawing.Size(296, 53);
            this.rTextBoxDescripcionDocumento.TabIndex = 5;
            this.rTextBoxDescripcionDocumento.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Erase.png");
            this.imageList1.Images.SetKeyName(1, "Yes v3.png");
            this.imageList1.Images.SetKeyName(2, "exit.png");
            this.imageList1.Images.SetKeyName(3, "Copia de Save file.png");
            this.imageList1.Images.SetKeyName(4, "edit_add.png");
            this.imageList1.Images.SetKeyName(5, "Erase.png");
            this.imageList1.Images.SetKeyName(6, "wi0062-48.gif");
            this.imageList1.Images.SetKeyName(7, "Undo.png");
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnCerrarDocumento);
            this.pnlBotones.Controls.Add(this.btnEliminarDocumento);
            this.pnlBotones.Controls.Add(this.btnAñadirDocumento);
            this.pnlBotones.Controls.Add(this.btnEditarDocumento);
            this.pnlBotones.Controls.Add(this.btnGuardarDocumento);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 399);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(565, 39);
            this.pnlBotones.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 7;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(234, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCerrarDocumento
            // 
            this.btnCerrarDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarDocumento.ImageIndex = 2;
            this.btnCerrarDocumento.ImageList = this.imageList1;
            this.btnCerrarDocumento.Location = new System.Drawing.Point(479, 3);
            this.btnCerrarDocumento.Name = "btnCerrarDocumento";
            this.btnCerrarDocumento.Size = new System.Drawing.Size(75, 32);
            this.btnCerrarDocumento.TabIndex = 13;
            this.btnCerrarDocumento.Text = "&Cerrar";
            this.btnCerrarDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarDocumento.UseVisualStyleBackColor = true;
            this.btnCerrarDocumento.Click += new System.EventHandler(this.btnCerrarAñadirDocumento_Click);
            // 
            // btnEliminarDocumento
            // 
            this.btnEliminarDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarDocumento.ImageIndex = 0;
            this.btnEliminarDocumento.ImageList = this.imageList1;
            this.btnEliminarDocumento.Location = new System.Drawing.Point(310, 3);
            this.btnEliminarDocumento.Name = "btnEliminarDocumento";
            this.btnEliminarDocumento.Size = new System.Drawing.Size(75, 32);
            this.btnEliminarDocumento.TabIndex = 12;
            this.btnEliminarDocumento.Text = "&Eliminar";
            this.btnEliminarDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarDocumento.UseVisualStyleBackColor = true;
            this.btnEliminarDocumento.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAñadirDocumento
            // 
            this.btnAñadirDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirDocumento.ImageIndex = 4;
            this.btnAñadirDocumento.ImageList = this.imageList1;
            this.btnAñadirDocumento.Location = new System.Drawing.Point(6, 3);
            this.btnAñadirDocumento.Name = "btnAñadirDocumento";
            this.btnAñadirDocumento.Size = new System.Drawing.Size(75, 32);
            this.btnAñadirDocumento.TabIndex = 11;
            this.btnAñadirDocumento.Text = "&Añadir";
            this.btnAñadirDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirDocumento.UseVisualStyleBackColor = true;
            this.btnAñadirDocumento.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditarDocumento
            // 
            this.btnEditarDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarDocumento.ImageIndex = 6;
            this.btnEditarDocumento.ImageList = this.imageList1;
            this.btnEditarDocumento.Location = new System.Drawing.Point(158, 3);
            this.btnEditarDocumento.Name = "btnEditarDocumento";
            this.btnEditarDocumento.Size = new System.Drawing.Size(75, 32);
            this.btnEditarDocumento.TabIndex = 10;
            this.btnEditarDocumento.Text = "&Editar";
            this.btnEditarDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarDocumento.UseVisualStyleBackColor = true;
            this.btnEditarDocumento.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardarDocumento
            // 
            this.btnGuardarDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarDocumento.ImageIndex = 3;
            this.btnGuardarDocumento.ImageList = this.imageList1;
            this.btnGuardarDocumento.Location = new System.Drawing.Point(82, 3);
            this.btnGuardarDocumento.Name = "btnGuardarDocumento";
            this.btnGuardarDocumento.Size = new System.Drawing.Size(75, 32);
            this.btnGuardarDocumento.TabIndex = 9;
            this.btnGuardarDocumento.Text = "&Guardar";
            this.btnGuardarDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarDocumento.UseVisualStyleBackColor = true;
            this.btnGuardarDocumento.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVListadoDocumentos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(0, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 248);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Documentos :";
            // 
            // dtGVListadoDocumentos
            // 
            this.dtGVListadoDocumentos.AllowUserToAddRows = false;
            this.dtGVListadoDocumentos.AllowUserToResizeRows = false;
            this.dtGVListadoDocumentos.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoDocumentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoDocumentoTipo,
            this.DGCNombreDocumento,
            this.DGCDescripcion});
            this.dtGVListadoDocumentos.DataSource = this.bdSourceDocumentosTipos;
            this.dtGVListadoDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListadoDocumentos.Location = new System.Drawing.Point(3, 16);
            this.dtGVListadoDocumentos.Name = "dtGVListadoDocumentos";
            this.dtGVListadoDocumentos.ReadOnly = true;
            this.dtGVListadoDocumentos.RowHeadersVisible = false;
            this.dtGVListadoDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListadoDocumentos.Size = new System.Drawing.Size(559, 229);
            this.dtGVListadoDocumentos.TabIndex = 0;
            // 
            // DGCCodigoDocumentoTipo
            // 
            this.DGCCodigoDocumentoTipo.DataPropertyName = "CodigoDocumentoTipo";
            this.DGCCodigoDocumentoTipo.HeaderText = "Codigo";
            this.DGCCodigoDocumentoTipo.Name = "DGCCodigoDocumentoTipo";
            this.DGCCodigoDocumentoTipo.ReadOnly = true;
            this.DGCCodigoDocumentoTipo.Width = 75;
            // 
            // DGCNombreDocumento
            // 
            this.DGCNombreDocumento.DataPropertyName = "NombreDocumento";
            this.DGCNombreDocumento.HeaderText = "Nombre";
            this.DGCNombreDocumento.Name = "DGCNombreDocumento";
            this.DGCNombreDocumento.ReadOnly = true;
            this.DGCNombreDocumento.Width = 300;
            // 
            // DGCDescripcion
            // 
            this.DGCDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCDescripcion.DataPropertyName = "Descripcion";
            this.DGCDescripcion.HeaderText = "Descripción";
            this.DGCDescripcion.Name = "DGCDescripcion";
            this.DGCDescripcion.ReadOnly = true;
            // 
            // bdSourceDocumentosTipos
            // 
            this.bdSourceDocumentosTipos.CurrentChanged += new System.EventHandler(this.bdSourceDocumentosTipos_CurrentChanged);
            // 
            // FAñadirDocumentosTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(565, 438);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.gBoxDetalle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAñadirDocumentosTipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AÑADIR TIPO DE DOCUMENTOS";
            this.gBoxDetalle.ResumeLayout(false);
            this.gBoxDetalle.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceDocumentosTipos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCodigoTipoDocumento;
        private System.Windows.Forms.TextBox TxtNombreDocumento;
        private System.Windows.Forms.GroupBox gBoxDetalle;
        private System.Windows.Forms.RichTextBox rTextBoxDescripcionDocumento;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnEditarDocumento;
        private System.Windows.Forms.Button btnGuardarDocumento;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnAñadirDocumento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGVListadoDocumentos;
        private System.Windows.Forms.Button btnCerrarDocumento;
        private System.Windows.Forms.Button btnEliminarDocumento;
        private System.Windows.Forms.BindingSource bdSourceDocumentosTipos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoDocumentoTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDescripcion;
    }
}