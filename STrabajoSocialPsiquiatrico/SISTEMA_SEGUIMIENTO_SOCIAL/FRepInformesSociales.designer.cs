namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FRepInformeSocial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepInformeSocial));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkTrabajdoraSocial = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.cBoxTrabajadoraSocial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Printer v2.png");
            this.imageList1.Images.SetKeyName(1, "Undo.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(6, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 122);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterios de Búsqueda";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.Controls.Add(this.checkTrabajdoraSocial);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.dateTimePicker2);
            this.panel3.Controls.Add(this.btnImprimir);
            this.panel3.Controls.Add(this.cBoxTrabajadoraSocial);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(2, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(502, 66);
            this.panel3.TabIndex = 47;
            // 
            // checkTrabajdoraSocial
            // 
            this.checkTrabajdoraSocial.AutoSize = true;
            this.checkTrabajdoraSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTrabajdoraSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkTrabajdoraSocial.Location = new System.Drawing.Point(13, 36);
            this.checkTrabajdoraSocial.Name = "checkTrabajdoraSocial";
            this.checkTrabajdoraSocial.Size = new System.Drawing.Size(116, 17);
            this.checkTrabajdoraSocial.TabIndex = 48;
            this.checkTrabajdoraSocial.Text = "Trabajo Social :";
            this.checkTrabajdoraSocial.UseVisualStyleBackColor = true;
            this.checkTrabajdoraSocial.CheckedChanged += new System.EventHandler(this.checkTrabajdoraSocial_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(298, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 1;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(420, 34);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 31);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(114, 8);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker2.TabIndex = 15;
            // 
            // btnImprimir
            // 
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.ImageIndex = 0;
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(420, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(74, 31);
            this.btnImprimir.TabIndex = 13;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cBoxTrabajadoraSocial
            // 
            this.cBoxTrabajadoraSocial.FormattingEnabled = true;
            this.cBoxTrabajadoraSocial.Location = new System.Drawing.Point(131, 34);
            this.cBoxTrabajadoraSocial.Name = "cBoxTrabajadoraSocial";
            this.cBoxTrabajadoraSocial.Size = new System.Drawing.Size(268, 21);
            this.cBoxTrabajadoraSocial.TabIndex = 52;            
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(237, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Hasta :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(64, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Desde :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(10, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Fecha :";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton1.Location = new System.Drawing.Point(27, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(163, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Informes Sociales Realizadas";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // FRepInformeSocial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 127);
            this.Controls.Add(this.groupBox2);
            this.Name = "FRepInformeSocial";
            this.Text = "INFORMES SOCIALES REALIZADOS";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox cBoxTrabajadoraSocial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkTrabajdoraSocial;
    }
}