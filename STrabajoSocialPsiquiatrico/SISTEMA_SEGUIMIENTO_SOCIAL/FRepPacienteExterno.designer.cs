namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepPacienteExterno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepPacienteExterno));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtGVPacientes = new System.Windows.Forms.DataGridView();
            this.DGCHClinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCompletoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEdadActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCGradoInstruccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDepartamentoProcedencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtTotalPacientes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEdad2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEdad1 = new System.Windows.Forms.TextBox();
            this.cBoxProcedencia = new System.Windows.Forms.ComboBox();
            this.cBoxGradoInstruccion = new System.Windows.Forms.ComboBox();
            this.cBoxEdad = new System.Windows.Forms.ComboBox();
            this.cBoxEstadoCivil = new System.Windows.Forms.ComboBox();
            this.cBoxSexo = new System.Windows.Forms.ComboBox();
            this.checkProcedencia = new System.Windows.Forms.CheckBox();
            this.checkGradoInstruccion = new System.Windows.Forms.CheckBox();
            this.checkEstadoCivil = new System.Windows.Forms.CheckBox();
            this.checkEdad = new System.Windows.Forms.CheckBox();
            this.checkSexo = new System.Windows.Forms.CheckBox();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtGVPacientes);
            this.groupBox5.Location = new System.Drawing.Point(8, 115);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(828, 347);
            this.groupBox5.TabIndex = 8;
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
            this.DGCDepartamentoProcedencia});
            this.dtGVPacientes.Location = new System.Drawing.Point(6, 22);
            this.dtGVPacientes.Name = "dtGVPacientes";
            this.dtGVPacientes.Size = new System.Drawing.Size(816, 324);
            this.dtGVPacientes.TabIndex = 0;
            // 
            // DGCHClinico
            // 
            this.DGCHClinico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCHClinico.DataPropertyName = "HClinico";
            this.DGCHClinico.HeaderText = "Nro. H. Clínico";
            this.DGCHClinico.Name = "DGCHClinico";
            this.DGCHClinico.ReadOnly = true;
            // 
            // DGCNombreCompletoPaciente
            // 
            this.DGCNombreCompletoPaciente.DataPropertyName = "NombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.HeaderText = "Nombre del Paciente";
            this.DGCNombreCompletoPaciente.Name = "DGCNombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.ReadOnly = true;
            this.DGCNombreCompletoPaciente.Width = 250;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMostrar);
            this.panel1.Controls.Add(this.txtTotalPacientes);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Location = new System.Drawing.Point(-7, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 43);
            this.panel1.TabIndex = 9;
            // 
            // btnMostrar
            // 
            this.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrar.ImageIndex = 1;
            this.btnMostrar.ImageList = this.imageList1;
            this.btnMostrar.Location = new System.Drawing.Point(517, 6);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(74, 31);
            this.btnMostrar.TabIndex = 12;
            this.btnMostrar.Text = "&Mostrar";
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
            this.imageList1.Images.SetKeyName(2, "Undo.png");
            // 
            // txtTotalPacientes
            // 
            this.txtTotalPacientes.Location = new System.Drawing.Point(110, 13);
            this.txtTotalPacientes.Name = "txtTotalPacientes";
            this.txtTotalPacientes.Size = new System.Drawing.Size(62, 20);
            this.txtTotalPacientes.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(17, 15);
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
            this.btnCerrar.Location = new System.Drawing.Point(757, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(74, 31);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.ImageIndex = 2;
            this.btnEliminar.ImageList = this.imageList1;
            this.btnEliminar.Location = new System.Drawing.Point(677, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(74, 31);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "&Cancelar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.ImageIndex = 1;
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(597, 5);
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
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtEdad2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtEdad1);
            this.groupBox2.Controls.Add(this.cBoxProcedencia);
            this.groupBox2.Controls.Add(this.cBoxGradoInstruccion);
            this.groupBox2.Controls.Add(this.cBoxEdad);
            this.groupBox2.Controls.Add(this.cBoxEstadoCivil);
            this.groupBox2.Controls.Add(this.cBoxSexo);
            this.groupBox2.Controls.Add(this.checkProcedencia);
            this.groupBox2.Controls.Add(this.checkGradoInstruccion);
            this.groupBox2.Controls.Add(this.checkEstadoCivil);
            this.groupBox2.Controls.Add(this.checkEdad);
            this.groupBox2.Controls.Add(this.checkSexo);
            this.groupBox2.Location = new System.Drawing.Point(8, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(826, 94);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "Año (s)";
            // 
            // txtEdad2
            // 
            this.txtEdad2.Enabled = false;
            this.txtEdad2.Location = new System.Drawing.Point(251, 64);
            this.txtEdad2.Name = "txtEdad2";
            this.txtEdad2.Size = new System.Drawing.Size(52, 20);
            this.txtEdad2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "Año (s)";
            // 
            // txtEdad1
            // 
            this.txtEdad1.Enabled = false;
            this.txtEdad1.Location = new System.Drawing.Point(251, 38);
            this.txtEdad1.Name = "txtEdad1";
            this.txtEdad1.Size = new System.Drawing.Size(52, 20);
            this.txtEdad1.TabIndex = 14;
            // 
            // cBoxProcedencia
            // 
            this.cBoxProcedencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxProcedencia.Enabled = false;
            this.cBoxProcedencia.FormattingEnabled = true;
            this.cBoxProcedencia.Location = new System.Drawing.Point(674, 37);
            this.cBoxProcedencia.Name = "cBoxProcedencia";
            this.cBoxProcedencia.Size = new System.Drawing.Size(129, 21);
            this.cBoxProcedencia.TabIndex = 9;
            // 
            // cBoxGradoInstruccion
            // 
            this.cBoxGradoInstruccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxGradoInstruccion.Enabled = false;
            this.cBoxGradoInstruccion.FormattingEnabled = true;
            this.cBoxGradoInstruccion.Location = new System.Drawing.Point(516, 37);
            this.cBoxGradoInstruccion.Name = "cBoxGradoInstruccion";
            this.cBoxGradoInstruccion.Size = new System.Drawing.Size(127, 21);
            this.cBoxGradoInstruccion.TabIndex = 8;
            // 
            // cBoxEdad
            // 
            this.cBoxEdad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxEdad.Enabled = false;
            this.cBoxEdad.FormattingEnabled = true;
            this.cBoxEdad.Items.AddRange(new object[] {
            "Igual que ",
            "Mayor que",
            "Menor que",
            "Entre"});
            this.cBoxEdad.Location = new System.Drawing.Point(157, 37);
            this.cBoxEdad.Name = "cBoxEdad";
            this.cBoxEdad.Size = new System.Drawing.Size(92, 21);
            this.cBoxEdad.TabIndex = 7;
            // 
            // cBoxEstadoCivil
            // 
            this.cBoxEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxEstadoCivil.Enabled = false;
            this.cBoxEstadoCivil.FormattingEnabled = true;
            this.cBoxEstadoCivil.Location = new System.Drawing.Point(356, 37);
            this.cBoxEstadoCivil.Name = "cBoxEstadoCivil";
            this.cBoxEstadoCivil.Size = new System.Drawing.Size(127, 21);
            this.cBoxEstadoCivil.TabIndex = 6;
            // 
            // cBoxSexo
            // 
            this.cBoxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSexo.Enabled = false;
            this.cBoxSexo.FormattingEnabled = true;
            this.cBoxSexo.Location = new System.Drawing.Point(25, 37);
            this.cBoxSexo.Name = "cBoxSexo";
            this.cBoxSexo.Size = new System.Drawing.Size(97, 21);
            this.cBoxSexo.TabIndex = 5;
            // 
            // checkProcedencia
            // 
            this.checkProcedencia.AutoSize = true;
            this.checkProcedencia.Location = new System.Drawing.Point(674, 19);
            this.checkProcedencia.Name = "checkProcedencia";
            this.checkProcedencia.Size = new System.Drawing.Size(86, 17);
            this.checkProcedencia.TabIndex = 4;
            this.checkProcedencia.Text = "Procedencia";
            this.checkProcedencia.UseVisualStyleBackColor = true;
            this.checkProcedencia.CheckedChanged += new System.EventHandler(this.checkProcedencia_CheckedChanged);
            // 
            // checkGradoInstruccion
            // 
            this.checkGradoInstruccion.AutoSize = true;
            this.checkGradoInstruccion.Location = new System.Drawing.Point(517, 19);
            this.checkGradoInstruccion.Name = "checkGradoInstruccion";
            this.checkGradoInstruccion.Size = new System.Drawing.Size(110, 17);
            this.checkGradoInstruccion.TabIndex = 3;
            this.checkGradoInstruccion.Text = "Grado Instrucción";
            this.checkGradoInstruccion.UseVisualStyleBackColor = true;
            this.checkGradoInstruccion.CheckedChanged += new System.EventHandler(this.checkGradoInstruccion_CheckedChanged);
            // 
            // checkEstadoCivil
            // 
            this.checkEstadoCivil.AutoSize = true;
            this.checkEstadoCivil.Location = new System.Drawing.Point(357, 19);
            this.checkEstadoCivil.Name = "checkEstadoCivil";
            this.checkEstadoCivil.Size = new System.Drawing.Size(81, 17);
            this.checkEstadoCivil.TabIndex = 2;
            this.checkEstadoCivil.Text = "Estado Civil";
            this.checkEstadoCivil.UseVisualStyleBackColor = true;
            this.checkEstadoCivil.CheckedChanged += new System.EventHandler(this.checkEstadoCivil_CheckedChanged);
            // 
            // checkEdad
            // 
            this.checkEdad.AutoSize = true;
            this.checkEdad.Location = new System.Drawing.Point(159, 19);
            this.checkEdad.Name = "checkEdad";
            this.checkEdad.Size = new System.Drawing.Size(51, 17);
            this.checkEdad.TabIndex = 1;
            this.checkEdad.Text = "Edad";
            this.checkEdad.UseVisualStyleBackColor = true;
            this.checkEdad.CheckedChanged += new System.EventHandler(this.checkEdad_CheckedChanged);
            // 
            // checkSexo
            // 
            this.checkSexo.AutoSize = true;
            this.checkSexo.Location = new System.Drawing.Point(26, 19);
            this.checkSexo.Name = "checkSexo";
            this.checkSexo.Size = new System.Drawing.Size(50, 17);
            this.checkSexo.TabIndex = 0;
            this.checkSexo.Text = "Sexo";
            this.checkSexo.UseVisualStyleBackColor = true;
            this.checkSexo.CheckedChanged += new System.EventHandler(this.checkSexo_CheckedChanged);
            // 
            // FRepPacienteExterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(841, 505);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FRepPacienteExterno";
            this.Text = "PACIENTES EXTERNOS";
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dtGVPacientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotalPacientes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEdad1;
        private System.Windows.Forms.ComboBox cBoxProcedencia;
        private System.Windows.Forms.ComboBox cBoxGradoInstruccion;
        private System.Windows.Forms.ComboBox cBoxEdad;
        private System.Windows.Forms.ComboBox cBoxEstadoCivil;
        private System.Windows.Forms.ComboBox cBoxSexo;
        private System.Windows.Forms.CheckBox checkProcedencia;
        private System.Windows.Forms.CheckBox checkGradoInstruccion;
        private System.Windows.Forms.CheckBox checkEstadoCivil;
        private System.Windows.Forms.CheckBox checkEdad;
        private System.Windows.Forms.CheckBox checkSexo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCHClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompletoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEdadActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEstadoCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCGradoInstruccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDepartamentoProcedencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEdad2;
        private System.Windows.Forms.Button btnMostrar;
    }
}