namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FAñadirCategoria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAñadirCategoria));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtCodigoCategoria = new System.Windows.Forms.TextBox();
            this.TxtNombreCategoria = new System.Windows.Forms.TextBox();
            this.TxtAporteUsuario = new System.Windows.Forms.TextBox();
            this.TxtSubvencionInstitucional = new System.Windows.Forms.TextBox();
            this.TxtPuntajeMaximo = new System.Windows.Forms.TextBox();
            this.TxtPuntajeMinimo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVListadoCategorias = new System.Windows.Forms.DataGridView();
            this.DGCCodigoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCAporteUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCSubvencionInstitucional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPuntajeMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPuntajeMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdSourceCategorias = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCerrarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.btnGuardarCategoria = new System.Windows.Forms.Button();
            this.btnEditarCategoria = new System.Windows.Forms.Button();
            this.btnAñadirCategoria = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceCategorias)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(66, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Categoria :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(62, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Categoria :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(60, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Aporte Usuario (%) :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(14, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Subvención Institucional (%) :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(72, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Puntaje Máximo :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(73, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Puntaje Mínimo :";
            // 
            // TxtCodigoCategoria
            // 
            this.TxtCodigoCategoria.Location = new System.Drawing.Point(166, 26);
            this.TxtCodigoCategoria.Name = "TxtCodigoCategoria";
            this.TxtCodigoCategoria.ReadOnly = true;
            this.TxtCodigoCategoria.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigoCategoria.TabIndex = 6;
            // 
            // TxtNombreCategoria
            // 
            this.TxtNombreCategoria.Location = new System.Drawing.Point(166, 58);
            this.TxtNombreCategoria.Name = "TxtNombreCategoria";
            this.TxtNombreCategoria.Size = new System.Drawing.Size(100, 20);
            this.TxtNombreCategoria.TabIndex = 7;
            // 
            // TxtAporteUsuario
            // 
            this.TxtAporteUsuario.Location = new System.Drawing.Point(166, 90);
            this.TxtAporteUsuario.Name = "TxtAporteUsuario";
            this.TxtAporteUsuario.Size = new System.Drawing.Size(100, 20);
            this.TxtAporteUsuario.TabIndex = 8;
            // 
            // TxtSubvencionInstitucional
            // 
            this.TxtSubvencionInstitucional.Location = new System.Drawing.Point(166, 122);
            this.TxtSubvencionInstitucional.Name = "TxtSubvencionInstitucional";
            this.TxtSubvencionInstitucional.Size = new System.Drawing.Size(100, 20);
            this.TxtSubvencionInstitucional.TabIndex = 9;
            // 
            // TxtPuntajeMaximo
            // 
            this.TxtPuntajeMaximo.Location = new System.Drawing.Point(166, 154);
            this.TxtPuntajeMaximo.Name = "TxtPuntajeMaximo";
            this.TxtPuntajeMaximo.Size = new System.Drawing.Size(63, 20);
            this.TxtPuntajeMaximo.TabIndex = 10;
            // 
            // TxtPuntajeMinimo
            // 
            this.TxtPuntajeMinimo.Location = new System.Drawing.Point(166, 186);
            this.TxtPuntajeMinimo.Name = "TxtPuntajeMinimo";
            this.TxtPuntajeMinimo.Size = new System.Drawing.Size(63, 20);
            this.TxtPuntajeMinimo.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtPuntajeMaximo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtPuntajeMinimo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtSubvencionInstitucional);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtAporteUsuario);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtNombreCategoria);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtCodigoCategoria);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 228);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Introducción de Datos :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVListadoCategorias);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(283, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 228);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Categorias :";
            // 
            // dtGVListadoCategorias
            // 
            this.dtGVListadoCategorias.AllowUserToAddRows = false;
            this.dtGVListadoCategorias.AllowUserToResizeRows = false;
            this.dtGVListadoCategorias.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListadoCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListadoCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListadoCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoCategoria,
            this.DGCNombreCategoria,
            this.DGCAporteUsuario,
            this.DGCSubvencionInstitucional,
            this.DGCPuntajeMinimo,
            this.DGCPuntajeMaximo});
            this.dtGVListadoCategorias.DataSource = this.bdSourceCategorias;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGVListadoCategorias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVListadoCategorias.Location = new System.Drawing.Point(6, 16);
            this.dtGVListadoCategorias.Name = "dtGVListadoCategorias";
            this.dtGVListadoCategorias.ReadOnly = true;
            this.dtGVListadoCategorias.RowHeadersVisible = false;
            this.dtGVListadoCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListadoCategorias.Size = new System.Drawing.Size(604, 204);
            this.dtGVListadoCategorias.TabIndex = 0;
            // 
            // DGCCodigoCategoria
            // 
            this.DGCCodigoCategoria.DataPropertyName = "CodigoCategoria";
            this.DGCCodigoCategoria.HeaderText = "Código";
            this.DGCCodigoCategoria.Name = "DGCCodigoCategoria";
            this.DGCCodigoCategoria.ReadOnly = true;
            // 
            // DGCNombreCategoria
            // 
            this.DGCNombreCategoria.DataPropertyName = "NombreCategoria";
            this.DGCNombreCategoria.HeaderText = "Categoría";
            this.DGCNombreCategoria.Name = "DGCNombreCategoria";
            this.DGCNombreCategoria.ReadOnly = true;
            // 
            // DGCAporteUsuario
            // 
            this.DGCAporteUsuario.DataPropertyName = "AporteUsuario";
            this.DGCAporteUsuario.HeaderText = "Aporte";
            this.DGCAporteUsuario.Name = "DGCAporteUsuario";
            this.DGCAporteUsuario.ReadOnly = true;
            // 
            // DGCSubvencionInstitucional
            // 
            this.DGCSubvencionInstitucional.DataPropertyName = "SubvencionInstitucional";
            this.DGCSubvencionInstitucional.HeaderText = "Subvención Institucional";
            this.DGCSubvencionInstitucional.Name = "DGCSubvencionInstitucional";
            this.DGCSubvencionInstitucional.ReadOnly = true;
            // 
            // DGCPuntajeMinimo
            // 
            this.DGCPuntajeMinimo.DataPropertyName = "PuntajeMinimo";
            this.DGCPuntajeMinimo.HeaderText = "Puntaje Mínimo";
            this.DGCPuntajeMinimo.Name = "DGCPuntajeMinimo";
            this.DGCPuntajeMinimo.ReadOnly = true;
            // 
            // DGCPuntajeMaximo
            // 
            this.DGCPuntajeMaximo.DataPropertyName = "PuntajeMaximo";
            this.DGCPuntajeMaximo.HeaderText = "Puntaje Máximo";
            this.DGCPuntajeMaximo.Name = "DGCPuntajeMaximo";
            this.DGCPuntajeMaximo.ReadOnly = true;
            // 
            // bdSourceCategorias
            // 
            this.bdSourceCategorias.CurrentChanged += new System.EventHandler(this.bdSourceCategorias_CurrentChanged);
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnCerrarCategoria);
            this.pnlBotones.Controls.Add(this.btnEliminarCategoria);
            this.pnlBotones.Controls.Add(this.btnGuardarCategoria);
            this.pnlBotones.Controls.Add(this.btnEditarCategoria);
            this.pnlBotones.Controls.Add(this.btnAñadirCategoria);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 228);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(899, 42);
            this.pnlBotones.TabIndex = 15;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 5;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(252, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 31);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Copia de Save file.png");
            this.imageList1.Images.SetKeyName(1, "edit_add.png");
            this.imageList1.Images.SetKeyName(2, "Erase.png");
            this.imageList1.Images.SetKeyName(3, "exit.png");
            this.imageList1.Images.SetKeyName(4, "wi0062-48.gif");
            this.imageList1.Images.SetKeyName(5, "Undo.png");
            // 
            // btnCerrarCategoria
            // 
            this.btnCerrarCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarCategoria.ImageIndex = 3;
            this.btnCerrarCategoria.ImageList = this.imageList1;
            this.btnCerrarCategoria.Location = new System.Drawing.Point(816, 5);
            this.btnCerrarCategoria.Name = "btnCerrarCategoria";
            this.btnCerrarCategoria.Size = new System.Drawing.Size(74, 31);
            this.btnCerrarCategoria.TabIndex = 24;
            this.btnCerrarCategoria.Text = "&Cerrar";
            this.btnCerrarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarCategoria.UseVisualStyleBackColor = true;
            this.btnCerrarCategoria.Click += new System.EventHandler(this.btnCerrarAñadirActividad_Click);
            // 
            // btnEliminarCategoria
            // 
            this.btnEliminarCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarCategoria.ImageIndex = 2;
            this.btnEliminarCategoria.ImageList = this.imageList1;
            this.btnEliminarCategoria.Location = new System.Drawing.Point(332, 5);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(74, 31);
            this.btnEliminarCategoria.TabIndex = 23;
            this.btnEliminarCategoria.Text = "&Eliminar";
            this.btnEliminarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardarCategoria
            // 
            this.btnGuardarCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCategoria.ImageIndex = 0;
            this.btnGuardarCategoria.ImageList = this.imageList1;
            this.btnGuardarCategoria.Location = new System.Drawing.Point(92, 5);
            this.btnGuardarCategoria.Name = "btnGuardarCategoria";
            this.btnGuardarCategoria.Size = new System.Drawing.Size(74, 31);
            this.btnGuardarCategoria.TabIndex = 22;
            this.btnGuardarCategoria.Text = "&Guardar";
            this.btnGuardarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarCategoria.UseVisualStyleBackColor = true;
            this.btnGuardarCategoria.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnEditarCategoria
            // 
            this.btnEditarCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarCategoria.ImageIndex = 4;
            this.btnEditarCategoria.ImageList = this.imageList1;
            this.btnEditarCategoria.Location = new System.Drawing.Point(172, 5);
            this.btnEditarCategoria.Name = "btnEditarCategoria";
            this.btnEditarCategoria.Size = new System.Drawing.Size(74, 31);
            this.btnEditarCategoria.TabIndex = 21;
            this.btnEditarCategoria.Text = "&Editar";
            this.btnEditarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarCategoria.UseVisualStyleBackColor = true;
            this.btnEditarCategoria.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAñadirCategoria
            // 
            this.btnAñadirCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirCategoria.ImageIndex = 1;
            this.btnAñadirCategoria.ImageList = this.imageList1;
            this.btnAñadirCategoria.Location = new System.Drawing.Point(12, 5);
            this.btnAñadirCategoria.Name = "btnAñadirCategoria";
            this.btnAñadirCategoria.Size = new System.Drawing.Size(74, 31);
            this.btnAñadirCategoria.TabIndex = 20;
            this.btnAñadirCategoria.Text = "&Añadir";
            this.btnAñadirCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirCategoria.UseVisualStyleBackColor = true;
            this.btnAñadirCategoria.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // FAñadirCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(899, 270);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlBotones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAñadirCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AÑADIR CATEGORÍAS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListadoCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceCategorias)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtCodigoCategoria;
        private System.Windows.Forms.TextBox TxtNombreCategoria;
        private System.Windows.Forms.TextBox TxtAporteUsuario;
        private System.Windows.Forms.TextBox TxtSubvencionInstitucional;
        private System.Windows.Forms.TextBox TxtPuntajeMaximo;
        private System.Windows.Forms.TextBox TxtPuntajeMinimo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.DataGridView dtGVListadoCategorias;
        private System.Windows.Forms.Button btnCerrarCategoria;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.Button btnGuardarCategoria;
        private System.Windows.Forms.Button btnEditarCategoria;
        private System.Windows.Forms.Button btnAñadirCategoria;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource bdSourceCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCAporteUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCSubvencionInstitucional;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPuntajeMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPuntajeMaximo;
    }
}