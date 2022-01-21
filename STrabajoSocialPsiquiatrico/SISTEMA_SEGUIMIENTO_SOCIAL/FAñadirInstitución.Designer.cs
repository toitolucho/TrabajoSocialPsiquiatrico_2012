namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FAñadirInstitución
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAñadirInstitución));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCodigoUnidadMedica = new System.Windows.Forms.TextBox();
            this.TxtNombreUnidadMedica = new System.Windows.Forms.TextBox();
            this.TxtDireccionUnidadMedica = new System.Windows.Forms.TextBox();
            this.TxtTelefonoUnidadMedica = new System.Windows.Forms.TextBox();
            this.rTextBoxDescripcionUMedica = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditarUMedica = new System.Windows.Forms.Button();
            this.btnEliminarUMedica = new System.Windows.Forms.Button();
            this.btnCerrarUMedica = new System.Windows.Forms.Button();
            this.btnGuardarUMedica = new System.Windows.Forms.Button();
            this.btnAñadirUMedica = new System.Windows.Forms.Button();
            this.gBoxDetalle = new System.Windows.Forms.GroupBox();
            this.cBoxTipoUnidadMedica = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bdSourceUnidadesMedicas = new System.Windows.Forms.BindingSource(this.components);
            this.dGridViewListadoUnidadesMedicas = new System.Windows.Forms.DataGridView();
            this.DGCCodigoUnidadMedica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreUnidadMedica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDireccionUnidadMedica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTelefonoUnidadMedica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlBotones.SuspendLayout();
            this.gBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceUnidadesMedicas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridViewListadoUnidadesMedicas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(64, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Institución :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(60, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Institución :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(103, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dirección :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(106, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Teléfono :";
            // 
            // TxtCodigoUnidadMedica
            // 
            this.TxtCodigoUnidadMedica.Location = new System.Drawing.Point(167, 24);
            this.TxtCodigoUnidadMedica.Name = "TxtCodigoUnidadMedica";
            this.TxtCodigoUnidadMedica.ReadOnly = true;
            this.TxtCodigoUnidadMedica.Size = new System.Drawing.Size(83, 20);
            this.TxtCodigoUnidadMedica.TabIndex = 0;
            // 
            // TxtNombreUnidadMedica
            // 
            this.TxtNombreUnidadMedica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombreUnidadMedica.Location = new System.Drawing.Point(167, 50);
            this.TxtNombreUnidadMedica.Name = "TxtNombreUnidadMedica";
            this.TxtNombreUnidadMedica.Size = new System.Drawing.Size(388, 20);
            this.TxtNombreUnidadMedica.TabIndex = 1;
            // 
            // TxtDireccionUnidadMedica
            // 
            this.TxtDireccionUnidadMedica.Location = new System.Drawing.Point(167, 76);
            this.TxtDireccionUnidadMedica.Name = "TxtDireccionUnidadMedica";
            this.TxtDireccionUnidadMedica.Size = new System.Drawing.Size(388, 20);
            this.TxtDireccionUnidadMedica.TabIndex = 2;
            // 
            // TxtTelefonoUnidadMedica
            // 
            this.TxtTelefonoUnidadMedica.Location = new System.Drawing.Point(167, 102);
            this.TxtTelefonoUnidadMedica.Name = "TxtTelefonoUnidadMedica";
            this.TxtTelefonoUnidadMedica.Size = new System.Drawing.Size(180, 20);
            this.TxtTelefonoUnidadMedica.TabIndex = 3;
            // 
            // rTextBoxDescripcionUMedica
            // 
            this.rTextBoxDescripcionUMedica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTextBoxDescripcionUMedica.Location = new System.Drawing.Point(167, 155);
            this.rTextBoxDescripcionUMedica.Name = "rTextBoxDescripcionUMedica";
            this.rTextBoxDescripcionUMedica.Size = new System.Drawing.Size(306, 47);
            this.rTextBoxDescripcionUMedica.TabIndex = 5;
            this.rTextBoxDescripcionUMedica.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exit.png");
            this.imageList1.Images.SetKeyName(1, "wi0062-48.gif");
            this.imageList1.Images.SetKeyName(2, "Erase.png");
            this.imageList1.Images.SetKeyName(3, "Copia de Save file.png");
            this.imageList1.Images.SetKeyName(4, "edit_add.png");
            this.imageList1.Images.SetKeyName(5, "Undo.png");
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnEditarUMedica);
            this.pnlBotones.Controls.Add(this.btnEliminarUMedica);
            this.pnlBotones.Controls.Add(this.btnCerrarUMedica);
            this.pnlBotones.Controls.Add(this.btnGuardarUMedica);
            this.pnlBotones.Controls.Add(this.btnAñadirUMedica);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(5, 458);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(632, 36);
            this.pnlBotones.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 5;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(232, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(70, 29);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditarUMedica
            // 
            this.btnEditarUMedica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarUMedica.ImageIndex = 1;
            this.btnEditarUMedica.ImageList = this.imageList1;
            this.btnEditarUMedica.Location = new System.Drawing.Point(157, 3);
            this.btnEditarUMedica.Name = "btnEditarUMedica";
            this.btnEditarUMedica.Size = new System.Drawing.Size(70, 29);
            this.btnEditarUMedica.TabIndex = 2;
            this.btnEditarUMedica.Text = "&Editar";
            this.btnEditarUMedica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarUMedica.UseVisualStyleBackColor = true;
            this.btnEditarUMedica.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminarUMedica
            // 
            this.btnEliminarUMedica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarUMedica.ImageIndex = 2;
            this.btnEliminarUMedica.ImageList = this.imageList1;
            this.btnEliminarUMedica.Location = new System.Drawing.Point(307, 3);
            this.btnEliminarUMedica.Name = "btnEliminarUMedica";
            this.btnEliminarUMedica.Size = new System.Drawing.Size(70, 29);
            this.btnEliminarUMedica.TabIndex = 3;
            this.btnEliminarUMedica.Text = "&Eliminar";
            this.btnEliminarUMedica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarUMedica.UseVisualStyleBackColor = true;
            this.btnEliminarUMedica.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrarUMedica
            // 
            this.btnCerrarUMedica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarUMedica.ImageIndex = 0;
            this.btnCerrarUMedica.ImageList = this.imageList1;
            this.btnCerrarUMedica.Location = new System.Drawing.Point(547, 2);
            this.btnCerrarUMedica.Name = "btnCerrarUMedica";
            this.btnCerrarUMedica.Size = new System.Drawing.Size(70, 29);
            this.btnCerrarUMedica.TabIndex = 5;
            this.btnCerrarUMedica.Text = "&Cerrar";
            this.btnCerrarUMedica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarUMedica.UseVisualStyleBackColor = true;
            this.btnCerrarUMedica.Click += new System.EventHandler(this.btnCerrarAñadirDocumento_Click);
            // 
            // btnGuardarUMedica
            // 
            this.btnGuardarUMedica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarUMedica.ImageIndex = 3;
            this.btnGuardarUMedica.ImageList = this.imageList1;
            this.btnGuardarUMedica.Location = new System.Drawing.Point(82, 3);
            this.btnGuardarUMedica.Name = "btnGuardarUMedica";
            this.btnGuardarUMedica.Size = new System.Drawing.Size(70, 29);
            this.btnGuardarUMedica.TabIndex = 1;
            this.btnGuardarUMedica.Text = "&Guardar";
            this.btnGuardarUMedica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarUMedica.UseVisualStyleBackColor = true;
            this.btnGuardarUMedica.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnAñadirUMedica
            // 
            this.btnAñadirUMedica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirUMedica.ImageIndex = 4;
            this.btnAñadirUMedica.ImageList = this.imageList1;
            this.btnAñadirUMedica.Location = new System.Drawing.Point(7, 3);
            this.btnAñadirUMedica.Name = "btnAñadirUMedica";
            this.btnAñadirUMedica.Size = new System.Drawing.Size(70, 29);
            this.btnAñadirUMedica.TabIndex = 0;
            this.btnAñadirUMedica.Text = "&Añadir";
            this.btnAñadirUMedica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirUMedica.UseVisualStyleBackColor = true;
            this.btnAñadirUMedica.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // gBoxDetalle
            // 
            this.gBoxDetalle.Controls.Add(this.cBoxTipoUnidadMedica);
            this.gBoxDetalle.Controls.Add(this.label6);
            this.gBoxDetalle.Controls.Add(this.label4);
            this.gBoxDetalle.Controls.Add(this.rTextBoxDescripcionUMedica);
            this.gBoxDetalle.Controls.Add(this.label1);
            this.gBoxDetalle.Controls.Add(this.label2);
            this.gBoxDetalle.Controls.Add(this.label3);
            this.gBoxDetalle.Controls.Add(this.label5);
            this.gBoxDetalle.Controls.Add(this.TxtTelefonoUnidadMedica);
            this.gBoxDetalle.Controls.Add(this.TxtCodigoUnidadMedica);
            this.gBoxDetalle.Controls.Add(this.TxtDireccionUnidadMedica);
            this.gBoxDetalle.Controls.Add(this.TxtNombreUnidadMedica);
            this.gBoxDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDetalle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxDetalle.Location = new System.Drawing.Point(5, 5);
            this.gBoxDetalle.Name = "gBoxDetalle";
            this.gBoxDetalle.Size = new System.Drawing.Size(632, 218);
            this.gBoxDetalle.TabIndex = 0;
            this.gBoxDetalle.TabStop = false;
            this.gBoxDetalle.Text = "Introducción de Datos :";
            // 
            // cBoxTipoUnidadMedica
            // 
            this.cBoxTipoUnidadMedica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoUnidadMedica.FormattingEnabled = true;
            this.cBoxTipoUnidadMedica.Location = new System.Drawing.Point(167, 128);
            this.cBoxTipoUnidadMedica.Name = "cBoxTipoUnidadMedica";
            this.cBoxTipoUnidadMedica.Size = new System.Drawing.Size(180, 21);
            this.cBoxTipoUnidadMedica.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(127, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tipo :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(92, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Descripción :";
            // 
            // bdSourceUnidadesMedicas
            // 
            this.bdSourceUnidadesMedicas.CurrentChanged += new System.EventHandler(this.bdSourceUnidadesMedicas_CurrentChanged);
            // 
            // dGridViewListadoUnidadesMedicas
            // 
            this.dGridViewListadoUnidadesMedicas.AllowUserToAddRows = false;
            this.dGridViewListadoUnidadesMedicas.AllowUserToResizeRows = false;
            this.dGridViewListadoUnidadesMedicas.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridViewListadoUnidadesMedicas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridViewListadoUnidadesMedicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridViewListadoUnidadesMedicas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoUnidadMedica,
            this.DGCNombreUnidadMedica,
            this.DGCDireccionUnidadMedica,
            this.DGCTelefonoUnidadMedica});
            this.dGridViewListadoUnidadesMedicas.DataSource = this.bdSourceUnidadesMedicas;
            this.dGridViewListadoUnidadesMedicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGridViewListadoUnidadesMedicas.Location = new System.Drawing.Point(3, 16);
            this.dGridViewListadoUnidadesMedicas.Name = "dGridViewListadoUnidadesMedicas";
            this.dGridViewListadoUnidadesMedicas.ReadOnly = true;
            this.dGridViewListadoUnidadesMedicas.RowHeadersVisible = false;
            this.dGridViewListadoUnidadesMedicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridViewListadoUnidadesMedicas.Size = new System.Drawing.Size(626, 216);
            this.dGridViewListadoUnidadesMedicas.TabIndex = 0;
            // 
            // DGCCodigoUnidadMedica
            // 
            this.DGCCodigoUnidadMedica.DataPropertyName = "CodigoUnidadMedica";
            this.DGCCodigoUnidadMedica.HeaderText = "Código";
            this.DGCCodigoUnidadMedica.Name = "DGCCodigoUnidadMedica";
            this.DGCCodigoUnidadMedica.ReadOnly = true;
            this.DGCCodigoUnidadMedica.Width = 65;
            // 
            // DGCNombreUnidadMedica
            // 
            this.DGCNombreUnidadMedica.DataPropertyName = "NombreUnidadMedica";
            this.DGCNombreUnidadMedica.HeaderText = "Nombre de la Institución";
            this.DGCNombreUnidadMedica.Name = "DGCNombreUnidadMedica";
            this.DGCNombreUnidadMedica.ReadOnly = true;
            this.DGCNombreUnidadMedica.Width = 350;
            // 
            // DGCDireccionUnidadMedica
            // 
            this.DGCDireccionUnidadMedica.DataPropertyName = "DireccionUnidadMedica";
            this.DGCDireccionUnidadMedica.HeaderText = "Dirección";
            this.DGCDireccionUnidadMedica.Name = "DGCDireccionUnidadMedica";
            this.DGCDireccionUnidadMedica.ReadOnly = true;
            this.DGCDireccionUnidadMedica.Width = 200;
            // 
            // DGCTelefonoUnidadMedica
            // 
            this.DGCTelefonoUnidadMedica.DataPropertyName = "TelefonoUnidadMedica";
            this.DGCTelefonoUnidadMedica.HeaderText = "Teléfono";
            this.DGCTelefonoUnidadMedica.Name = "DGCTelefonoUnidadMedica";
            this.DGCTelefonoUnidadMedica.ReadOnly = true;
            this.DGCTelefonoUnidadMedica.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dGridViewListadoUnidadesMedicas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(5, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 235);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Instituciones :";
            // 
            // FAñadirInstitución
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(642, 499);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBoxDetalle);
            this.Controls.Add(this.pnlBotones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAñadirInstitución";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AÑADIR INSTITUCIONES";
            this.pnlBotones.ResumeLayout(false);
            this.gBoxDetalle.ResumeLayout(false);
            this.gBoxDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceUnidadesMedicas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridViewListadoUnidadesMedicas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCodigoUnidadMedica;
        private System.Windows.Forms.TextBox TxtNombreUnidadMedica;
        private System.Windows.Forms.TextBox TxtDireccionUnidadMedica;
        private System.Windows.Forms.TextBox TxtTelefonoUnidadMedica;
        private System.Windows.Forms.RichTextBox rTextBoxDescripcionUMedica;
        private System.Windows.Forms.Button btnGuardarUMedica;
        private System.Windows.Forms.Button btnAñadirUMedica;
        private System.Windows.Forms.Button btnCerrarUMedica;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.GroupBox gBoxDetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEditarUMedica;
        private System.Windows.Forms.Button btnEliminarUMedica;
        private System.Windows.Forms.BindingSource bdSourceUnidadesMedicas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dGridViewListadoUnidadesMedicas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cBoxTipoUnidadMedica;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoUnidadMedica;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreUnidadMedica;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDireccionUnidadMedica;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTelefonoUnidadMedica;
    }
}