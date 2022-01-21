namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FGeograficoBusqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGeograficoBusqueda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bdNavRegiones = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bdSourceRegiones = new System.Windows.Forms.BindingSource(this.components);
            this.dtGVRegiones = new System.Windows.Forms.DataGridView();
            this.txtTextoBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.DGCCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoLocalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavRegiones)).BeginInit();
            this.bdNavRegiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceRegiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVRegiones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTextoBusqueda);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Introduzca los Datos";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 155);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(419, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // bdNavRegiones
            // 
            this.bdNavRegiones.AddNewItem = null;
            this.bdNavRegiones.BindingSource = this.bdSourceRegiones;
            this.bdNavRegiones.CountItem = this.bindingNavigatorCountItem;
            this.bdNavRegiones.DeleteItem = null;
            this.bdNavRegiones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bdNavRegiones.Location = new System.Drawing.Point(0, 44);
            this.bdNavRegiones.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdNavRegiones.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdNavRegiones.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdNavRegiones.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdNavRegiones.Name = "bdNavRegiones";
            this.bdNavRegiones.PositionItem = this.bindingNavigatorPositionItem;
            this.bdNavRegiones.Size = new System.Drawing.Size(419, 25);
            this.bdNavRegiones.TabIndex = 2;
            this.bdNavRegiones.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // dtGVRegiones
            // 
            this.dtGVRegiones.AllowUserToAddRows = false;
            this.dtGVRegiones.AllowUserToDeleteRows = false;
            this.dtGVRegiones.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVRegiones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVRegiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVRegiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigo,
            this.DGCCodigoPais,
            this.DGCCodigoDepartamento,
            this.DGCCodigoProvincia,
            this.DGCCodigoLocalidad,
            this.DGCNombreRegion});
            this.dtGVRegiones.DataSource = this.bdSourceRegiones;
            this.dtGVRegiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVRegiones.Location = new System.Drawing.Point(0, 69);
            this.dtGVRegiones.Name = "dtGVRegiones";
            this.dtGVRegiones.ReadOnly = true;
            this.dtGVRegiones.Size = new System.Drawing.Size(419, 86);
            this.dtGVRegiones.TabIndex = 3;
            this.dtGVRegiones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVRegiones_CellDoubleClick);
            // 
            // txtTextoBusqueda
            // 
            this.txtTextoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextoBusqueda.Location = new System.Drawing.Point(119, 16);
            this.txtTextoBusqueda.Name = "txtTextoBusqueda";
            this.txtTextoBusqueda.Size = new System.Drawing.Size(221, 20);
            this.txtTextoBusqueda.TabIndex = 0;
            this.txtTextoBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTextoBusqueda_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Texto de Busqueda";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(346, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(276, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(67, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(349, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(67, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // DGCCodigo
            // 
            this.DGCCodigo.HeaderText = "Cod.";
            this.DGCCodigo.Name = "DGCCodigo";
            this.DGCCodigo.ReadOnly = true;
            // 
            // DGCCodigoPais
            // 
            this.DGCCodigoPais.DataPropertyName = "CodigoPais";
            this.DGCCodigoPais.HeaderText = "Column1";
            this.DGCCodigoPais.Name = "DGCCodigoPais";
            this.DGCCodigoPais.ReadOnly = true;
            this.DGCCodigoPais.Visible = false;
            // 
            // DGCCodigoDepartamento
            // 
            this.DGCCodigoDepartamento.DataPropertyName = "CodigoDepartamento";
            this.DGCCodigoDepartamento.HeaderText = "Column1";
            this.DGCCodigoDepartamento.Name = "DGCCodigoDepartamento";
            this.DGCCodigoDepartamento.ReadOnly = true;
            this.DGCCodigoDepartamento.Visible = false;
            // 
            // DGCCodigoProvincia
            // 
            this.DGCCodigoProvincia.DataPropertyName = "CodigoProvincia";
            this.DGCCodigoProvincia.HeaderText = "Column1";
            this.DGCCodigoProvincia.Name = "DGCCodigoProvincia";
            this.DGCCodigoProvincia.ReadOnly = true;
            this.DGCCodigoProvincia.Visible = false;
            // 
            // DGCCodigoLocalidad
            // 
            this.DGCCodigoLocalidad.DataPropertyName = "CodigoLocalidad";
            this.DGCCodigoLocalidad.HeaderText = "Column1";
            this.DGCCodigoLocalidad.Name = "DGCCodigoLocalidad";
            this.DGCCodigoLocalidad.ReadOnly = true;
            this.DGCCodigoLocalidad.Visible = false;
            // 
            // DGCNombreRegion
            // 
            this.DGCNombreRegion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombreRegion.DataPropertyName = "NombreRegion";
            this.DGCNombreRegion.HeaderText = "Nombre";
            this.DGCNombreRegion.Name = "DGCNombreRegion";
            this.DGCNombreRegion.ReadOnly = true;
            // 
            // FGeograficoBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(419, 184);
            this.Controls.Add(this.dtGVRegiones);
            this.Controls.Add(this.bdNavRegiones);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FGeograficoBusqueda";
            this.Text = "Busqueda de Regiones";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdNavRegiones)).EndInit();
            this.bdNavRegiones.ResumeLayout(false);
            this.bdNavRegiones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceRegiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVRegiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bdSourceRegiones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.BindingNavigator bdNavRegiones;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTextoBusqueda;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dtGVRegiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoProvincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoLocalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreRegion;
    }
}