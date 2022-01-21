namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FBuscarPacientesOperaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBuscarPacientesOperaciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkListarUltimosRegistros = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtTextoBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgvPacientes = new System.Windows.Forms.DataGridView();
            this.bdSourcePacientes = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DGCNumeroPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCHistorialClinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCFechaOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNumeroOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCOcupacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCIPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDatoExtra1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDatoExtra2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkListarUltimosRegistros);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.txtTextoBusqueda);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 74);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkListarUltimosRegistros
            // 
            this.checkListarUltimosRegistros.AutoSize = true;
            this.checkListarUltimosRegistros.Location = new System.Drawing.Point(655, 45);
            this.checkListarUltimosRegistros.Name = "checkListarUltimosRegistros";
            this.checkListarUltimosRegistros.Size = new System.Drawing.Size(94, 17);
            this.checkListarUltimosRegistros.TabIndex = 8;
            this.checkListarUltimosRegistros.Text = "UltimoRegistro";
            this.checkListarUltimosRegistros.UseVisualStyleBackColor = true;
            this.checkListarUltimosRegistros.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "al";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "del";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(326, 40);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(201, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(44, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(124, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Buscar entre Fechas";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtTextoBusqueda
            // 
            this.txtTextoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextoBusqueda.Location = new System.Drawing.Point(160, 11);
            this.txtTextoBusqueda.Name = "txtTextoBusqueda";
            this.txtTextoBusqueda.Size = new System.Drawing.Size(477, 20);
            this.txtTextoBusqueda.TabIndex = 2;
            this.txtTextoBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTextoBusqueda_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Información a Buscar ";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImageIndex = 0;
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(652, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(81, 30);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "viewmag.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgvPacientes);
            this.groupBox1.Controls.Add(this.bindingNavigator1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 393);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Registros Encontrados";
            // 
            // dtgvPacientes
            // 
            this.dtgvPacientes.AllowUserToAddRows = false;
            this.dtgvPacientes.AllowUserToResizeRows = false;
            this.dtgvPacientes.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNumeroPaciente,
            this.DGCHistorialClinico,
            this.DGCNombreCompleto,
            this.DGCFechaOperacion,
            this.DGCNumeroOperacion,
            this.DGCOcupacion,
            this.DGCCIPaciente,
            this.DGCDatoExtra1,
            this.DGCDatoExtra2});
            this.dtgvPacientes.DataSource = this.bdSourcePacientes;
            this.dtgvPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvPacientes.Location = new System.Drawing.Point(3, 41);
            this.dtgvPacientes.Name = "dtgvPacientes";
            this.dtgvPacientes.ReadOnly = true;
            this.dtgvPacientes.RowHeadersVisible = false;
            this.dtgvPacientes.RowTemplate.Height = 24;
            this.dtgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPacientes.Size = new System.Drawing.Size(778, 349);
            this.dtgvPacientes.TabIndex = 1;
            this.dtgvPacientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPacientes_CellDoubleClick);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(778, 25);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // DGCNumeroPaciente
            // 
            this.DGCNumeroPaciente.DataPropertyName = "NumeroPaciente";
            this.DGCNumeroPaciente.HeaderText = "Nro Pac";
            this.DGCNumeroPaciente.Name = "DGCNumeroPaciente";
            this.DGCNumeroPaciente.ReadOnly = true;
            this.DGCNumeroPaciente.Visible = false;
            this.DGCNumeroPaciente.Width = 70;
            // 
            // DGCHistorialClinico
            // 
            this.DGCHistorialClinico.DataPropertyName = "HClinico";
            this.DGCHistorialClinico.HeaderText = "H. Clínico";
            this.DGCHistorialClinico.Name = "DGCHistorialClinico";
            this.DGCHistorialClinico.ReadOnly = true;
            this.DGCHistorialClinico.Width = 70;
            // 
            // DGCNombreCompleto
            // 
            this.DGCNombreCompleto.DataPropertyName = "NombreCompleto";
            this.DGCNombreCompleto.HeaderText = "Nombre del Paciente";
            this.DGCNombreCompleto.Name = "DGCNombreCompleto";
            this.DGCNombreCompleto.ReadOnly = true;
            this.DGCNombreCompleto.Width = 280;
            // 
            // DGCFechaOperacion
            // 
            this.DGCFechaOperacion.DataPropertyName = "FechaOperacion";
            this.DGCFechaOperacion.HeaderText = "Fecha Operacion";
            this.DGCFechaOperacion.Name = "DGCFechaOperacion";
            this.DGCFechaOperacion.ReadOnly = true;
            // 
            // DGCNumeroOperacion
            // 
            this.DGCNumeroOperacion.DataPropertyName = "NumeroOperacion";
            this.DGCNumeroOperacion.HeaderText = "Nro de Registro";
            this.DGCNumeroOperacion.Name = "DGCNumeroOperacion";
            this.DGCNumeroOperacion.ReadOnly = true;
            this.DGCNumeroOperacion.Width = 70;
            // 
            // DGCOcupacion
            // 
            this.DGCOcupacion.DataPropertyName = "Ocupacion";
            this.DGCOcupacion.HeaderText = "Ocupación";
            this.DGCOcupacion.Name = "DGCOcupacion";
            this.DGCOcupacion.ReadOnly = true;
            this.DGCOcupacion.Width = 150;
            // 
            // DGCCIPaciente
            // 
            this.DGCCIPaciente.DataPropertyName = "CIPaciente";
            this.DGCCIPaciente.HeaderText = "C.I.";
            this.DGCCIPaciente.Name = "DGCCIPaciente";
            this.DGCCIPaciente.ReadOnly = true;
            this.DGCCIPaciente.Width = 200;
            // 
            // DGCDatoExtra1
            // 
            this.DGCDatoExtra1.HeaderText = "Dato";
            this.DGCDatoExtra1.Name = "DGCDatoExtra1";
            this.DGCDatoExtra1.ReadOnly = true;
            this.DGCDatoExtra1.Visible = false;
            this.DGCDatoExtra1.Width = 350;
            // 
            // DGCDatoExtra2
            // 
            this.DGCDatoExtra2.HeaderText = "Dato2";
            this.DGCDatoExtra2.Name = "DGCDatoExtra2";
            this.DGCDatoExtra2.ReadOnly = true;
            this.DGCDatoExtra2.Visible = false;
            this.DGCDatoExtra2.Width = 350;
            // 
            // FBuscarPacientesOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 467);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FBuscarPacientesOperaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÚSQUEDA DE REGISTROS";
            this.Shown += new System.EventHandler(this.FBuscarPacientesOperaciones_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTextoBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgvPacientes;
        private System.Windows.Forms.BindingSource bdSourcePacientes;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox checkListarUltimosRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNumeroPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCHistorialClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNumeroOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCOcupacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCIPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDatoExtra1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDatoExtra2;
    }
}