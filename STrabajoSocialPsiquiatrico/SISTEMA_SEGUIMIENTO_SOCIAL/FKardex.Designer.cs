namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FKardex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FKardex));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TxtInformacionKardex = new System.Windows.Forms.TextBox();
            this.cBoxBuscarPor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVListadoPaciente = new System.Windows.Forms.DataGridView();
            this.DGCHClinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNumeroPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSeccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CRVKardexPaciente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TxtNombrePacienteKardex = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoPaciente)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Por :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.TxtInformacionKardex);
            this.groupBox1.Controls.Add(this.cBoxBuscarPor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(10, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 121);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda de Pacientes";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImageIndex = 1;
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(197, 73);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 31);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exit.png");
            this.imageList1.Images.SetKeyName(1, "viewmag.png");
            // 
            // TxtInformacionKardex
            // 
            this.TxtInformacionKardex.Location = new System.Drawing.Point(83, 52);
            this.TxtInformacionKardex.Name = "TxtInformacionKardex";
            this.TxtInformacionKardex.Size = new System.Drawing.Size(194, 20);
            this.TxtInformacionKardex.TabIndex = 3;
            this.TxtInformacionKardex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInformacionKardex_KeyDown);
            // 
            // cBoxBuscarPor
            // 
            this.cBoxBuscarPor.FormattingEnabled = true;
            this.cBoxBuscarPor.Items.AddRange(new object[] {
            "Historial Clinico",
            "Nombre/s",
            "Apellido Paterno",
            "Apellido Materno",
            "Unidad",
            "Seccion"});
            this.cBoxBuscarPor.Location = new System.Drawing.Point(83, 25);
            this.cBoxBuscarPor.Name = "cBoxBuscarPor";
            this.cBoxBuscarPor.Size = new System.Drawing.Size(194, 21);
            this.cBoxBuscarPor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Información :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVListadoPaciente);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(304, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 121);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione el  Paciente";
            // 
            // dtGVListadoPaciente
            // 
            this.dtGVListadoPaciente.AllowUserToAddRows = false;
            this.dtGVListadoPaciente.AllowUserToDeleteRows = false;
            this.dtGVListadoPaciente.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoPaciente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoPaciente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCHClinico,
            this.DGCNumeroPaciente,
            this.DGCNombre,
            this.DGCApellidoPaterno,
            this.DGCApellidoMaterno,
            this.DGCUnidad,
            this.DGCSeccion});
            this.dtGVListadoPaciente.Location = new System.Drawing.Point(6, 15);
            this.dtGVListadoPaciente.MultiSelect = false;
            this.dtGVListadoPaciente.Name = "dtGVListadoPaciente";
            this.dtGVListadoPaciente.ReadOnly = true;
            this.dtGVListadoPaciente.RowHeadersVisible = false;
            this.dtGVListadoPaciente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListadoPaciente.Size = new System.Drawing.Size(634, 100);
            this.dtGVListadoPaciente.TabIndex = 4;
            this.dtGVListadoPaciente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVListadoPaciente_CellContentDoubleClick);
            // 
            // DGCHClinico
            // 
            this.DGCHClinico.DataPropertyName = "HClinico";
            this.DGCHClinico.HeaderText = "H. Clínica";
            this.DGCHClinico.Name = "DGCHClinico";
            this.DGCHClinico.ReadOnly = true;
            this.DGCHClinico.Width = 80;
            // 
            // DGCNumeroPaciente
            // 
            this.DGCNumeroPaciente.DataPropertyName = "NumeroPaciente";
            this.DGCNumeroPaciente.HeaderText = "Nº";
            this.DGCNumeroPaciente.Name = "DGCNumeroPaciente";
            this.DGCNumeroPaciente.ReadOnly = true;
            this.DGCNumeroPaciente.Visible = false;
            // 
            // DGCNombre
            // 
            this.DGCNombre.DataPropertyName = "Nombre";
            this.DGCNombre.HeaderText = "Nombre del Paciente";
            this.DGCNombre.Name = "DGCNombre";
            this.DGCNombre.ReadOnly = true;
            this.DGCNombre.Width = 150;
            // 
            // DGCApellidoPaterno
            // 
            this.DGCApellidoPaterno.DataPropertyName = "ApellidoPaterno";
            this.DGCApellidoPaterno.HeaderText = "Apellido Paterno";
            this.DGCApellidoPaterno.Name = "DGCApellidoPaterno";
            this.DGCApellidoPaterno.ReadOnly = true;
            // 
            // DGCApellidoMaterno
            // 
            this.DGCApellidoMaterno.DataPropertyName = "ApellidoMaterno";
            this.DGCApellidoMaterno.HeaderText = "Apellido Materno";
            this.DGCApellidoMaterno.Name = "DGCApellidoMaterno";
            this.DGCApellidoMaterno.ReadOnly = true;
            // 
            // DGCUnidad
            // 
            this.DGCUnidad.DataPropertyName = "Unidad";
            this.DGCUnidad.HeaderText = "Unidad";
            this.DGCUnidad.Name = "DGCUnidad";
            this.DGCUnidad.ReadOnly = true;
            // 
            // DGCSeccion
            // 
            this.DGCSeccion.DataPropertyName = "Seccion";
            this.DGCSeccion.HeaderText = "Sección";
            this.DGCSeccion.Name = "DGCSeccion";
            this.DGCSeccion.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(217, 397);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 42);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(217, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 37);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 548);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(962, 40);
            this.panel3.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 0;
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(882, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 31);
            this.button3.TabIndex = 1;
            this.button3.Text = "&Cerrar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Paciente :";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(1, 163);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 393);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CRVKardexPaciente);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(952, 367);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vista Previa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CRVKardexPaciente
            // 
            this.CRVKardexPaciente.ActiveViewIndex = -1;
            this.CRVKardexPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVKardexPaciente.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVKardexPaciente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVKardexPaciente.Location = new System.Drawing.Point(3, 3);
            this.CRVKardexPaciente.Name = "CRVKardexPaciente";
            this.CRVKardexPaciente.ShowGroupTreeButton = false;
            this.CRVKardexPaciente.ShowParameterPanelButton = false;
            this.CRVKardexPaciente.ShowRefreshButton = false;
            this.CRVKardexPaciente.Size = new System.Drawing.Size(946, 361);
            this.CRVKardexPaciente.TabIndex = 0;
            this.CRVKardexPaciente.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // TxtNombrePacienteKardex
            // 
            this.TxtNombrePacienteKardex.BackColor = System.Drawing.Color.SteelBlue;
            this.TxtNombrePacienteKardex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombrePacienteKardex.ForeColor = System.Drawing.SystemColors.Window;
            this.TxtNombrePacienteKardex.Location = new System.Drawing.Point(173, 10);
            this.TxtNombrePacienteKardex.Name = "TxtNombrePacienteKardex";
            this.TxtNombrePacienteKardex.Size = new System.Drawing.Size(666, 20);
            this.TxtNombrePacienteKardex.TabIndex = 9;
            // 
            // FKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(962, 588);
            this.Controls.Add(this.TxtNombrePacienteKardex);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FKardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KARDEX DE PACIENTES";
            this.Shown += new System.EventHandler(this.FKardex_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoPaciente)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox TxtInformacionKardex;
        private System.Windows.Forms.ComboBox cBoxBuscarPor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtGVListadoPaciente;
        public System.Windows.Forms.TextBox TxtNombrePacienteKardex;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVKardexPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCHClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNumeroPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSeccion;
    }
}