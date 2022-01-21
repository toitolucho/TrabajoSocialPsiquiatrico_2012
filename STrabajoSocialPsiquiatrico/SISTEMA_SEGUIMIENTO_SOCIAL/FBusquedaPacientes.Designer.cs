namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FBusquedaPacientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBusquedaPacientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubvencionFichaAtencion = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkPacientesConsultaExterna = new System.Windows.Forms.RadioButton();
            this.checkPacientesHospitalizados = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.TxtInformación = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GBListadoPacientes = new System.Windows.Forms.GroupBox();
            this.dtGVListadoPacientesBusqueda = new System.Windows.Forms.DataGridView();
            this.bdNavPacientes = new System.Windows.Forms.BindingNavigator(this.components);
            this.bdSourcePacientes = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DGCNumeroPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCHClinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCFechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEdad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCOcupacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSeccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDenominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEstadoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GBListadoPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoPacientesBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavPacientes)).BeginInit();
            this.bdNavPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSubvencionFichaAtencion);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.TxtInformación);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSubvencionFichaAtencion
            // 
            this.btnSubvencionFichaAtencion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubvencionFichaAtencion.ImageIndex = 1;
            this.btnSubvencionFichaAtencion.ImageList = this.imageList1;
            this.btnSubvencionFichaAtencion.Location = new System.Drawing.Point(26, 60);
            this.btnSubvencionFichaAtencion.Name = "btnSubvencionFichaAtencion";
            this.btnSubvencionFichaAtencion.Size = new System.Drawing.Size(131, 31);
            this.btnSubvencionFichaAtencion.TabIndex = 6;
            this.btnSubvencionFichaAtencion.Text = "       &Nuevo Paciente";
            this.btnSubvencionFichaAtencion.UseVisualStyleBackColor = true;
            this.btnSubvencionFichaAtencion.Visible = false;
            this.btnSubvencionFichaAtencion.Click += new System.EventHandler(this.btnSubvencionFichaAtencion_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "magnifier.png");
            this.imageList1.Images.SetKeyName(1, "Doctor.png");
            this.imageList1.Images.SetKeyName(2, "viewmag.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkPacientesConsultaExterna);
            this.groupBox2.Controls.Add(this.checkPacientesHospitalizados);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(451, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 43);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "&Buscar en";
            // 
            // checkPacientesConsultaExterna
            // 
            this.checkPacientesConsultaExterna.AutoSize = true;
            this.checkPacientesConsultaExterna.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkPacientesConsultaExterna.Location = new System.Drawing.Point(225, 18);
            this.checkPacientesConsultaExterna.Name = "checkPacientesConsultaExterna";
            this.checkPacientesConsultaExterna.Size = new System.Drawing.Size(155, 17);
            this.checkPacientesConsultaExterna.TabIndex = 3;
            this.checkPacientesConsultaExterna.Text = "&Pacientes Consulta Externa";
            this.checkPacientesConsultaExterna.UseVisualStyleBackColor = true;
            // 
            // checkPacientesHospitalizados
            // 
            this.checkPacientesHospitalizados.AutoSize = true;
            this.checkPacientesHospitalizados.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkPacientesHospitalizados.Location = new System.Drawing.Point(30, 19);
            this.checkPacientesHospitalizados.Name = "checkPacientesHospitalizados";
            this.checkPacientesHospitalizados.Size = new System.Drawing.Size(143, 17);
            this.checkPacientesHospitalizados.TabIndex = 2;
            this.checkPacientesHospitalizados.Text = "&Pacientes Hospitalizados";
            this.checkPacientesHospitalizados.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImageIndex = 2;
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(728, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(133, 31);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Ejecutar Búsqueda";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // TxtInformación
            // 
            this.TxtInformación.Location = new System.Drawing.Point(97, 20);
            this.TxtInformación.Name = "TxtInformación";
            this.TxtInformación.Size = new System.Drawing.Size(602, 20);
            this.TxtInformación.TabIndex = 3;
            this.TxtInformación.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInformación_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Información :";
            // 
            // GBListadoPacientes
            // 
            this.GBListadoPacientes.Controls.Add(this.dtGVListadoPacientesBusqueda);
            this.GBListadoPacientes.Controls.Add(this.bdNavPacientes);
            this.GBListadoPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GBListadoPacientes.ForeColor = System.Drawing.Color.RoyalBlue;
            this.GBListadoPacientes.Location = new System.Drawing.Point(0, 111);
            this.GBListadoPacientes.Name = "GBListadoPacientes";
            this.GBListadoPacientes.Size = new System.Drawing.Size(868, 399);
            this.GBListadoPacientes.TabIndex = 3;
            this.GBListadoPacientes.TabStop = false;
            this.GBListadoPacientes.Text = "Lista de Pacientes";
            // 
            // dtGVListadoPacientesBusqueda
            // 
            this.dtGVListadoPacientesBusqueda.AllowUserToAddRows = false;
            this.dtGVListadoPacientesBusqueda.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoPacientesBusqueda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoPacientesBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoPacientesBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNumeroPaciente,
            this.DGCHClinico,
            this.DGCNombre,
            this.DGCApellidoPaterno,
            this.DGCApellidoMaterno,
            this.DGCFechaNacimiento,
            this.DGCEdad,
            this.DGCFechaIngreso,
            this.DGCOcupacion,
            this.DGCUnidad,
            this.DGCSeccion,
            this.DGCDenominacion,
            this.DGCEstadoPaciente});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVListadoPacientesBusqueda.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVListadoPacientesBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListadoPacientesBusqueda.Location = new System.Drawing.Point(3, 41);
            this.dtGVListadoPacientesBusqueda.Name = "dtGVListadoPacientesBusqueda";
            this.dtGVListadoPacientesBusqueda.ReadOnly = true;
            this.dtGVListadoPacientesBusqueda.RowHeadersVisible = false;
            this.dtGVListadoPacientesBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListadoPacientesBusqueda.Size = new System.Drawing.Size(862, 355);
            this.dtGVListadoPacientesBusqueda.TabIndex = 0;
            this.dtGVListadoPacientesBusqueda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVListadoPacientesBusqueda_CellDoubleClick);
            // 
            // bdNavPacientes
            // 
            this.bdNavPacientes.AddNewItem = null;
            this.bdNavPacientes.BindingSource = this.bdSourcePacientes;
            this.bdNavPacientes.CountItem = this.bindingNavigatorCountItem;
            this.bdNavPacientes.DeleteItem = null;
            this.bdNavPacientes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bdNavPacientes.Location = new System.Drawing.Point(3, 16);
            this.bdNavPacientes.MoveFirstItem = null;
            this.bdNavPacientes.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdNavPacientes.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdNavPacientes.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdNavPacientes.Name = "bdNavPacientes";
            this.bdNavPacientes.PositionItem = this.bindingNavigatorPositionItem;
            this.bdNavPacientes.Size = new System.Drawing.Size(862, 25);
            this.bdNavPacientes.TabIndex = 1;
            this.bdNavPacientes.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // DGCNumeroPaciente
            // 
            this.DGCNumeroPaciente.DataPropertyName = "NumeroPaciente";
            this.DGCNumeroPaciente.HeaderText = "Nro Pac.";
            this.DGCNumeroPaciente.Name = "DGCNumeroPaciente";
            this.DGCNumeroPaciente.ReadOnly = true;
            this.DGCNumeroPaciente.Visible = false;
            this.DGCNumeroPaciente.Width = 50;
            // 
            // DGCHClinico
            // 
            this.DGCHClinico.DataPropertyName = "HClinico";
            this.DGCHClinico.HeaderText = "Nº H. Clínico";
            this.DGCHClinico.Name = "DGCHClinico";
            this.DGCHClinico.ReadOnly = true;
            this.DGCHClinico.Width = 60;
            // 
            // DGCNombre
            // 
            this.DGCNombre.DataPropertyName = "Nombre";
            this.DGCNombre.HeaderText = "Nombre del Paciente";
            this.DGCNombre.Name = "DGCNombre";
            this.DGCNombre.ReadOnly = true;
            this.DGCNombre.Width = 120;
            // 
            // DGCApellidoPaterno
            // 
            this.DGCApellidoPaterno.DataPropertyName = "ApellidoPaterno";
            this.DGCApellidoPaterno.HeaderText = "Apellido Paterno";
            this.DGCApellidoPaterno.Name = "DGCApellidoPaterno";
            this.DGCApellidoPaterno.ReadOnly = true;
            this.DGCApellidoPaterno.Width = 125;
            // 
            // DGCApellidoMaterno
            // 
            this.DGCApellidoMaterno.DataPropertyName = "ApellidoMaterno";
            this.DGCApellidoMaterno.HeaderText = "Apellido Materno";
            this.DGCApellidoMaterno.Name = "DGCApellidoMaterno";
            this.DGCApellidoMaterno.ReadOnly = true;
            this.DGCApellidoMaterno.Width = 125;
            // 
            // DGCFechaNacimiento
            // 
            this.DGCFechaNacimiento.DataPropertyName = "FechaNacimiento";
            this.DGCFechaNacimiento.HeaderText = "Fecha Nacimiento";
            this.DGCFechaNacimiento.Name = "DGCFechaNacimiento";
            this.DGCFechaNacimiento.ReadOnly = true;
            this.DGCFechaNacimiento.Width = 90;
            // 
            // DGCEdad
            // 
            this.DGCEdad.DataPropertyName = "Edad";
            this.DGCEdad.HeaderText = "Edad";
            this.DGCEdad.Name = "DGCEdad";
            this.DGCEdad.ReadOnly = true;
            this.DGCEdad.Width = 38;
            // 
            // DGCFechaIngreso
            // 
            this.DGCFechaIngreso.DataPropertyName = "FechaIngreso";
            this.DGCFechaIngreso.HeaderText = "Fecha Ingreso";
            this.DGCFechaIngreso.Name = "DGCFechaIngreso";
            this.DGCFechaIngreso.ReadOnly = true;
            // 
            // DGCOcupacion
            // 
            this.DGCOcupacion.DataPropertyName = "Ocupacion";
            this.DGCOcupacion.HeaderText = "Ocupación";
            this.DGCOcupacion.Name = "DGCOcupacion";
            this.DGCOcupacion.ReadOnly = true;
            // 
            // DGCUnidad
            // 
            this.DGCUnidad.DataPropertyName = "Unidad";
            this.DGCUnidad.HeaderText = "Unidad";
            this.DGCUnidad.Name = "DGCUnidad";
            this.DGCUnidad.ReadOnly = true;
            this.DGCUnidad.Width = 50;
            // 
            // DGCSeccion
            // 
            this.DGCSeccion.DataPropertyName = "Seccion";
            this.DGCSeccion.HeaderText = "Sección";
            this.DGCSeccion.Name = "DGCSeccion";
            this.DGCSeccion.ReadOnly = true;
            this.DGCSeccion.Width = 70;
            // 
            // DGCDenominacion
            // 
            this.DGCDenominacion.DataPropertyName = "Denominacion";
            this.DGCDenominacion.HeaderText = "Denominación";
            this.DGCDenominacion.Name = "DGCDenominacion";
            this.DGCDenominacion.ReadOnly = true;
            this.DGCDenominacion.Width = 250;
            // 
            // DGCEstadoPaciente
            // 
            this.DGCEstadoPaciente.DataPropertyName = "EstadoPaciente";
            this.DGCEstadoPaciente.HeaderText = "Estado";
            this.DGCEstadoPaciente.Name = "DGCEstadoPaciente";
            this.DGCEstadoPaciente.ReadOnly = true;
            this.DGCEstadoPaciente.Width = 80;
            // 
            // FBusquedaPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(868, 510);
            this.Controls.Add(this.GBListadoPacientes);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FBusquedaPacientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÚSQUEDA DE PACIENTES";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GBListadoPacientes.ResumeLayout(false);
            this.GBListadoPacientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoPacientesBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavPacientes)).EndInit();
            this.bdNavPacientes.ResumeLayout(false);
            this.bdNavPacientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePacientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtInformación;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox GBListadoPacientes;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton checkPacientesConsultaExterna;
        private System.Windows.Forms.RadioButton checkPacientesHospitalizados;
        private System.Windows.Forms.DataGridView dtGVListadoPacientesBusqueda;
        public System.Windows.Forms.Button btnSubvencionFichaAtencion;
        private System.Windows.Forms.BindingNavigator bdNavPacientes;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bdSourcePacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNumeroPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCHClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEdad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCOcupacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSeccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDenominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEstadoPaciente;
    }
}