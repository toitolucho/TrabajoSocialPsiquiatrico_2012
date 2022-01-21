namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepDocumentoPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepDocumentoPaciente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVPacientesDocumentos = new System.Windows.Forms.DataGridView();
            this.bdNavPacientesDocumentos = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBtnAmbos = new System.Windows.Forms.RadioButton();
            this.rBtnTramitoPac = new System.Windows.Forms.RadioButton();
            this.rBtnTramitoTS = new System.Windows.Forms.RadioButton();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkActualmenteHospitalizados = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bdSourcePacientesDocumentos = new System.Windows.Forms.BindingSource(this.components);
            this.checkTiposDocumentos = new System.Windows.Forms.CheckBox();
            this.cBoxTiposDocumentos = new System.Windows.Forms.ComboBox();
            this.DGCFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCompletoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCHClinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTramitoTrabSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientesDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavPacientesDocumentos)).BeginInit();
            this.bdNavPacientesDocumentos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePacientesDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnMostrar);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 43);
            this.panel1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImageIndex = 1;
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(421, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 31);
            this.button2.TabIndex = 13;
            this.button2.Text = "&Cancelar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exit.png");
            this.imageList1.Images.SetKeyName(1, "Properties.png");
            this.imageList1.Images.SetKeyName(2, "Printer v2.png");
            // 
            // btnMostrar
            // 
            this.btnMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrar.ImageIndex = 1;
            this.btnMostrar.ImageList = this.imageList1;
            this.btnMostrar.Location = new System.Drawing.Point(498, 4);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(74, 31);
            this.btnMostrar.TabIndex = 12;
            this.btnMostrar.Text = "&Listar";
            this.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.ImageIndex = 0;
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(652, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(74, 31);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.ImageIndex = 2;
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(575, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(74, 31);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVPacientesDocumentos);
            this.groupBox2.Controls.Add(this.bdNavPacientesDocumentos);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(8, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(736, 282);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Pacientes";
            // 
            // dtGVPacientesDocumentos
            // 
            this.dtGVPacientesDocumentos.AllowUserToAddRows = false;
            this.dtGVPacientesDocumentos.AllowUserToDeleteRows = false;
            this.dtGVPacientesDocumentos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVPacientesDocumentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVPacientesDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPacientesDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCFechaRegistro,
            this.DGCNombreCompletoPaciente,
            this.DGCHClinico,
            this.DGCNombreDocumento,
            this.DGCTramitoTrabSocial});
            this.dtGVPacientesDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVPacientesDocumentos.Location = new System.Drawing.Point(3, 41);
            this.dtGVPacientesDocumentos.Name = "dtGVPacientesDocumentos";
            this.dtGVPacientesDocumentos.RowHeadersVisible = false;
            this.dtGVPacientesDocumentos.Size = new System.Drawing.Size(730, 238);
            this.dtGVPacientesDocumentos.TabIndex = 0;
            // 
            // bdNavPacientesDocumentos
            // 
            this.bdNavPacientesDocumentos.AddNewItem = null;
            this.bdNavPacientesDocumentos.CountItem = this.bindingNavigatorCountItem;
            this.bdNavPacientesDocumentos.DeleteItem = null;
            this.bdNavPacientesDocumentos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bdNavPacientesDocumentos.Location = new System.Drawing.Point(3, 16);
            this.bdNavPacientesDocumentos.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdNavPacientesDocumentos.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdNavPacientesDocumentos.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdNavPacientesDocumentos.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdNavPacientesDocumentos.Name = "bdNavPacientesDocumentos";
            this.bdNavPacientesDocumentos.PositionItem = this.bindingNavigatorPositionItem;
            this.bdNavPacientesDocumentos.Size = new System.Drawing.Size(730, 25);
            this.bdNavPacientesDocumentos.TabIndex = 1;
            this.bdNavPacientesDocumentos.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBtnAmbos);
            this.groupBox1.Controls.Add(this.rBtnTramitoPac);
            this.groupBox1.Controls.Add(this.rBtnTramitoTS);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(324, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 66);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de Búsqueda";
            // 
            // rBtnAmbos
            // 
            this.rBtnAmbos.AutoSize = true;
            this.rBtnAmbos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rBtnAmbos.Location = new System.Drawing.Point(340, 25);
            this.rBtnAmbos.Name = "rBtnAmbos";
            this.rBtnAmbos.Size = new System.Drawing.Size(57, 17);
            this.rBtnAmbos.TabIndex = 29;
            this.rBtnAmbos.TabStop = true;
            this.rBtnAmbos.Text = "Ambos";
            this.rBtnAmbos.UseVisualStyleBackColor = true;
            // 
            // rBtnTramitoPac
            // 
            this.rBtnTramitoPac.AutoSize = true;
            this.rBtnTramitoPac.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rBtnTramitoPac.Location = new System.Drawing.Point(161, 25);
            this.rBtnTramitoPac.Name = "rBtnTramitoPac";
            this.rBtnTramitoPac.Size = new System.Drawing.Size(158, 17);
            this.rBtnTramitoPac.TabIndex = 28;
            this.rBtnTramitoPac.TabStop = true;
            this.rBtnTramitoPac.Text = "Presentados por el Paciente";
            this.rBtnTramitoPac.UseVisualStyleBackColor = true;
            // 
            // rBtnTramitoTS
            // 
            this.rBtnTramitoTS.AutoSize = true;
            this.rBtnTramitoTS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rBtnTramitoTS.Location = new System.Drawing.Point(9, 25);
            this.rBtnTramitoTS.Name = "rBtnTramitoTS";
            this.rBtnTramitoTS.Size = new System.Drawing.Size(131, 17);
            this.rBtnTramitoTS.TabIndex = 27;
            this.rBtnTramitoTS.TabStop = true;
            this.rBtnTramitoTS.Text = "Tramitó Trabajo Social";
            this.rBtnTramitoTS.UseVisualStyleBackColor = true;
            // 
            // dateFechaFin
            // 
            this.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaFin.Location = new System.Drawing.Point(495, 8);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Size = new System.Drawing.Size(125, 20);
            this.dateFechaFin.TabIndex = 22;
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaInicio.Location = new System.Drawing.Point(220, 8);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(125, 20);
            this.dateFechaInicio.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(103, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Periodo ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dateFechaFin);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dateFechaInicio);
            this.panel2.Location = new System.Drawing.Point(8, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(739, 35);
            this.panel2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(447, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Hasta :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(169, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Desde :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(647, 74);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(89, 20);
            this.textBox3.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(563, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Fecha Ingreso :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(484, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 20);
            this.textBox2.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "H. Clinico :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 20);
            this.textBox1.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Paciente :";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton1.Location = new System.Drawing.Point(39, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(205, 17);
            this.radioButton1.TabIndex = 30;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Documentos de Pacientes Ingresados";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // checkActualmenteHospitalizados
            // 
            this.checkActualmenteHospitalizados.AutoSize = true;
            this.checkActualmenteHospitalizados.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkActualmenteHospitalizados.Location = new System.Drawing.Point(71, 39);
            this.checkActualmenteHospitalizados.Name = "checkActualmenteHospitalizados";
            this.checkActualmenteHospitalizados.Size = new System.Drawing.Size(156, 17);
            this.checkActualmenteHospitalizados.TabIndex = 31;
            this.checkActualmenteHospitalizados.Text = "Actualmente Hospitalizados";
            this.checkActualmenteHospitalizados.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.checkActualmenteHospitalizados);
            this.groupBox3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox3.Location = new System.Drawing.Point(5, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 66);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mostrar Reporte";
            // 
            // checkTiposDocumentos
            // 
            this.checkTiposDocumentos.AutoSize = true;
            this.checkTiposDocumentos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkTiposDocumentos.Location = new System.Drawing.Point(9, 139);
            this.checkTiposDocumentos.Name = "checkTiposDocumentos";
            this.checkTiposDocumentos.Size = new System.Drawing.Size(394, 17);
            this.checkTiposDocumentos.TabIndex = 30;
            this.checkTiposDocumentos.Text = "Listado de Pacientes Hospitalizados que cuenten con el Tipo de Documento :";
            this.checkTiposDocumentos.UseVisualStyleBackColor = true;
            this.checkTiposDocumentos.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // cBoxTiposDocumentos
            // 
            this.cBoxTiposDocumentos.FormattingEnabled = true;
            this.cBoxTiposDocumentos.Location = new System.Drawing.Point(407, 138);
            this.cBoxTiposDocumentos.Name = "cBoxTiposDocumentos";
            this.cBoxTiposDocumentos.Size = new System.Drawing.Size(329, 21);
            this.cBoxTiposDocumentos.TabIndex = 46;
            // 
            // DGCFechaRegistro
            // 
            this.DGCFechaRegistro.DataPropertyName = "FechaRegistro";
            this.DGCFechaRegistro.HeaderText = "Fecha de Registro";
            this.DGCFechaRegistro.Name = "DGCFechaRegistro";
            // 
            // DGCNombreCompletoPaciente
            // 
            this.DGCNombreCompletoPaciente.DataPropertyName = "NombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.HeaderText = "Nombre Paciente";
            this.DGCNombreCompletoPaciente.Name = "DGCNombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.Width = 250;
            // 
            // DGCHClinico
            // 
            this.DGCHClinico.DataPropertyName = "HClinico";
            this.DGCHClinico.HeaderText = "H. Clínico";
            this.DGCHClinico.Name = "DGCHClinico";
            this.DGCHClinico.Width = 80;
            // 
            // DGCNombreDocumento
            // 
            this.DGCNombreDocumento.DataPropertyName = "NombreDocumento";
            this.DGCNombreDocumento.HeaderText = "Nombre del Documento";
            this.DGCNombreDocumento.Name = "DGCNombreDocumento";
            this.DGCNombreDocumento.Width = 250;
            // 
            // DGCTramitoTrabSocial
            // 
            this.DGCTramitoTrabSocial.DataPropertyName = "TramitoTrabSocial";
            this.DGCTramitoTrabSocial.HeaderText = "Tramitó Trabajo Social";
            this.DGCTramitoTrabSocial.Name = "DGCTramitoTrabSocial";
            // 
            // FRepDocumentoPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(750, 489);
            this.Controls.Add(this.cBoxTiposDocumentos);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.checkTiposDocumentos);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRepDocumentoPaciente";
            this.Text = "DOCUMENTOS CON QUE CUENTA EL PACIENTE";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientesDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavPacientesDocumentos)).EndInit();
            this.bdNavPacientesDocumentos.ResumeLayout(false);
            this.bdNavPacientesDocumentos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePacientesDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGVPacientesDocumentos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtnAmbos;
        private System.Windows.Forms.RadioButton rBtnTramitoPac;
        private System.Windows.Forms.RadioButton rBtnTramitoTS;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator bdNavPacientesDocumentos;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bdSourcePacientesDocumentos;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox checkActualmenteHospitalizados;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkTiposDocumentos;
        private System.Windows.Forms.ComboBox cBoxTiposDocumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompletoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCHClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTramitoTrabSocial;
    }
}