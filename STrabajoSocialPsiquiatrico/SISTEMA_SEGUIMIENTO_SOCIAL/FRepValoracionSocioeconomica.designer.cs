namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepValoracionSocioeconomica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepValoracionSocioeconomica));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnAmbos = new System.Windows.Forms.RadioButton();
            this.rbtnPacientesExternos = new System.Windows.Forms.RadioButton();
            this.rbtnPacientesInternos = new System.Windows.Forms.RadioButton();
            this.dtGVPacientes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtTotalPacientes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cBoxCategoria = new System.Windows.Forms.ComboBox();
            this.checkCategoria = new System.Windows.Forms.CheckBox();
            this.cBoxEspecialidad = new System.Windows.Forms.ComboBox();
            this.checkEspecialidad = new System.Windows.Forms.CheckBox();
            this.cBoxSexo = new System.Windows.Forms.ComboBox();
            this.checkSexo = new System.Windows.Forms.CheckBox();
            this.checkCantidad = new System.Windows.Forms.CheckBox();
            this.cBoxServicio = new System.Windows.Forms.ComboBox();
            this.checkServicio = new System.Windows.Forms.CheckBox();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DGCFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCompletoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnListar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnAmbos);
            this.groupBox2.Controls.Add(this.rbtnPacientesExternos);
            this.groupBox2.Controls.Add(this.rbtnPacientesInternos);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(8, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 50);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterios de Búsqueda";
            // 
            // rbtnAmbos
            // 
            this.rbtnAmbos.AutoSize = true;
            this.rbtnAmbos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnAmbos.Location = new System.Drawing.Point(579, 22);
            this.rbtnAmbos.Name = "rbtnAmbos";
            this.rbtnAmbos.Size = new System.Drawing.Size(57, 17);
            this.rbtnAmbos.TabIndex = 20;
            this.rbtnAmbos.TabStop = true;
            this.rbtnAmbos.Text = "Ambos";
            this.rbtnAmbos.UseVisualStyleBackColor = true;
            // 
            // rbtnPacientesExternos
            // 
            this.rbtnPacientesExternos.AutoSize = true;
            this.rbtnPacientesExternos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnPacientesExternos.Location = new System.Drawing.Point(330, 22);
            this.rbtnPacientesExternos.Name = "rbtnPacientesExternos";
            this.rbtnPacientesExternos.Size = new System.Drawing.Size(116, 17);
            this.rbtnPacientesExternos.TabIndex = 19;
            this.rbtnPacientesExternos.TabStop = true;
            this.rbtnPacientesExternos.Text = "Pacientes Externos";
            this.rbtnPacientesExternos.UseVisualStyleBackColor = true;
            // 
            // rbtnPacientesInternos
            // 
            this.rbtnPacientesInternos.AutoSize = true;
            this.rbtnPacientesInternos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnPacientesInternos.Location = new System.Drawing.Point(84, 22);
            this.rbtnPacientesInternos.Name = "rbtnPacientesInternos";
            this.rbtnPacientesInternos.Size = new System.Drawing.Size(113, 17);
            this.rbtnPacientesInternos.TabIndex = 0;
            this.rbtnPacientesInternos.TabStop = true;
            this.rbtnPacientesInternos.Text = "Pacientes Internos";
            this.rbtnPacientesInternos.UseVisualStyleBackColor = true;
            // 
            // dtGVPacientes
            // 
            this.dtGVPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCFechaIngreso,
            this.DGCNombreCompletoPaciente,
            this.DGCSexo,
            this.DGCNombreServicio,
            this.DGCNombreEspecialidad,
            this.DGCCategoria});
            this.dtGVPacientes.Location = new System.Drawing.Point(7, 15);
            this.dtGVPacientes.Name = "dtGVPacientes";
            this.dtGVPacientes.Size = new System.Drawing.Size(753, 275);
            this.dtGVPacientes.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnListar);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.txtTotalPacientes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 485);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 43);
            this.panel1.TabIndex = 14;
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.ImageIndex = 0;
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(696, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(74, 31);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
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
            this.btnCancelar.Location = new System.Drawing.Point(616, 4);
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
            this.btnImprimir.Location = new System.Drawing.Point(536, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(74, 31);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtTotalPacientes
            // 
            this.txtTotalPacientes.Location = new System.Drawing.Point(153, 9);
            this.txtTotalPacientes.Name = "txtTotalPacientes";
            this.txtTotalPacientes.Size = new System.Drawing.Size(70, 20);
            this.txtTotalPacientes.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cantidad de Pacientes :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGVPacientes);
            this.groupBox1.Location = new System.Drawing.Point(9, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 296);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cBoxCategoria);
            this.groupBox3.Controls.Add(this.checkCategoria);
            this.groupBox3.Controls.Add(this.cBoxEspecialidad);
            this.groupBox3.Controls.Add(this.checkEspecialidad);
            this.groupBox3.Controls.Add(this.cBoxSexo);
            this.groupBox3.Controls.Add(this.checkSexo);
            this.groupBox3.Controls.Add(this.checkCantidad);
            this.groupBox3.Controls.Add(this.cBoxServicio);
            this.groupBox3.Controls.Add(this.checkServicio);
            this.groupBox3.Controls.Add(this.dateFechaInicio);
            this.groupBox3.Controls.Add(this.dateFechaFin);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(9, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(767, 136);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // cBoxCategoria
            // 
            this.cBoxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCategoria.Enabled = false;
            this.cBoxCategoria.FormattingEnabled = true;
            this.cBoxCategoria.Location = new System.Drawing.Point(619, 37);
            this.cBoxCategoria.Name = "cBoxCategoria";
            this.cBoxCategoria.Size = new System.Drawing.Size(97, 21);
            this.cBoxCategoria.TabIndex = 31;
            // 
            // checkCategoria
            // 
            this.checkCategoria.AutoSize = true;
            this.checkCategoria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkCategoria.Location = new System.Drawing.Point(619, 19);
            this.checkCategoria.Name = "checkCategoria";
            this.checkCategoria.Size = new System.Drawing.Size(73, 17);
            this.checkCategoria.TabIndex = 30;
            this.checkCategoria.Text = "Categoría";
            this.checkCategoria.UseVisualStyleBackColor = true;
            this.checkCategoria.CheckedChanged += new System.EventHandler(this.checkCategoria_CheckedChanged);
            // 
            // cBoxEspecialidad
            // 
            this.cBoxEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxEspecialidad.Enabled = false;
            this.cBoxEspecialidad.FormattingEnabled = true;
            this.cBoxEspecialidad.Location = new System.Drawing.Point(249, 36);
            this.cBoxEspecialidad.Name = "cBoxEspecialidad";
            this.cBoxEspecialidad.Size = new System.Drawing.Size(167, 21);
            this.cBoxEspecialidad.TabIndex = 29;
            // 
            // checkEspecialidad
            // 
            this.checkEspecialidad.AutoSize = true;
            this.checkEspecialidad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkEspecialidad.Location = new System.Drawing.Point(249, 18);
            this.checkEspecialidad.Name = "checkEspecialidad";
            this.checkEspecialidad.Size = new System.Drawing.Size(86, 17);
            this.checkEspecialidad.TabIndex = 28;
            this.checkEspecialidad.Text = "Especialidad";
            this.checkEspecialidad.UseVisualStyleBackColor = true;
            this.checkEspecialidad.CheckedChanged += new System.EventHandler(this.checkEspecialidad_CheckedChanged);
            // 
            // cBoxSexo
            // 
            this.cBoxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSexo.Enabled = false;
            this.cBoxSexo.FormattingEnabled = true;
            this.cBoxSexo.Location = new System.Drawing.Point(464, 36);
            this.cBoxSexo.Name = "cBoxSexo";
            this.cBoxSexo.Size = new System.Drawing.Size(105, 21);
            this.cBoxSexo.TabIndex = 27;
            // 
            // checkSexo
            // 
            this.checkSexo.AutoSize = true;
            this.checkSexo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkSexo.Location = new System.Drawing.Point(464, 18);
            this.checkSexo.Name = "checkSexo";
            this.checkSexo.Size = new System.Drawing.Size(50, 17);
            this.checkSexo.TabIndex = 26;
            this.checkSexo.Text = "Sexo";
            this.checkSexo.UseVisualStyleBackColor = true;
            this.checkSexo.CheckedChanged += new System.EventHandler(this.checkSexo_CheckedChanged);
            // 
            // checkCantidad
            // 
            this.checkCantidad.AutoSize = true;
            this.checkCantidad.ForeColor = System.Drawing.Color.RoyalBlue;
            this.checkCantidad.Location = new System.Drawing.Point(51, 74);
            this.checkCantidad.Name = "checkCantidad";
            this.checkCantidad.Size = new System.Drawing.Size(353, 17);
            this.checkCantidad.TabIndex = 25;
            this.checkCantidad.Text = "Cantidad Total de Servicios Brindados con su respectiva Subvención";
            this.checkCantidad.UseVisualStyleBackColor = true;
            // 
            // cBoxServicio
            // 
            this.cBoxServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxServicio.Enabled = false;
            this.cBoxServicio.FormattingEnabled = true;
            this.cBoxServicio.Location = new System.Drawing.Point(48, 36);
            this.cBoxServicio.Name = "cBoxServicio";
            this.cBoxServicio.Size = new System.Drawing.Size(153, 21);
            this.cBoxServicio.TabIndex = 24;
            // 
            // checkServicio
            // 
            this.checkServicio.AutoSize = true;
            this.checkServicio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkServicio.Location = new System.Drawing.Point(49, 18);
            this.checkServicio.Name = "checkServicio";
            this.checkServicio.Size = new System.Drawing.Size(64, 17);
            this.checkServicio.TabIndex = 23;
            this.checkServicio.Text = "Servicio";
            this.checkServicio.UseVisualStyleBackColor = true;
            this.checkServicio.CheckedChanged += new System.EventHandler(this.checkServicio_CheckedChanged);
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaInicio.Location = new System.Drawing.Point(165, 105);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(188, 20);
            this.dateFechaInicio.TabIndex = 22;
            // 
            // dateFechaFin
            // 
            this.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaFin.Location = new System.Drawing.Point(451, 105);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Size = new System.Drawing.Size(188, 20);
            this.dateFechaFin.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(115, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Desde :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(404, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Hasta :";
            // 
            // DGCFechaIngreso
            // 
            this.DGCFechaIngreso.DataPropertyName = "FechaIngreso";
            this.DGCFechaIngreso.HeaderText = "Fecha";
            this.DGCFechaIngreso.Name = "DGCFechaIngreso";
            this.DGCFechaIngreso.Width = 80;
            // 
            // DGCNombreCompletoPaciente
            // 
            this.DGCNombreCompletoPaciente.DataPropertyName = "NombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.HeaderText = "Nombre del Paciente";
            this.DGCNombreCompletoPaciente.Name = "DGCNombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.Width = 220;
            // 
            // DGCSexo
            // 
            this.DGCSexo.DataPropertyName = "Sexo";
            this.DGCSexo.HeaderText = "Sexo";
            this.DGCSexo.Name = "DGCSexo";
            // 
            // DGCNombreServicio
            // 
            this.DGCNombreServicio.DataPropertyName = "NombreServicio";
            this.DGCNombreServicio.HeaderText = "Servicio";
            this.DGCNombreServicio.Name = "DGCNombreServicio";
            this.DGCNombreServicio.Width = 190;
            // 
            // DGCNombreEspecialidad
            // 
            this.DGCNombreEspecialidad.DataPropertyName = "NombreEspecialidad";
            this.DGCNombreEspecialidad.HeaderText = "Especialidad";
            this.DGCNombreEspecialidad.Name = "DGCNombreEspecialidad";
            this.DGCNombreEspecialidad.Width = 150;
            // 
            // DGCCategoria
            // 
            this.DGCCategoria.DataPropertyName = "Categoria";
            this.DGCCategoria.HeaderText = "Categoría";
            this.DGCCategoria.Name = "DGCCategoria";
            // 
            // btnListar
            // 
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.ImageIndex = 1;
            this.btnListar.ImageList = this.imageList1;
            this.btnListar.Location = new System.Drawing.Point(456, 3);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(74, 31);
            this.btnListar.TabIndex = 9;
            this.btnListar.Text = "&Listar";
            this.btnListar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // FRepValoracionSocioeconomica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(781, 527);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Name = "FRepValoracionSocioeconomica";
            this.Text = "REPORTE DE VALORACIÓN SOCIOECONÓMICA";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnAmbos;
        private System.Windows.Forms.RadioButton rbtnPacientesExternos;
        private System.Windows.Forms.RadioButton rbtnPacientesInternos;
        private System.Windows.Forms.DataGridView dtGVPacientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtTotalPacientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cBoxCategoria;
        private System.Windows.Forms.CheckBox checkCategoria;
        private System.Windows.Forms.ComboBox cBoxEspecialidad;
        private System.Windows.Forms.CheckBox checkEspecialidad;
        private System.Windows.Forms.ComboBox cBoxSexo;
        private System.Windows.Forms.CheckBox checkSexo;
        private System.Windows.Forms.CheckBox checkCantidad;
        private System.Windows.Forms.ComboBox cBoxServicio;
        private System.Windows.Forms.CheckBox checkServicio;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompletoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCategoria;
        private System.Windows.Forms.Button btnListar;
    }
}