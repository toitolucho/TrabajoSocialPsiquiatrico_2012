namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepInterconsultaRealizada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepInterconsultaRealizada));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkCantidades = new System.Windows.Forms.CheckBox();
            this.cBoxSexo = new System.Windows.Forms.ComboBox();
            this.checkSexo = new System.Windows.Forms.CheckBox();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnInterconsultas = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtGVPacientes = new System.Windows.Forms.DataGridView();
            this.DGCFechaOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCompletoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreUnidadMedica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTramite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCMedicoSolicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreUnidadMedica2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exit.png");
            this.imageList1.Images.SetKeyName(1, "Printer v2.png");
            this.imageList1.Images.SetKeyName(2, "Undo.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkCantidades);
            this.groupBox2.Controls.Add(this.cBoxSexo);
            this.groupBox2.Controls.Add(this.checkSexo);
            this.groupBox2.Controls.Add(this.dateFechaInicio);
            this.groupBox2.Controls.Add(this.dateFechaFin);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rbtnInterconsultas);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(8, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(771, 107);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterios de Búsqueda";
            // 
            // checkCantidades
            // 
            this.checkCantidades.AutoSize = true;
            this.checkCantidades.Location = new System.Drawing.Point(366, 73);
            this.checkCantidades.Name = "checkCantidades";
            this.checkCantidades.Size = new System.Drawing.Size(343, 17);
            this.checkCantidades.TabIndex = 18;
            this.checkCantidades.Text = "Cantidad Total de Pacientes Interconsultados, ordenado por meses";
            this.checkCantidades.UseVisualStyleBackColor = true;
            // 
            // cBoxSexo
            // 
            this.cBoxSexo.Enabled = false;
            this.cBoxSexo.FormattingEnabled = true;
            this.cBoxSexo.Location = new System.Drawing.Point(27, 73);
            this.cBoxSexo.Name = "cBoxSexo";
            this.cBoxSexo.Size = new System.Drawing.Size(97, 21);
            this.cBoxSexo.TabIndex = 17;
            // 
            // checkSexo
            // 
            this.checkSexo.AutoSize = true;
            this.checkSexo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkSexo.Location = new System.Drawing.Point(28, 55);
            this.checkSexo.Name = "checkSexo";
            this.checkSexo.Size = new System.Drawing.Size(50, 17);
            this.checkSexo.TabIndex = 16;
            this.checkSexo.Text = "Sexo";
            this.checkSexo.UseVisualStyleBackColor = true;
            this.checkSexo.CheckedChanged += new System.EventHandler(this.checkSexo_CheckedChanged);
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaInicio.Location = new System.Drawing.Point(301, 25);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(157, 20);
            this.dateFechaInicio.TabIndex = 15;
            // 
            // dateFechaFin
            // 
            this.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaFin.Location = new System.Drawing.Point(552, 25);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Size = new System.Drawing.Size(157, 20);
            this.dateFechaFin.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(251, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Desde :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(505, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hasta :";
            // 
            // rbtnInterconsultas
            // 
            this.rbtnInterconsultas.AutoSize = true;
            this.rbtnInterconsultas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnInterconsultas.Location = new System.Drawing.Point(27, 25);
            this.rbtnInterconsultas.Name = "rbtnInterconsultas";
            this.rbtnInterconsultas.Size = new System.Drawing.Size(146, 17);
            this.rbtnInterconsultas.TabIndex = 0;
            this.rbtnInterconsultas.TabStop = true;
            this.rbtnInterconsultas.Text = "Interconsultas Realizadas";
            this.rbtnInterconsultas.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtGVPacientes);
            this.groupBox3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox3.Location = new System.Drawing.Point(7, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(772, 313);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // dtGVPacientes
            // 
            this.dtGVPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCFechaOperacion,
            this.DGCNombreCompletoPaciente,
            this.DGCNombreUnidadMedica,
            this.Column7,
            this.DGCTramite,
            this.DGCMedicoSolicitante,
            this.DGCNombreUnidadMedica2,
            this.DGCNombreEspecialidad});
            this.dtGVPacientes.Location = new System.Drawing.Point(6, 16);
            this.dtGVPacientes.Name = "dtGVPacientes";
            this.dtGVPacientes.Size = new System.Drawing.Size(760, 291);
            this.dtGVPacientes.TabIndex = 0;
            // 
            // DGCFechaOperacion
            // 
            this.DGCFechaOperacion.DataPropertyName = "FechaOperacion";
            this.DGCFechaOperacion.HeaderText = "Fecha Interconsulta";
            this.DGCFechaOperacion.Name = "DGCFechaOperacion";
            this.DGCFechaOperacion.Width = 80;
            // 
            // DGCNombreCompletoPaciente
            // 
            this.DGCNombreCompletoPaciente.DataPropertyName = "NombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.HeaderText = "Nombre del Paciente";
            this.DGCNombreCompletoPaciente.Name = "DGCNombreCompletoPaciente";
            this.DGCNombreCompletoPaciente.Width = 220;
            // 
            // DGCNombreUnidadMedica
            // 
            this.DGCNombreUnidadMedica.DataPropertyName = "NombreUnidadMedica";
            this.DGCNombreUnidadMedica.HeaderText = "Unidad";
            this.DGCNombreUnidadMedica.Name = "DGCNombreUnidadMedica";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Sección";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // DGCTramite
            // 
            this.DGCTramite.DataPropertyName = "Tramite";
            this.DGCTramite.HeaderText = "Trámite";
            this.DGCTramite.Name = "DGCTramite";
            // 
            // DGCMedicoSolicitante
            // 
            this.DGCMedicoSolicitante.DataPropertyName = "MedicoSolicitante";
            this.DGCMedicoSolicitante.HeaderText = "Médico Solicitante";
            this.DGCMedicoSolicitante.Name = "DGCMedicoSolicitante";
            this.DGCMedicoSolicitante.Width = 190;
            // 
            // DGCNombreUnidadMedica2
            // 
            this.DGCNombreUnidadMedica2.DataPropertyName = "NombreUnidadMedica2";
            this.DGCNombreUnidadMedica2.HeaderText = "Unidad Médica";
            this.DGCNombreUnidadMedica2.Name = "DGCNombreUnidadMedica2";
            this.DGCNombreUnidadMedica2.Width = 190;
            // 
            // DGCNombreEspecialidad
            // 
            this.DGCNombreEspecialidad.DataPropertyName = "NombreEspecialidad";
            this.DGCNombreEspecialidad.HeaderText = "Especialidad";
            this.DGCNombreEspecialidad.Name = "DGCNombreEspecialidad";
            this.DGCNombreEspecialidad.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cantidad de Referencias :";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(153, 9);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(70, 20);
            this.txtCantidad.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-7, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 43);
            this.panel1.TabIndex = 11;
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.ImageIndex = 0;
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(708, 3);
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
            this.btnCancelar.Location = new System.Drawing.Point(628, 3);
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
            this.btnImprimir.Location = new System.Drawing.Point(548, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(74, 31);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // FRepInterconsultaRealizada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(788, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRepInterconsultaRealizada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INTERCONSULTAS REALIZADAS";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DataGridView dtGVPacientes;
        private System.Windows.Forms.RadioButton rbtnInterconsultas;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxSexo;
        private System.Windows.Forms.CheckBox checkSexo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.CheckBox checkCantidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompletoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreUnidadMedica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTramite;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCMedicoSolicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreUnidadMedica2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreEspecialidad;
    }
}