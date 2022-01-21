namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepUbicacionPacientesHospitalizados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepUbicacionPacientesHospitalizados));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkCantidad = new System.Windows.Forms.CheckBox();
            this.cBoxSeccion = new System.Windows.Forms.ComboBox();
            this.cBoxUnidad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rBtnHospitalizados = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtGVPacientes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotalPacientes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.DGCHClinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCompletoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEdadActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCGradoInstruccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDepartamentoProcedencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSeccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateFechaInicio);
            this.groupBox1.Controls.Add(this.dateFechaFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkCantidad);
            this.groupBox1.Controls.Add(this.cBoxSeccion);
            this.groupBox1.Controls.Add(this.cBoxUnidad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rBtnHospitalizados);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(8, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios de Búsqueda";
            // 
            // checkCantidad
            // 
            this.checkCantidad.AutoSize = true;
            this.checkCantidad.Location = new System.Drawing.Point(55, 54);
            this.checkCantidad.Name = "checkCantidad";
            this.checkCantidad.Size = new System.Drawing.Size(409, 17);
            this.checkCantidad.TabIndex = 10;
            this.checkCantidad.Text = "Cantidad Total de Pacientes que Actualmente Reciden en una Unidad y Sección";
            this.checkCantidad.UseVisualStyleBackColor = true;
            // 
            // cBoxSeccion
            // 
            this.cBoxSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSeccion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cBoxSeccion.FormattingEnabled = true;
            this.cBoxSeccion.Items.AddRange(new object[] {
            "MUJERES",
            "VARONES",
            "MIXTA"});
            this.cBoxSeccion.Location = new System.Drawing.Point(543, 21);
            this.cBoxSeccion.Name = "cBoxSeccion";
            this.cBoxSeccion.Size = new System.Drawing.Size(135, 21);
            this.cBoxSeccion.TabIndex = 9;
            // 
            // cBoxUnidad
            // 
            this.cBoxUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUnidad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cBoxUnidad.FormattingEnabled = true;
            this.cBoxUnidad.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cBoxUnidad.Location = new System.Drawing.Point(357, 21);
            this.cBoxUnidad.Name = "cBoxUnidad";
            this.cBoxUnidad.Size = new System.Drawing.Size(69, 21);
            this.cBoxUnidad.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(300, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Unidad :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(485, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sección :";
            // 
            // rBtnHospitalizados
            // 
            this.rBtnHospitalizados.AutoSize = true;
            this.rBtnHospitalizados.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rBtnHospitalizados.Location = new System.Drawing.Point(56, 21);
            this.rBtnHospitalizados.Name = "rBtnHospitalizados";
            this.rBtnHospitalizados.Size = new System.Drawing.Size(200, 17);
            this.rBtnHospitalizados.TabIndex = 2;
            this.rBtnHospitalizados.TabStop = true;
            this.rBtnHospitalizados.Text = "Pacientes Actualmente Hopitalizados";
            this.rBtnHospitalizados.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtGVPacientes);
            this.groupBox5.Location = new System.Drawing.Point(7, 119);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(734, 320);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // dtGVPacientes
            // 
            this.dtGVPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCHClinico,
            this.DGCNombreCompletoPaciente,
            this.DGCSexo,
            this.DGCEdadActual,
            this.DGCEstadoCivil,
            this.DGCGradoInstruccion,
            this.DGCDepartamentoProcedencia,
            this.DGCUnidad,
            this.DGCSeccion});
            this.dtGVPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVPacientes.Location = new System.Drawing.Point(3, 16);
            this.dtGVPacientes.Name = "dtGVPacientes";
            this.dtGVPacientes.Size = new System.Drawing.Size(728, 301);
            this.dtGVPacientes.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnListar);
            this.panel1.Controls.Add(this.txtTotalPacientes);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Location = new System.Drawing.Point(-3, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 42);
            this.panel1.TabIndex = 7;
            // 
            // txtTotalPacientes
            // 
            this.txtTotalPacientes.Location = new System.Drawing.Point(110, 10);
            this.txtTotalPacientes.Name = "txtTotalPacientes";
            this.txtTotalPacientes.Size = new System.Drawing.Size(62, 20);
            this.txtTotalPacientes.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(17, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Total Pacientes :";
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.ImageIndex = 0;
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(647, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(74, 31);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exit.png");
            this.imageList1.Images.SetKeyName(1, "Printer v2.png");
            this.imageList1.Images.SetKeyName(2, "Undo.png");
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 2;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(567, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 31);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.ImageIndex = 1;
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(487, 6);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(74, 31);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnListar
            // 
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.ImageIndex = 1;
            this.btnListar.ImageList = this.imageList1;
            this.btnListar.Location = new System.Drawing.Point(407, 6);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(74, 31);
            this.btnListar.TabIndex = 12;
            this.btnListar.Text = "&Listar";
            this.btnListar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // DGCHClinico
            // 
            this.DGCHClinico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCHClinico.DataPropertyName = "HClinico";
            this.DGCHClinico.HeaderText = "Nro. H. Clínico";
            this.DGCHClinico.Name = "DGCHClinico";
            this.DGCHClinico.ReadOnly = true;
            this.DGCHClinico.Visible = false;
            // 
            // DGCNombreCompletoPaciente
            // 
            this.DGCNombreCompletoPaciente.DataPropertyName = "NombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.HeaderText = "Nombre del Paciente";
            this.DGCNombreCompletoPaciente.Name = "DGCNombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.ReadOnly = true;
            this.DGCNombreCompletoPaciente.Width = 230;
            // 
            // DGCSexo
            // 
            this.DGCSexo.DataPropertyName = "Sexo";
            this.DGCSexo.HeaderText = "Sexo";
            this.DGCSexo.Name = "DGCSexo";
            this.DGCSexo.ReadOnly = true;
            // 
            // DGCEdadActual
            // 
            this.DGCEdadActual.DataPropertyName = "EdadActual";
            this.DGCEdadActual.HeaderText = "Edad";
            this.DGCEdadActual.Name = "DGCEdadActual";
            this.DGCEdadActual.ReadOnly = true;
            this.DGCEdadActual.Width = 50;
            // 
            // DGCEstadoCivil
            // 
            this.DGCEstadoCivil.DataPropertyName = "EstadoCivil";
            this.DGCEstadoCivil.HeaderText = "Estado Civil";
            this.DGCEstadoCivil.Name = "DGCEstadoCivil";
            this.DGCEstadoCivil.ReadOnly = true;
            // 
            // DGCGradoInstruccion
            // 
            this.DGCGradoInstruccion.DataPropertyName = "GradoInstruccion";
            this.DGCGradoInstruccion.HeaderText = "Grado Instrucción";
            this.DGCGradoInstruccion.Name = "DGCGradoInstruccion";
            this.DGCGradoInstruccion.ReadOnly = true;
            // 
            // DGCDepartamentoProcedencia
            // 
            this.DGCDepartamentoProcedencia.DataPropertyName = "DepartamentoProcedencia";
            this.DGCDepartamentoProcedencia.HeaderText = "Procedencia";
            this.DGCDepartamentoProcedencia.Name = "DGCDepartamentoProcedencia";
            // 
            // DGCUnidad
            // 
            this.DGCUnidad.DataPropertyName = "Unidad";
            this.DGCUnidad.HeaderText = "Unidad";
            this.DGCUnidad.Name = "DGCUnidad";
            this.DGCUnidad.Visible = false;
            this.DGCUnidad.Width = 50;
            // 
            // DGCSeccion
            // 
            this.DGCSeccion.DataPropertyName = "Seccion";
            this.DGCSeccion.HeaderText = "Sección";
            this.DGCSeccion.Name = "DGCSeccion";
            this.DGCSeccion.Visible = false;
            this.DGCSeccion.Width = 90;
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaInicio.Location = new System.Drawing.Point(159, 77);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(188, 20);
            this.dateFechaInicio.TabIndex = 26;
            // 
            // dateFechaFin
            // 
            this.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaFin.Location = new System.Drawing.Point(445, 77);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Size = new System.Drawing.Size(188, 20);
            this.dateFechaFin.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(109, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Desde :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(398, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Hasta :";
            // 
            // FRepUbicacionPacientesHospitalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(749, 475);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FRepUbicacionPacientesHospitalizados";
            this.Text = "UBICACIÓN DE PACIENTES HOSPITALIZADOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtnHospitalizados;
        private System.Windows.Forms.ComboBox cBoxSeccion;
        private System.Windows.Forms.ComboBox cBoxUnidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkCantidad;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dtGVPacientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotalPacientes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCHClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompletoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEdadActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEstadoCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCGradoInstruccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDepartamentoProcedencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSeccion;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}