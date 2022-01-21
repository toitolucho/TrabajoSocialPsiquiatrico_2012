namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepActividadesDiarias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepActividadesDiarias));
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAñadirUsuario = new System.Windows.Forms.Button();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.cBoxTrabajadoraSocial = new System.Windows.Forms.ComboBox();
            this.rBtnActividadesDiarias = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.checkTrabajadoraSocial = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarUsuario.ImageIndex = 1;
            this.btnEliminarUsuario.ImageList = this.imageList1;
            this.btnEliminarUsuario.Location = new System.Drawing.Point(530, 117);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(74, 31);
            this.btnEliminarUsuario.TabIndex = 19;
            this.btnEliminarUsuario.Text = "&Cancelar";
            this.btnEliminarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Printer v2.png");
            this.imageList1.Images.SetKeyName(1, "Undo.png");
            // 
            // btnAñadirUsuario
            // 
            this.btnAñadirUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAñadirUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirUsuario.ImageIndex = 0;
            this.btnAñadirUsuario.ImageList = this.imageList1;
            this.btnAñadirUsuario.Location = new System.Drawing.Point(614, 117);
            this.btnAñadirUsuario.Name = "btnAñadirUsuario";
            this.btnAñadirUsuario.Size = new System.Drawing.Size(74, 31);
            this.btnAñadirUsuario.TabIndex = 18;
            this.btnAñadirUsuario.Text = "&Imprimir";
            this.btnAñadirUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirUsuario.UseVisualStyleBackColor = true;
            this.btnAñadirUsuario.Click += new System.EventHandler(this.btnAñadirUsuario_Click);
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaInicio.Location = new System.Drawing.Point(282, 9);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(114, 20);
            this.dateFechaInicio.TabIndex = 15;
            this.dateFechaInicio.ValueChanged += new System.EventHandler(this.dateFechaInicio_ValueChanged);
            // 
            // dateFechaFin
            // 
            this.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaFin.Location = new System.Drawing.Point(500, 9);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Size = new System.Drawing.Size(114, 20);
            this.dateFechaFin.TabIndex = 14;
            this.dateFechaFin.ValueChanged += new System.EventHandler(this.dateFechaFin_ValueChanged);
            // 
            // cBoxTrabajadoraSocial
            // 
            this.cBoxTrabajadoraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTrabajadoraSocial.FormattingEnabled = true;
            this.cBoxTrabajadoraSocial.Location = new System.Drawing.Point(556, 42);
            this.cBoxTrabajadoraSocial.Name = "cBoxTrabajadoraSocial";
            this.cBoxTrabajadoraSocial.Size = new System.Drawing.Size(220, 21);
            this.cBoxTrabajadoraSocial.TabIndex = 17;
            // 
            // rBtnActividadesDiarias
            // 
            this.rBtnActividadesDiarias.AutoSize = true;
            this.rBtnActividadesDiarias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnActividadesDiarias.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rBtnActividadesDiarias.Location = new System.Drawing.Point(12, 44);
            this.rBtnActividadesDiarias.Name = "rBtnActividadesDiarias";
            this.rBtnActividadesDiarias.Size = new System.Drawing.Size(402, 17);
            this.rBtnActividadesDiarias.TabIndex = 0;
            this.rBtnActividadesDiarias.TabStop = true;
            this.rBtnActividadesDiarias.Text = "Cuadro General de Cantidades de Actividades realizadas clasificados por meses";
            this.rBtnActividadesDiarias.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateFechaFin);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateFechaInicio);
            this.panel1.Location = new System.Drawing.Point(-3, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 40);
            this.panel1.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(453, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Hasta :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(235, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Desde :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(143, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Periodo ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.radioButton5.Location = new System.Drawing.Point(12, 12);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(293, 17);
            this.radioButton5.TabIndex = 36;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Listado General de Cantidades de Actividades realizadas";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.ImageIndex = 0;
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(698, 117);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(74, 31);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // checkTrabajadoraSocial
            // 
            this.checkTrabajadoraSocial.AutoSize = true;
            this.checkTrabajadoraSocial.Location = new System.Drawing.Point(432, 44);
            this.checkTrabajadoraSocial.Name = "checkTrabajadoraSocial";
            this.checkTrabajadoraSocial.Size = new System.Drawing.Size(121, 17);
            this.checkTrabajadoraSocial.TabIndex = 37;
            this.checkTrabajadoraSocial.Text = "Trabajadora Social :";
            this.checkTrabajadoraSocial.UseVisualStyleBackColor = true;
            this.checkTrabajadoraSocial.CheckedChanged += new System.EventHandler(this.checkTrabajadoraSocial_CheckedChanged);
            // 
            // FRepActividadesDiarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(781, 151);
            this.Controls.Add(this.checkTrabajadoraSocial);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAñadirUsuario);
            this.Controls.Add(this.rBtnActividadesDiarias);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.cBoxTrabajadoraSocial);
            this.Name = "FRepActividadesDiarias";
            this.Text = "ACTVIDADES DIARIAS REALIZADAS";
            this.Load += new System.EventHandler(this.FRepEvacionesPacientes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAñadirUsuario;
        private System.Windows.Forms.ComboBox cBoxTrabajadoraSocial;
        private System.Windows.Forms.RadioButton rBtnActividadesDiarias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox checkTrabajadoraSocial;
    }
}