namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDocumentos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxHistorialClinico = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAnadirDocumentos = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cBoxNombreDocumento = new System.Windows.Forms.ComboBox();
            this.rbtnNoTramitoTSocial = new System.Windows.Forms.RadioButton();
            this.rbtnSiTramitoTSocial = new System.Windows.Forms.RadioButton();
            this.dateFechaRegistroDoc = new System.Windows.Forms.DateTimePicker();
            this.TxtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.TxtNumeroPaciente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAnadirDocumento = new System.Windows.Forms.Button();
            this.btnGuardarDocumento = new System.Windows.Forms.Button();
            this.btnCerrarDocumento = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVListadoDocumento = new System.Windows.Forms.DataGridView();
            this.bdSourceDocumentosPacientes = new System.Windows.Forms.BindingSource(this.components);
            this.DGCNumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreDocumento = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DGCFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTramitoTrabSocial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceDocumentosPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxHistorialClinico);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAnadirDocumentos);
            this.groupBox1.Controls.Add(this.cBoxNombreDocumento);
            this.groupBox1.Controls.Add(this.rbtnNoTramitoTSocial);
            this.groupBox1.Controls.Add(this.rbtnSiTramitoTSocial);
            this.groupBox1.Controls.Add(this.dateFechaRegistroDoc);
            this.groupBox1.Controls.Add(this.TxtNumeroDocumento);
            this.groupBox1.Controls.Add(this.TxtNumeroPaciente);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Introducción de Datos :";
            // 
            // txtBoxHistorialClinico
            // 
            this.txtBoxHistorialClinico.Location = new System.Drawing.Point(142, 24);
            this.txtBoxHistorialClinico.Name = "txtBoxHistorialClinico";
            this.txtBoxHistorialClinico.ReadOnly = true;
            this.txtBoxHistorialClinico.Size = new System.Drawing.Size(65, 20);
            this.txtBoxHistorialClinico.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(102, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "H.C. :";
            // 
            // btnAnadirDocumentos
            // 
            this.btnAnadirDocumentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnadirDocumentos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAnadirDocumentos.ImageIndex = 6;
            this.btnAnadirDocumentos.ImageList = this.imageList1;
            this.btnAnadirDocumentos.Location = new System.Drawing.Point(436, 79);
            this.btnAnadirDocumentos.Name = "btnAnadirDocumentos";
            this.btnAnadirDocumentos.Size = new System.Drawing.Size(28, 25);
            this.btnAnadirDocumentos.TabIndex = 15;
            this.btnAnadirDocumentos.UseVisualStyleBackColor = true;
            this.btnAnadirDocumentos.Click += new System.EventHandler(this.btnAnadirDocumentos_Click);
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
            this.imageList1.Images.SetKeyName(5, "viewmag.png");
            this.imageList1.Images.SetKeyName(6, "web.png");
            this.imageList1.Images.SetKeyName(7, "wi0062-48.gif");
            // 
            // cBoxNombreDocumento
            // 
            this.cBoxNombreDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBoxNombreDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBoxNombreDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxNombreDocumento.FormattingEnabled = true;
            this.cBoxNombreDocumento.Location = new System.Drawing.Point(142, 82);
            this.cBoxNombreDocumento.Name = "cBoxNombreDocumento";
            this.cBoxNombreDocumento.Size = new System.Drawing.Size(293, 21);
            this.cBoxNombreDocumento.TabIndex = 14;
            // 
            // rbtnNoTramitoTSocial
            // 
            this.rbtnNoTramitoTSocial.AutoSize = true;
            this.rbtnNoTramitoTSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnNoTramitoTSocial.Location = new System.Drawing.Point(193, 113);
            this.rbtnNoTramitoTSocial.Name = "rbtnNoTramitoTSocial";
            this.rbtnNoTramitoTSocial.Size = new System.Drawing.Size(39, 17);
            this.rbtnNoTramitoTSocial.TabIndex = 12;
            this.rbtnNoTramitoTSocial.TabStop = true;
            this.rbtnNoTramitoTSocial.Text = "No";
            this.rbtnNoTramitoTSocial.UseVisualStyleBackColor = true;
            // 
            // rbtnSiTramitoTSocial
            // 
            this.rbtnSiTramitoTSocial.AutoSize = true;
            this.rbtnSiTramitoTSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnSiTramitoTSocial.Location = new System.Drawing.Point(142, 113);
            this.rbtnSiTramitoTSocial.Name = "rbtnSiTramitoTSocial";
            this.rbtnSiTramitoTSocial.Size = new System.Drawing.Size(34, 17);
            this.rbtnSiTramitoTSocial.TabIndex = 11;
            this.rbtnSiTramitoTSocial.TabStop = true;
            this.rbtnSiTramitoTSocial.Text = "Si";
            this.rbtnSiTramitoTSocial.UseVisualStyleBackColor = true;
            // 
            // dateFechaRegistroDoc
            // 
            this.dateFechaRegistroDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaRegistroDoc.Location = new System.Drawing.Point(142, 53);
            this.dateFechaRegistroDoc.Name = "dateFechaRegistroDoc";
            this.dateFechaRegistroDoc.Size = new System.Drawing.Size(103, 20);
            this.dateFechaRegistroDoc.TabIndex = 8;
            // 
            // TxtNumeroDocumento
            // 
            this.TxtNumeroDocumento.Location = new System.Drawing.Point(387, 24);
            this.TxtNumeroDocumento.Name = "TxtNumeroDocumento";
            this.TxtNumeroDocumento.ReadOnly = true;
            this.TxtNumeroDocumento.Size = new System.Drawing.Size(66, 20);
            this.TxtNumeroDocumento.TabIndex = 7;
            // 
            // TxtNumeroPaciente
            // 
            this.TxtNumeroPaciente.Location = new System.Drawing.Point(441, 46);
            this.TxtNumeroPaciente.Name = "TxtNumeroPaciente";
            this.TxtNumeroPaciente.ReadOnly = true;
            this.TxtNumeroPaciente.Size = new System.Drawing.Size(65, 20);
            this.TxtNumeroPaciente.TabIndex = 6;
            this.TxtNumeroPaciente.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(17, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tramitó Trabajo Social :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(28, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre Documento :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(51, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Registro :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(239, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nº Documento del Paciente :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(365, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº Paciente :";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.btnAnadirDocumento);
            this.panel1.Controls.Add(this.btnGuardarDocumento);
            this.panel1.Controls.Add(this.btnCerrarDocumento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 39);
            this.panel1.TabIndex = 15;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 4;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(327, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Ca&ncelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.ImageIndex = 1;
            this.btnEliminar.ImageList = this.imageList1;
            this.btnEliminar.Location = new System.Drawing.Point(248, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 32);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.ImageIndex = 7;
            this.btnModificar.ImageList = this.imageList1;
            this.btnModificar.Location = new System.Drawing.Point(169, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 32);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "&Editar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAnadirDocumento
            // 
            this.btnAnadirDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnadirDocumento.ImageIndex = 0;
            this.btnAnadirDocumento.ImageList = this.imageList1;
            this.btnAnadirDocumento.Location = new System.Drawing.Point(11, 3);
            this.btnAnadirDocumento.Name = "btnAnadirDocumento";
            this.btnAnadirDocumento.Size = new System.Drawing.Size(75, 32);
            this.btnAnadirDocumento.TabIndex = 8;
            this.btnAnadirDocumento.Text = "&Añadir";
            this.btnAnadirDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnadirDocumento.UseVisualStyleBackColor = true;
            this.btnAnadirDocumento.Click += new System.EventHandler(this.btnAnadirDocumento_Click);
            // 
            // btnGuardarDocumento
            // 
            this.btnGuardarDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarDocumento.ImageIndex = 2;
            this.btnGuardarDocumento.ImageList = this.imageList1;
            this.btnGuardarDocumento.Location = new System.Drawing.Point(90, 3);
            this.btnGuardarDocumento.Name = "btnGuardarDocumento";
            this.btnGuardarDocumento.Size = new System.Drawing.Size(75, 32);
            this.btnGuardarDocumento.TabIndex = 6;
            this.btnGuardarDocumento.Text = "&Guardar";
            this.btnGuardarDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarDocumento.UseVisualStyleBackColor = true;
            this.btnGuardarDocumento.Click += new System.EventHandler(this.btnGuardarDocumento_Click);
            // 
            // btnCerrarDocumento
            // 
            this.btnCerrarDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarDocumento.ImageIndex = 3;
            this.btnCerrarDocumento.ImageList = this.imageList1;
            this.btnCerrarDocumento.Location = new System.Drawing.Point(450, 3);
            this.btnCerrarDocumento.Name = "btnCerrarDocumento";
            this.btnCerrarDocumento.Size = new System.Drawing.Size(75, 32);
            this.btnCerrarDocumento.TabIndex = 7;
            this.btnCerrarDocumento.Text = "&Cerrar";
            this.btnCerrarDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarDocumento.UseVisualStyleBackColor = true;
            this.btnCerrarDocumento.Click += new System.EventHandler(this.btnCerrarDocumento_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVListadoDocumento);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(0, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(532, 257);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Documentos :";
            // 
            // dtGVListadoDocumento
            // 
            this.dtGVListadoDocumento.AllowUserToAddRows = false;
            this.dtGVListadoDocumento.AllowUserToResizeRows = false;
            this.dtGVListadoDocumento.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoDocumento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoDocumento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNumeroDocumento,
            this.DGCNombreDocumento,
            this.DGCFechaRegistro,
            this.DGCTramitoTrabSocial});
            this.dtGVListadoDocumento.DataSource = this.bdSourceDocumentosPacientes;
            this.dtGVListadoDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListadoDocumento.Location = new System.Drawing.Point(3, 16);
            this.dtGVListadoDocumento.Name = "dtGVListadoDocumento";
            this.dtGVListadoDocumento.ReadOnly = true;
            this.dtGVListadoDocumento.RowHeadersVisible = false;
            this.dtGVListadoDocumento.RowTemplate.Height = 24;
            this.dtGVListadoDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListadoDocumento.Size = new System.Drawing.Size(526, 238);
            this.dtGVListadoDocumento.TabIndex = 0;
            this.dtGVListadoDocumento.SelectionChanged += new System.EventHandler(this.dtGVListadoDocumento_SelectionChanged);
            // 
            // DGCNumeroDocumento
            // 
            this.DGCNumeroDocumento.DataPropertyName = "NumeroDocumento";
            this.DGCNumeroDocumento.HeaderText = "Nº Documento";
            this.DGCNumeroDocumento.Name = "DGCNumeroDocumento";
            this.DGCNumeroDocumento.ReadOnly = true;
            this.DGCNumeroDocumento.Visible = false;
            // 
            // DGCNombreDocumento
            // 
            this.DGCNombreDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombreDocumento.DataPropertyName = "NombreDocumento";
            this.DGCNombreDocumento.HeaderText = "Documento";
            this.DGCNombreDocumento.Name = "DGCNombreDocumento";
            this.DGCNombreDocumento.ReadOnly = true;
            this.DGCNombreDocumento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCNombreDocumento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DGCFechaRegistro
            // 
            this.DGCFechaRegistro.DataPropertyName = "FechaRegistro";
            this.DGCFechaRegistro.HeaderText = "Fecha Reg.";
            this.DGCFechaRegistro.Name = "DGCFechaRegistro";
            this.DGCFechaRegistro.ReadOnly = true;
            this.DGCFechaRegistro.Width = 90;
            // 
            // DGCTramitoTrabSocial
            // 
            this.DGCTramitoTrabSocial.DataPropertyName = "TramitoTrabSocial";
            this.DGCTramitoTrabSocial.FalseValue = "N";
            this.DGCTramitoTrabSocial.HeaderText = "Tramito Trab Social";
            this.DGCTramitoTrabSocial.Name = "DGCTramitoTrabSocial";
            this.DGCTramitoTrabSocial.ReadOnly = true;
            this.DGCTramitoTrabSocial.TrueValue = "S";
            // 
            // FDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(532, 441);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOCUMENTOS CON QUE CUENTA EL PACIENTE";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceDocumentosPacientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCerrarDocumento;
        private System.Windows.Forms.Button btnGuardarDocumento;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnNoTramitoTSocial;
        private System.Windows.Forms.RadioButton rbtnSiTramitoTSocial;
        private System.Windows.Forms.DateTimePicker dateFechaRegistroDoc;
        private System.Windows.Forms.TextBox TxtNumeroDocumento;
        private System.Windows.Forms.TextBox TxtNumeroPaciente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnadirDocumentos;
        private System.Windows.Forms.ComboBox cBoxNombreDocumento;
        private System.Windows.Forms.Button btnAnadirDocumento;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGVListadoDocumento;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.BindingSource bdSourceDocumentosPacientes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtBoxHistorialClinico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNumeroDocumento;
        private System.Windows.Forms.DataGridViewComboBoxColumn DGCNombreDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaRegistro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCTramitoTrabSocial;
    }
}