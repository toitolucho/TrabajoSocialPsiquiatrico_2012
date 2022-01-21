namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FFamiliaresPaciente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLblNombreCompleto = new System.Windows.Forms.ToolStripStatusLabel();
            this.gListadoFamiliares = new System.Windows.Forms.GroupBox();
            this.dtgvListadoFamiliares = new System.Windows.Forms.DataGridView();
            this.DGCNumeroFamiliar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreApellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCIntruccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreParentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCEdad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.gListadoFamiliares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListadoFamiliares)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsLblNombreCompleto});
            this.statusStrip1.Location = new System.Drawing.Point(0, 175);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(596, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(161, 17);
            this.toolStripStatusLabel1.Text = "Nombre Completo Paciente :";
            // 
            // tsLblNombreCompleto
            // 
            this.tsLblNombreCompleto.Name = "tsLblNombreCompleto";
            this.tsLblNombreCompleto.Size = new System.Drawing.Size(10, 17);
            this.tsLblNombreCompleto.Text = " ";
            // 
            // gListadoFamiliares
            // 
            this.gListadoFamiliares.Controls.Add(this.dtgvListadoFamiliares);
            this.gListadoFamiliares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gListadoFamiliares.Location = new System.Drawing.Point(0, 0);
            this.gListadoFamiliares.Name = "gListadoFamiliares";
            this.gListadoFamiliares.Size = new System.Drawing.Size(596, 144);
            this.gListadoFamiliares.TabIndex = 1;
            this.gListadoFamiliares.TabStop = false;
            this.gListadoFamiliares.Text = "Listado de Familiares";
            // 
            // dtgvListadoFamiliares
            // 
            this.dtgvListadoFamiliares.AllowUserToAddRows = false;
            this.dtgvListadoFamiliares.AllowUserToDeleteRows = false;
            this.dtgvListadoFamiliares.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvListadoFamiliares.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvListadoFamiliares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvListadoFamiliares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCNumeroFamiliar,
            this.DGCNombreApellidos,
            this.DGCIntruccion,
            this.DGCCivil,
            this.DGCNombreParentesco,
            this.DGCEdad});
            this.dtgvListadoFamiliares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvListadoFamiliares.Location = new System.Drawing.Point(3, 16);
            this.dtgvListadoFamiliares.MultiSelect = false;
            this.dtgvListadoFamiliares.Name = "dtgvListadoFamiliares";
            this.dtgvListadoFamiliares.ReadOnly = true;
            this.dtgvListadoFamiliares.RowHeadersVisible = false;
            this.dtgvListadoFamiliares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvListadoFamiliares.Size = new System.Drawing.Size(590, 125);
            this.dtgvListadoFamiliares.TabIndex = 0;
            this.dtgvListadoFamiliares.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvListadoFamiliares_CellDoubleClick);
            // 
            // DGCNumeroFamiliar
            // 
            this.DGCNumeroFamiliar.DataPropertyName = "NumeroFamiliar";
            this.DGCNumeroFamiliar.HeaderText = "Nro";
            this.DGCNumeroFamiliar.Name = "DGCNumeroFamiliar";
            this.DGCNumeroFamiliar.ReadOnly = true;
            this.DGCNumeroFamiliar.ToolTipText = "Numero de Paciente";
            this.DGCNumeroFamiliar.Width = 35;
            // 
            // DGCNombreApellidos
            // 
            this.DGCNombreApellidos.DataPropertyName = "NombreApellidos";
            this.DGCNombreApellidos.HeaderText = "Nombre Completo";
            this.DGCNombreApellidos.Name = "DGCNombreApellidos";
            this.DGCNombreApellidos.ReadOnly = true;
            this.DGCNombreApellidos.Width = 250;
            // 
            // DGCIntruccion
            // 
            this.DGCIntruccion.DataPropertyName = "Intruccion";
            this.DGCIntruccion.HeaderText = "Instrucción";
            this.DGCIntruccion.Name = "DGCIntruccion";
            this.DGCIntruccion.ReadOnly = true;
            // 
            // DGCCivil
            // 
            this.DGCCivil.DataPropertyName = "Civil";
            this.DGCCivil.HeaderText = "Estado Civil";
            this.DGCCivil.Name = "DGCCivil";
            this.DGCCivil.ReadOnly = true;
            // 
            // DGCNombreParentesco
            // 
            this.DGCNombreParentesco.DataPropertyName = "NombreParentesco";
            this.DGCNombreParentesco.HeaderText = "Parentesco";
            this.DGCNombreParentesco.Name = "DGCNombreParentesco";
            this.DGCNombreParentesco.ReadOnly = true;
            // 
            // DGCEdad
            // 
            this.DGCEdad.DataPropertyName = "Edad";
            this.DGCEdad.HeaderText = "Edad";
            this.DGCEdad.Name = "DGCEdad";
            this.DGCEdad.ReadOnly = true;
            this.DGCEdad.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 144);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(596, 31);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(518, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(437, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FFamiliaresPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(596, 197);
            this.Controls.Add(this.gListadoFamiliares);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FFamiliaresPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAMILIARES DEL PACIENTE";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gListadoFamiliares.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListadoFamiliares)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox gListadoFamiliares;
        private System.Windows.Forms.DataGridView dtgvListadoFamiliares;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsLblNombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNumeroFamiliar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreApellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCIntruccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreParentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCEdad;
    }
}