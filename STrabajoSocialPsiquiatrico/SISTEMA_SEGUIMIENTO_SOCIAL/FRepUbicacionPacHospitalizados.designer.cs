namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepUbicacionPacHospitalizados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepUbicacionPacHospitalizados));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBoxSeccion = new System.Windows.Forms.ComboBox();
            this.cBoxUnidad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkCantidad = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtGVPacientes = new System.Windows.Forms.DataGridView();
            this.DGCNombreCompletoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCHClinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEdadActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCGradoInstruccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDepartamentoProcedencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSeccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtTotalPacientes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.rBtnHospitalizados = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rBtnListadoDetallado = new System.Windows.Forms.RadioButton();
            this.rBtnListadoSimple = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxSeccion);
            this.groupBox1.Controls.Add(this.cBoxUnidad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(5, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 42);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios de Búsqueda";
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
            this.cBoxSeccion.Location = new System.Drawing.Point(317, 15);
            this.cBoxSeccion.Name = "cBoxSeccion";
            this.cBoxSeccion.Size = new System.Drawing.Size(135, 21);
            this.cBoxSeccion.TabIndex = 13;
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
            this.cBoxUnidad.Location = new System.Drawing.Point(114, 15);
            this.cBoxUnidad.Name = "cBoxUnidad";
            this.cBoxUnidad.Size = new System.Drawing.Size(69, 21);
            this.cBoxUnidad.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(57, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Unidad :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(259, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Sección :";
            // 
            // checkCantidad
            // 
            this.checkCantidad.AutoSize = true;
            this.checkCantidad.ForeColor = System.Drawing.Color.RoyalBlue;
            this.checkCantidad.Location = new System.Drawing.Point(12, 82);
            this.checkCantidad.Name = "checkCantidad";
            this.checkCantidad.Size = new System.Drawing.Size(373, 17);
            this.checkCantidad.TabIndex = 10;
            this.checkCantidad.Text = "Cuadro General de Cantidad de Pacientes hospitalizados en cada Unidad";
            this.checkCantidad.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtGVPacientes);
            this.groupBox5.Location = new System.Drawing.Point(7, 103);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(757, 362);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // dtGVPacientes
            // 
            this.dtGVPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNombreCompletoPaciente,
            this.DGCHClinico,
            this.Column1,
            this.Column4,
            this.Column5,
            this.DGCSexo,
            this.Column8,
            this.DGCEdadActual,
            this.Column9,
            this.DGCEstadoCivil,
            this.DGCGradoInstruccion,
            this.DGCDepartamentoProcedencia,
            this.Column6,
            this.Column7,
            this.Column2,
            this.Column3,
            this.DGCUnidad,
            this.DGCSeccion});
            this.dtGVPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVPacientes.Location = new System.Drawing.Point(3, 16);
            this.dtGVPacientes.Name = "dtGVPacientes";
            this.dtGVPacientes.Size = new System.Drawing.Size(751, 343);
            this.dtGVPacientes.TabIndex = 0;
            // 
            // DGCNombreCompletoPaciente
            // 
            this.DGCNombreCompletoPaciente.DataPropertyName = "NombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.HeaderText = "Nombre del Paciente";
            this.DGCNombreCompletoPaciente.Name = "DGCNombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.ReadOnly = true;
            this.DGCNombreCompletoPaciente.Width = 230;
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
            // Column1
            // 
            this.Column1.HeaderText = "Fecha Ingreso";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tiempo de Internación";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Diagnóstico Psiquiátrico";
            this.Column5.Name = "Column5";
            // 
            // DGCSexo
            // 
            this.DGCSexo.DataPropertyName = "Sexo";
            this.DGCSexo.HeaderText = "Sexo";
            this.DGCSexo.Name = "DGCSexo";
            this.DGCSexo.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Fecha de Nacimiento";
            this.Column8.Name = "Column8";
            // 
            // DGCEdadActual
            // 
            this.DGCEdadActual.DataPropertyName = "EdadActual";
            this.DGCEdadActual.HeaderText = "Edad";
            this.DGCEdadActual.Name = "DGCEdadActual";
            this.DGCEdadActual.ReadOnly = true;
            this.DGCEdadActual.Width = 50;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Carnet Identidad";
            this.Column9.Name = "Column9";
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
            this.DGCDepartamentoProcedencia.HeaderText = "Procedencia Dep.";
            this.DGCDepartamentoProcedencia.Name = "DGCDepartamentoProcedencia";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Procedencia Provincia";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Procedencia Localidad";
            this.Column7.Name = "Column7";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Religión";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Idioma";
            this.Column3.Name = "Column3";
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnListar);
            this.panel1.Controls.Add(this.txtTotalPacientes);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Location = new System.Drawing.Point(-3, 465);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 42);
            this.panel1.TabIndex = 7;
            // 
            // btnListar
            // 
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.ImageIndex = 1;
            this.btnListar.ImageList = this.imageList1;
            this.btnListar.Location = new System.Drawing.Point(445, 4);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(74, 31);
            this.btnListar.TabIndex = 12;
            this.btnListar.Text = "&Listar";
            this.btnListar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exit.png");
            this.imageList1.Images.SetKeyName(1, "Printer v2.png");
            this.imageList1.Images.SetKeyName(2, "Undo.png");
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
            this.btnCerrar.Location = new System.Drawing.Point(685, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(74, 31);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 2;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(605, 4);
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
            this.btnImprimir.Location = new System.Drawing.Point(525, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(74, 31);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // rBtnHospitalizados
            // 
            this.rBtnHospitalizados.AutoSize = true;
            this.rBtnHospitalizados.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rBtnHospitalizados.Location = new System.Drawing.Point(41, 4);
            this.rBtnHospitalizados.Name = "rBtnHospitalizados";
            this.rBtnHospitalizados.Size = new System.Drawing.Size(200, 17);
            this.rBtnHospitalizados.TabIndex = 8;
            this.rBtnHospitalizados.TabStop = true;
            this.rBtnHospitalizados.Text = "Pacientes Actualmente Hopitalizados";
            this.rBtnHospitalizados.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rBtnListadoDetallado);
            this.groupBox2.Controls.Add(this.rBtnListadoSimple);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(523, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 42);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imprimir Listado :";
            // 
            // rBtnListadoDetallado
            // 
            this.rBtnListadoDetallado.AutoSize = true;
            this.rBtnListadoDetallado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rBtnListadoDetallado.Location = new System.Drawing.Point(133, 17);
            this.rBtnListadoDetallado.Name = "rBtnListadoDetallado";
            this.rBtnListadoDetallado.Size = new System.Drawing.Size(70, 17);
            this.rBtnListadoDetallado.TabIndex = 1;
            this.rBtnListadoDetallado.Text = "Detallado";
            this.rBtnListadoDetallado.UseVisualStyleBackColor = true;
            // 
            // rBtnListadoSimple
            // 
            this.rBtnListadoSimple.AutoSize = true;
            this.rBtnListadoSimple.Checked = true;
            this.rBtnListadoSimple.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rBtnListadoSimple.Location = new System.Drawing.Point(38, 17);
            this.rBtnListadoSimple.Name = "rBtnListadoSimple";
            this.rBtnListadoSimple.Size = new System.Drawing.Size(56, 17);
            this.rBtnListadoSimple.TabIndex = 0;
            this.rBtnListadoSimple.TabStop = true;
            this.rBtnListadoSimple.Text = "Simple";
            this.rBtnListadoSimple.UseVisualStyleBackColor = true;
            // 
            // FRepUbicacionPacHospitalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(768, 506);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rBtnHospitalizados);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkCantidad);
            this.Name = "FRepUbicacionPacHospitalizados";
            this.Text = "PACIENTES HOSPITALIZADOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.CheckBox checkCantidad;
        private System.Windows.Forms.RadioButton rBtnHospitalizados;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompletoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCHClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEdadActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEstadoCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCGradoInstruccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDepartamentoProcedencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSeccion;
        private System.Windows.Forms.ComboBox cBoxSeccion;
        private System.Windows.Forms.ComboBox cBoxUnidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rBtnListadoDetallado;
        private System.Windows.Forms.RadioButton rBtnListadoSimple;
    }
}