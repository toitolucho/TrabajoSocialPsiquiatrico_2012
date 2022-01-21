namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepPacientesInstitucionalizados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepPacientesInstitucionalizados));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkPacHospitalizados = new System.Windows.Forms.CheckBox();
            this.rBtnPacInstitucionalizado = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVPacientes = new System.Windows.Forms.DataGridView();
            this.bdNavPacientes = new System.Windows.Forms.BindingNavigator(this.components);
            this.bdSourcePacientes = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.DGCFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCFechaActividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCompletoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCHClinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEdadActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDepartamentoProcedencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavPacientes)).BeginInit();
            this.bdNavPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePacientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkPacHospitalizados);
            this.groupBox1.Controls.Add(this.rBtnPacInstitucionalizado);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(7, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de Búsqueda";
            // 
            // checkPacHospitalizados
            // 
            this.checkPacHospitalizados.AutoSize = true;
            this.checkPacHospitalizados.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkPacHospitalizados.Location = new System.Drawing.Point(347, 26);
            this.checkPacHospitalizados.Name = "checkPacHospitalizados";
            this.checkPacHospitalizados.Size = new System.Drawing.Size(144, 17);
            this.checkPacHospitalizados.TabIndex = 28;
            this.checkPacHospitalizados.Text = "Pacientes Hospitalizados";
            this.checkPacHospitalizados.UseVisualStyleBackColor = true;
            // 
            // rBtnPacInstitucionalizado
            // 
            this.rBtnPacInstitucionalizado.AutoSize = true;
            this.rBtnPacInstitucionalizado.Checked = true;
            this.rBtnPacInstitucionalizado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rBtnPacInstitucionalizado.Location = new System.Drawing.Point(132, 25);
            this.rBtnPacInstitucionalizado.Name = "rBtnPacInstitucionalizado";
            this.rBtnPacInstitucionalizado.Size = new System.Drawing.Size(161, 17);
            this.rBtnPacInstitucionalizado.TabIndex = 27;
            this.rBtnPacInstitucionalizado.TabStop = true;
            this.rBtnPacInstitucionalizado.Text = "Pacientes Institucionalizados";
            this.rBtnPacInstitucionalizado.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dateFechaInicio);
            this.panel2.Controls.Add(this.dateFechaFin);
            this.panel2.Location = new System.Drawing.Point(-1, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 35);
            this.panel2.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(412, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Hasta :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(137, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Desde :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(68, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Periodo ";
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaInicio.Location = new System.Drawing.Point(184, 8);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(125, 20);
            this.dateFechaInicio.TabIndex = 23;
            // 
            // dateFechaFin
            // 
            this.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaFin.Location = new System.Drawing.Point(459, 8);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Size = new System.Drawing.Size(125, 20);
            this.dateFechaFin.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVPacientes);
            this.groupBox2.Controls.Add(this.bdNavPacientes);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(7, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(657, 347);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Pacientes";
            // 
            // dtGVPacientes
            // 
            this.dtGVPacientes.AllowUserToAddRows = false;
            this.dtGVPacientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCFechaIngreso,
            this.DGCFechaActividad,
            this.DGCNombreCompletoPaciente,
            this.DGCHClinico,
            this.DGCSexo,
            this.DGCEdadActual,
            this.DGCDepartamentoProcedencia});
            this.dtGVPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVPacientes.Location = new System.Drawing.Point(3, 41);
            this.dtGVPacientes.Name = "dtGVPacientes";
            this.dtGVPacientes.Size = new System.Drawing.Size(651, 303);
            this.dtGVPacientes.TabIndex = 0;
            // 
            // bdNavPacientes
            // 
            this.bdNavPacientes.AddNewItem = null;
            this.bdNavPacientes.BindingSource = this.bdSourcePacientes;
            this.bdNavPacientes.CountItem = this.bindingNavigatorCountItem;
            this.bdNavPacientes.DeleteItem = null;
            this.bdNavPacientes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bdNavPacientes.Location = new System.Drawing.Point(3, 16);
            this.bdNavPacientes.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdNavPacientes.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdNavPacientes.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdNavPacientes.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdNavPacientes.Name = "bdNavPacientes";
            this.bdNavPacientes.PositionItem = this.bindingNavigatorPositionItem;
            this.bdNavPacientes.Size = new System.Drawing.Size(651, 25);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMostrar);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Location = new System.Drawing.Point(-5, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 40);
            this.panel1.TabIndex = 7;
            // 
            // btnMostrar
            // 
            this.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrar.ImageIndex = 2;
            this.btnMostrar.ImageList = this.imageList1;
            this.btnMostrar.Location = new System.Drawing.Point(423, 3);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(74, 31);
            this.btnMostrar.TabIndex = 12;
            this.btnMostrar.Text = "&Listar";
            this.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exit.png");
            this.imageList1.Images.SetKeyName(1, "Printer v2.png");
            this.imageList1.Images.SetKeyName(2, "Properties.png");
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.ImageIndex = 0;
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(579, 3);
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
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.ImageIndex = 1;
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(501, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(74, 31);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // DGCFechaIngreso
            // 
            this.DGCFechaIngreso.DataPropertyName = "FechaIngreso";
            this.DGCFechaIngreso.HeaderText = "Fecha de Ingreso";
            this.DGCFechaIngreso.Name = "DGCFechaIngreso";
            this.DGCFechaIngreso.Width = 150;
            // 
            // DGCFechaActividad
            // 
            this.DGCFechaActividad.DataPropertyName = "FechaActividad";
            this.DGCFechaActividad.HeaderText = "Fecha Registro";
            this.DGCFechaActividad.Name = "DGCFechaActividad";
            this.DGCFechaActividad.Visible = false;
            // 
            // DGCNombreCompletoPaciente
            // 
            this.DGCNombreCompletoPaciente.DataPropertyName = "NombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.HeaderText = "Nombre Paciente";
            this.DGCNombreCompletoPaciente.Name = "DGCNombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.Width = 350;
            // 
            // DGCHClinico
            // 
            this.DGCHClinico.DataPropertyName = "HClinico";
            this.DGCHClinico.HeaderText = "H. Clínico";
            this.DGCHClinico.Name = "DGCHClinico";
            // 
            // DGCSexo
            // 
            this.DGCSexo.DataPropertyName = "Sexo";
            this.DGCSexo.HeaderText = "Sexo";
            this.DGCSexo.Name = "DGCSexo";
            // 
            // DGCEdadActual
            // 
            this.DGCEdadActual.DataPropertyName = "EdadActual";
            this.DGCEdadActual.HeaderText = "Edad";
            this.DGCEdadActual.Name = "DGCEdadActual";
            // 
            // DGCDepartamentoProcedencia
            // 
            this.DGCDepartamentoProcedencia.DataPropertyName = "DepartamentoProcedencia";
            this.DGCDepartamentoProcedencia.HeaderText = "Procedencia";
            this.DGCDepartamentoProcedencia.Name = "DGCDepartamentoProcedencia";
            // 
            // FRepPacientesInstitucionalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(668, 479);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRepPacientesInstitucionalizados";
            this.Text = "LISTADO DE PACIENTES INSTITUCIONALIZADOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavPacientes)).EndInit();
            this.bdNavPacientes.ResumeLayout(false);
            this.bdNavPacientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePacientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtnPacInstitucionalizado;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGVPacientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingNavigator bdNavPacientes;
        private System.Windows.Forms.BindingSource bdSourcePacientes;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.CheckBox checkPacHospitalizados;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompletoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCHClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEdadActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDepartamentoProcedencia;
    }
}