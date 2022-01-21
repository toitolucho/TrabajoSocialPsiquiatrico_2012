namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FAñadirParentesco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAñadirParentesco));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gBoxDatos = new System.Windows.Forms.GroupBox();
            this.rtextBoxDescripcionParentesco = new System.Windows.Forms.RichTextBox();
            this.TxtNombreParentesco = new System.Windows.Forms.TextBox();
            this.TxtCodigoParentesco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gBoxGrilla = new System.Windows.Forms.GroupBox();
            this.dtGVListadoParentesco = new System.Windows.Forms.DataGridView();
            this.DGCCodigoParentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreParentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdSourceParentescos = new System.Windows.Forms.BindingSource(this.components);
            this.gBoxDatos.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.gBoxGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoParentesco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceParentescos)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxDatos
            // 
            this.gBoxDatos.Controls.Add(this.rtextBoxDescripcionParentesco);
            this.gBoxDatos.Controls.Add(this.TxtNombreParentesco);
            this.gBoxDatos.Controls.Add(this.TxtCodigoParentesco);
            this.gBoxDatos.Controls.Add(this.label3);
            this.gBoxDatos.Controls.Add(this.label2);
            this.gBoxDatos.Controls.Add(this.label1);
            this.gBoxDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBoxDatos.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxDatos.Location = new System.Drawing.Point(0, 0);
            this.gBoxDatos.Name = "gBoxDatos";
            this.gBoxDatos.Size = new System.Drawing.Size(516, 143);
            this.gBoxDatos.TabIndex = 0;
            this.gBoxDatos.TabStop = false;
            this.gBoxDatos.Text = "Introducción de Datos :";
            // 
            // rtextBoxDescripcionParentesco
            // 
            this.rtextBoxDescripcionParentesco.Location = new System.Drawing.Point(172, 80);
            this.rtextBoxDescripcionParentesco.Name = "rtextBoxDescripcionParentesco";
            this.rtextBoxDescripcionParentesco.Size = new System.Drawing.Size(259, 46);
            this.rtextBoxDescripcionParentesco.TabIndex = 2;
            this.rtextBoxDescripcionParentesco.Text = "";
            // 
            // TxtNombreParentesco
            // 
            this.TxtNombreParentesco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombreParentesco.Location = new System.Drawing.Point(172, 52);
            this.TxtNombreParentesco.Name = "TxtNombreParentesco";
            this.TxtNombreParentesco.Size = new System.Drawing.Size(259, 20);
            this.TxtNombreParentesco.TabIndex = 1;
            // 
            // TxtCodigoParentesco
            // 
            this.TxtCodigoParentesco.Location = new System.Drawing.Point(172, 24);
            this.TxtCodigoParentesco.Name = "TxtCodigoParentesco";
            this.TxtCodigoParentesco.ReadOnly = true;
            this.TxtCodigoParentesco.Size = new System.Drawing.Size(70, 20);
            this.TxtCodigoParentesco.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(97, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripcion :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(59, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Parentesco :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(63, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Parentesco :";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Erase.png");
            this.imageList1.Images.SetKeyName(1, "Yes v3.png");
            this.imageList1.Images.SetKeyName(2, "wi0062-48.gif");
            this.imageList1.Images.SetKeyName(3, "Copia de Save file.png");
            this.imageList1.Images.SetKeyName(4, "edit_add.png");
            this.imageList1.Images.SetKeyName(5, "exit.png");
            this.imageList1.Images.SetKeyName(6, "Undo.png");
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnCerrar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Controls.Add(this.btnEditar);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnAceptar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 445);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(516, 40);
            this.pnlBotones.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 6;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(252, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cance&lar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.ImageIndex = 5;
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(430, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 32);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.ImageIndex = 4;
            this.btnNuevo.ImageList = this.imageList1;
            this.btnNuevo.Location = new System.Drawing.Point(9, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 32);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "&Añadir";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.ImageIndex = 2;
            this.btnEditar.ImageList = this.imageList1;
            this.btnEditar.Location = new System.Drawing.Point(171, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 32);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.ImageIndex = 0;
            this.btnEliminar.ImageList = this.imageList1;
            this.btnEliminar.Location = new System.Drawing.Point(333, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 32);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageIndex = 3;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(90, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 32);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Guardar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gBoxGrilla
            // 
            this.gBoxGrilla.Controls.Add(this.dtGVListadoParentesco);
            this.gBoxGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxGrilla.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxGrilla.Location = new System.Drawing.Point(0, 143);
            this.gBoxGrilla.Name = "gBoxGrilla";
            this.gBoxGrilla.Size = new System.Drawing.Size(516, 302);
            this.gBoxGrilla.TabIndex = 1;
            this.gBoxGrilla.TabStop = false;
            this.gBoxGrilla.Text = "Listado de Parentescos :";
            // 
            // dtGVListadoParentesco
            // 
            this.dtGVListadoParentesco.AllowUserToAddRows = false;
            this.dtGVListadoParentesco.AllowUserToResizeRows = false;
            this.dtGVListadoParentesco.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoParentesco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoParentesco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoParentesco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoParentesco,
            this.DGCNombreParentesco,
            this.DGCDescripcion});
            this.dtGVListadoParentesco.DataSource = this.bdSourceParentescos;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVListadoParentesco.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVListadoParentesco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListadoParentesco.Location = new System.Drawing.Point(3, 16);
            this.dtGVListadoParentesco.Name = "dtGVListadoParentesco";
            this.dtGVListadoParentesco.ReadOnly = true;
            this.dtGVListadoParentesco.RowHeadersVisible = false;
            this.dtGVListadoParentesco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListadoParentesco.Size = new System.Drawing.Size(510, 283);
            this.dtGVListadoParentesco.TabIndex = 0;
            // 
            // DGCCodigoParentesco
            // 
            this.DGCCodigoParentesco.DataPropertyName = "CodigoParentesco";
            this.DGCCodigoParentesco.HeaderText = "Código";
            this.DGCCodigoParentesco.Name = "DGCCodigoParentesco";
            this.DGCCodigoParentesco.ReadOnly = true;
            this.DGCCodigoParentesco.Width = 50;
            // 
            // DGCNombreParentesco
            // 
            this.DGCNombreParentesco.DataPropertyName = "NombreParentesco";
            this.DGCNombreParentesco.HeaderText = "Parentesco";
            this.DGCNombreParentesco.Name = "DGCNombreParentesco";
            this.DGCNombreParentesco.ReadOnly = true;
            this.DGCNombreParentesco.Width = 250;
            // 
            // DGCDescripcion
            // 
            this.DGCDescripcion.DataPropertyName = "Descripcion";
            this.DGCDescripcion.HeaderText = "Descripción";
            this.DGCDescripcion.Name = "DGCDescripcion";
            this.DGCDescripcion.ReadOnly = true;
            this.DGCDescripcion.Width = 200;
            // 
            // bdSourceParentescos
            // 
            this.bdSourceParentescos.CurrentChanged += new System.EventHandler(this.bdSourceParentescos_CurrentChanged);
            // 
            // FAñadirParentesco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(516, 485);
            this.Controls.Add(this.gBoxGrilla);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.gBoxDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAñadirParentesco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AÑADIR PARENTESCOS";
            this.gBoxDatos.ResumeLayout(false);
            this.gBoxDatos.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.gBoxGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoParentesco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceParentescos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxDatos;
        private System.Windows.Forms.RichTextBox rtextBoxDescripcionParentesco;
        private System.Windows.Forms.TextBox TxtNombreParentesco;
        private System.Windows.Forms.TextBox TxtCodigoParentesco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gBoxGrilla;
        private System.Windows.Forms.DataGridView dtGVListadoParentesco;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource bdSourceParentescos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoParentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreParentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDescripcion;
    }
}