namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FAñadirOcupaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAñadirOcupaciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.dtGVConceptos = new System.Windows.Forms.DataGridView();
            this.bdSourceOcupaciones = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.gBoxGrilla = new System.Windows.Forms.GroupBox();
            this.bdNavigatorOcupaciones = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gBoxDatos = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.DGCCodigoMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVConceptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceOcupaciones)).BeginInit();
            this.gBoxGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavigatorOcupaciones)).BeginInit();
            this.bdNavigatorOcupaciones.SuspendLayout();
            this.gBoxDatos.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
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
            // dtGVConceptos
            // 
            this.dtGVConceptos.AllowUserToAddRows = false;
            this.dtGVConceptos.AllowUserToDeleteRows = false;
            this.dtGVConceptos.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVConceptos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoMarca,
            this.DGCNombreMarca});
            this.dtGVConceptos.DataSource = this.bdSourceOcupaciones;
            this.dtGVConceptos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVConceptos.Location = new System.Drawing.Point(3, 41);
            this.dtGVConceptos.MultiSelect = false;
            this.dtGVConceptos.Name = "dtGVConceptos";
            this.dtGVConceptos.ReadOnly = true;
            this.dtGVConceptos.RowHeadersVisible = false;
            this.dtGVConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVConceptos.Size = new System.Drawing.Size(369, 57);
            this.dtGVConceptos.TabIndex = 0;
            // 
            // bdSourceOcupaciones
            // 
            this.bdSourceOcupaciones.CurrentChanged += new System.EventHandler(this.bdSourceOcupaciones_CurrentChanged);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // gBoxGrilla
            // 
            this.gBoxGrilla.Controls.Add(this.dtGVConceptos);
            this.gBoxGrilla.Controls.Add(this.bdNavigatorOcupaciones);
            this.gBoxGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxGrilla.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxGrilla.Location = new System.Drawing.Point(299, 0);
            this.gBoxGrilla.Name = "gBoxGrilla";
            this.gBoxGrilla.Size = new System.Drawing.Size(375, 101);
            this.gBoxGrilla.TabIndex = 2;
            this.gBoxGrilla.TabStop = false;
            this.gBoxGrilla.Text = "Listado de Ocupaciones";
            // 
            // bdNavigatorOcupaciones
            // 
            this.bdNavigatorOcupaciones.AddNewItem = null;
            this.bdNavigatorOcupaciones.BindingSource = this.bdSourceOcupaciones;
            this.bdNavigatorOcupaciones.CountItem = this.bindingNavigatorCountItem;
            this.bdNavigatorOcupaciones.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bdNavigatorOcupaciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem});
            this.bdNavigatorOcupaciones.Location = new System.Drawing.Point(3, 16);
            this.bdNavigatorOcupaciones.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdNavigatorOcupaciones.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdNavigatorOcupaciones.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdNavigatorOcupaciones.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdNavigatorOcupaciones.Name = "bdNavigatorOcupaciones";
            this.bdNavigatorOcupaciones.PositionItem = this.bindingNavigatorPositionItem;
            this.bdNavigatorOcupaciones.Size = new System.Drawing.Size(369, 25);
            this.bdNavigatorOcupaciones.TabIndex = 1;
            this.bdNavigatorOcupaciones.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
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
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // gBoxDatos
            // 
            this.gBoxDatos.Controls.Add(this.txtNombre);
            this.gBoxDatos.Controls.Add(this.txtCodigo);
            this.gBoxDatos.Controls.Add(this.label2);
            this.gBoxDatos.Controls.Add(this.label1);
            this.gBoxDatos.Dock = System.Windows.Forms.DockStyle.Left;
            this.gBoxDatos.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxDatos.Location = new System.Drawing.Point(3, 0);
            this.gBoxDatos.Name = "gBoxDatos";
            this.gBoxDatos.Size = new System.Drawing.Size(296, 101);
            this.gBoxDatos.TabIndex = 0;
            this.gBoxDatos.TabStop = false;
            this.gBoxDatos.Text = "Introducir Ocupaciones :";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(66, 61);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(224, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(66, 28);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(120, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCerrar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnAceptar);
            this.pnlBotones.Controls.Add(this.btnEditar);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotones.Location = new System.Drawing.Point(3, 101);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(671, 48);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(598, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(70, 29);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(522, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(70, 29);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(446, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(70, 29);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(370, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(70, 29);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(294, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(70, 29);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(218, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(70, 29);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 149);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // DGCCodigoMarca
            // 
            this.DGCCodigoMarca.DataPropertyName = "CodigoOcupacion";
            this.DGCCodigoMarca.HeaderText = "Codigo";
            this.DGCCodigoMarca.Name = "DGCCodigoMarca";
            this.DGCCodigoMarca.ReadOnly = true;
            // 
            // DGCNombreMarca
            // 
            this.DGCNombreMarca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombreMarca.DataPropertyName = "NombreOcupacion";
            this.DGCNombreMarca.HeaderText = "Nombre";
            this.DGCNombreMarca.Name = "DGCNombreMarca";
            this.DGCNombreMarca.ReadOnly = true;
            // 
            // FAñadirOcupaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 149);
            this.Controls.Add(this.gBoxGrilla);
            this.Controls.Add(this.gBoxDatos);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.splitter1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAñadirOcupaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AÑADIR OCUPACIONES";
            this.Shown += new System.EventHandler(this.FOcupaciones_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVConceptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceOcupaciones)).EndInit();
            this.gBoxGrilla.ResumeLayout(false);
            this.gBoxGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNavigatorOcupaciones)).EndInit();
            this.bdNavigatorOcupaciones.ResumeLayout(false);
            this.bdNavigatorOcupaciones.PerformLayout();
            this.gBoxDatos.ResumeLayout(false);
            this.gBoxDatos.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.DataGridView dtGVConceptos;
        private System.Windows.Forms.BindingSource bdSourceOcupaciones;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.GroupBox gBoxGrilla;
        private System.Windows.Forms.BindingNavigator bdNavigatorOcupaciones;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.GroupBox gBoxDatos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel pnlBotones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreMarca;
    }
}