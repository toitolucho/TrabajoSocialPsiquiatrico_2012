namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepServiciosBrindados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepServiciosBrindados));
            this.dtGVPacientes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtTotalPacientes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkCantidad = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTextoBusquedaPaciente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DGCFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCompletoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCHClinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCTipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoClaseServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCostoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCMontoCancelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDiferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGVPacientes
            // 
            this.dtGVPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCFechaIngreso,
            this.DGCNombreCompletoPaciente,
            this.DGCHClinico,
            this.DGCTipoServicio,
            this.DGCCodigoClaseServicio,
            this.DGCNombreServicio,
            this.DGCCostoServicio,
            this.DGCMontoCancelado,
            this.DGCDiferencia,
            this.DGCCategoria});
            this.dtGVPacientes.Location = new System.Drawing.Point(6, 13);
            this.dtGVPacientes.Name = "dtGVPacientes";
            this.dtGVPacientes.Size = new System.Drawing.Size(796, 345);
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
            this.panel1.Location = new System.Drawing.Point(-2, 471);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 39);
            this.panel1.TabIndex = 14;
            // 
            // btnListar
            // 
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.ImageIndex = 1;
            this.btnListar.ImageList = this.imageList1;
            this.btnListar.Location = new System.Drawing.Point(485, 2);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(74, 31);
            this.btnListar.TabIndex = 9;
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
            // btnCerrar
            // 
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.ImageIndex = 0;
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(725, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(74, 31);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 2;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(645, 2);
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
            this.btnImprimir.Location = new System.Drawing.Point(565, 2);
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
            this.txtTotalPacientes.Location = new System.Drawing.Point(153, 6);
            this.txtTotalPacientes.Name = "txtTotalPacientes";
            this.txtTotalPacientes.Size = new System.Drawing.Size(70, 20);
            this.txtTotalPacientes.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cantidad de Pacientes :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGVPacientes);
            this.groupBox1.Location = new System.Drawing.Point(6, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 365);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // checkCantidad
            // 
            this.checkCantidad.AutoSize = true;
            this.checkCantidad.ForeColor = System.Drawing.Color.RoyalBlue;
            this.checkCantidad.Location = new System.Drawing.Point(19, 50);
            this.checkCantidad.Name = "checkCantidad";
            this.checkCantidad.Size = new System.Drawing.Size(348, 17);
            this.checkCantidad.TabIndex = 25;
            this.checkCantidad.Text = "Cuadro General de Servicios Brindados con su respectiva Categoría";
            this.checkCantidad.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dateFechaFin);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dateFechaInicio);
            this.panel2.Location = new System.Drawing.Point(6, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(807, 35);
            this.panel2.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(122, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Periodo ";
            // 
            // dateFechaFin
            // 
            this.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaFin.Location = new System.Drawing.Point(580, 7);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Size = new System.Drawing.Size(142, 20);
            this.dateFechaFin.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(533, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Hasta :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(190, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Desde :";
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaInicio.Location = new System.Drawing.Point(240, 7);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(142, 20);
            this.dateFechaInicio.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtTextoBusquedaPaciente
            // 
            this.txtTextoBusquedaPaciente.Location = new System.Drawing.Point(88, 12);
            this.txtTextoBusquedaPaciente.Name = "txtTextoBusquedaPaciente";
            this.txtTextoBusquedaPaciente.Size = new System.Drawing.Size(474, 20);
            this.txtTextoBusquedaPaciente.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Paciente :";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(654, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 17);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.Text = "Desde su 1ra Consulta";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DGCFechaIngreso
            // 
            this.DGCFechaIngreso.DataPropertyName = "FechaIngreso";
            this.DGCFechaIngreso.HeaderText = "Fecha Subvención";
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
            // DGCHClinico
            // 
            this.DGCHClinico.DataPropertyName = "HClinico";
            this.DGCHClinico.HeaderText = "H. Clínico";
            this.DGCHClinico.Name = "DGCHClinico";
            // 
            // DGCTipoServicio
            // 
            this.DGCTipoServicio.DataPropertyName = "TipoServicio";
            this.DGCTipoServicio.HeaderText = "Tipo Servicio";
            this.DGCTipoServicio.Name = "DGCTipoServicio";
            // 
            // DGCCodigoClaseServicio
            // 
            this.DGCCodigoClaseServicio.DataPropertyName = "CodigoClaseServicio";
            this.DGCCodigoClaseServicio.HeaderText = "Clase Servicio";
            this.DGCCodigoClaseServicio.Name = "DGCCodigoClaseServicio";
            // 
            // DGCNombreServicio
            // 
            this.DGCNombreServicio.DataPropertyName = "NombreServicio";
            this.DGCNombreServicio.HeaderText = "Servicio Brindado";
            this.DGCNombreServicio.Name = "DGCNombreServicio";
            this.DGCNombreServicio.Width = 190;
            // 
            // DGCCostoServicio
            // 
            this.DGCCostoServicio.DataPropertyName = "CostoServicio";
            this.DGCCostoServicio.HeaderText = "Precio";
            this.DGCCostoServicio.Name = "DGCCostoServicio";
            // 
            // DGCMontoCancelado
            // 
            this.DGCMontoCancelado.DataPropertyName = "MontoCancelado";
            this.DGCMontoCancelado.HeaderText = "Subvención";
            this.DGCMontoCancelado.Name = "DGCMontoCancelado";
            // 
            // DGCDiferencia
            // 
            this.DGCDiferencia.DataPropertyName = "Diferencia";
            this.DGCDiferencia.HeaderText = "Diferencia Económica";
            this.DGCDiferencia.Name = "DGCDiferencia";
            // 
            // DGCCategoria
            // 
            this.DGCCategoria.DataPropertyName = "Categoria";
            this.DGCCategoria.HeaderText = "Categoría";
            this.DGCCategoria.Name = "DGCCategoria";
            // 
            // FRepServiciosBrindados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(818, 509);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkCantidad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTextoBusquedaPaciente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FRepServiciosBrindados";
            this.Text = "REPORTE DE SERVICIOS BRINDADOS";
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPacientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGVPacientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtTotalPacientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkCantidad;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTextoBusquedaPaciente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCFechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompletoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCHClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCTipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoClaseServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCostoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCMontoCancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDiferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCategoria;
    }
}