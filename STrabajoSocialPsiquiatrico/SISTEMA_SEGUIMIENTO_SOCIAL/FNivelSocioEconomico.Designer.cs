namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FNivelSocioEconomico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FNivelSocioEconomico));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtNombreApellidoPaciente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGVPreguntas = new System.Windows.Forms.DataGridView();
            this.DGCCodigoPreguntaValoracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombrePreguntaValoracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtGVRespuestas = new System.Windows.Forms.DataGridView();
            this.DGCSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCCodigoRespuestaValoracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreRespuestaValoracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPuntaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dtGVRespuestasSeleccionadas = new System.Windows.Forms.DataGridView();
            this.DGCCodigoRespuestaValoracion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCCodigoPreguntaValoracion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombrePreguntaValoracion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreRespuestaValoracion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCPuntajeActual2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtPuntajeTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtCategoria = new System.Windows.Forms.TextBox();
            this.TxtRangoPuntaje = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.bdSourceRespuestas = new System.Windows.Forms.BindingSource(this.components);
            this.bdSourcePreguntas = new System.Windows.Forms.BindingSource(this.components);
            this.btnGuardarNivelSocioeconomico = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPreguntas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVRespuestas)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVRespuestasSeleccionadas)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceRespuestas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtNombreApellidoPaciente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TxtNombreApellidoPaciente
            // 
            this.TxtNombreApellidoPaciente.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxtNombreApellidoPaciente.Location = new System.Drawing.Point(112, 13);
            this.TxtNombreApellidoPaciente.Name = "TxtNombreApellidoPaciente";
            this.TxtNombreApellidoPaciente.Size = new System.Drawing.Size(577, 20);
            this.TxtNombreApellidoPaciente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(51, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paciente :";
            // 
            // dtGVPreguntas
            // 
            this.dtGVPreguntas.AllowUserToAddRows = false;
            this.dtGVPreguntas.AllowUserToDeleteRows = false;
            this.dtGVPreguntas.AllowUserToResizeRows = false;
            this.dtGVPreguntas.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVPreguntas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVPreguntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoPreguntaValoracion,
            this.DGCNombrePreguntaValoracion});
            this.dtGVPreguntas.DataSource = this.bdSourcePreguntas;
            this.dtGVPreguntas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVPreguntas.Location = new System.Drawing.Point(5, 18);
            this.dtGVPreguntas.MultiSelect = false;
            this.dtGVPreguntas.Name = "dtGVPreguntas";
            this.dtGVPreguntas.ReadOnly = true;
            this.dtGVPreguntas.RowHeadersVisible = false;
            this.dtGVPreguntas.RowTemplate.Height = 24;
            this.dtGVPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVPreguntas.Size = new System.Drawing.Size(251, 300);
            this.dtGVPreguntas.TabIndex = 0;
            // 
            // DGCCodigoPreguntaValoracion
            // 
            this.DGCCodigoPreguntaValoracion.DataPropertyName = "CodigoPreguntaValoracion";
            this.DGCCodigoPreguntaValoracion.HeaderText = "Nº";
            this.DGCCodigoPreguntaValoracion.Name = "DGCCodigoPreguntaValoracion";
            this.DGCCodigoPreguntaValoracion.ReadOnly = true;
            this.DGCCodigoPreguntaValoracion.Width = 35;
            // 
            // DGCNombrePreguntaValoracion
            // 
            this.DGCNombrePreguntaValoracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombrePreguntaValoracion.DataPropertyName = "NombrePreguntaValoracion";
            this.DGCNombrePreguntaValoracion.HeaderText = "Pregunta";
            this.DGCNombrePreguntaValoracion.Name = "DGCNombrePreguntaValoracion";
            this.DGCNombrePreguntaValoracion.ReadOnly = true;
            // 
            // dtGVRespuestas
            // 
            this.dtGVRespuestas.AllowUserToAddRows = false;
            this.dtGVRespuestas.AllowUserToDeleteRows = false;
            this.dtGVRespuestas.AllowUserToResizeRows = false;
            this.dtGVRespuestas.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVRespuestas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVRespuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVRespuestas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCSeleccionar,
            this.DGCCodigoRespuestaValoracion,
            this.DGCNombreRespuestaValoracion,
            this.DGCPuntaje,
            this.DGCDescripcion});
            this.dtGVRespuestas.DataSource = this.bdSourceRespuestas;
            this.dtGVRespuestas.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtGVRespuestas.Location = new System.Drawing.Point(7, 20);
            this.dtGVRespuestas.MultiSelect = false;
            this.dtGVRespuestas.Name = "dtGVRespuestas";
            this.dtGVRespuestas.RowHeadersVisible = false;
            this.dtGVRespuestas.RowTemplate.Height = 24;
            this.dtGVRespuestas.Size = new System.Drawing.Size(468, 194);
            this.dtGVRespuestas.TabIndex = 0;
            // 
            // DGCSeleccionar
            // 
            this.DGCSeleccionar.DataPropertyName = "Seleccionar";
            this.DGCSeleccionar.HeaderText = "Seleccionar";
            this.DGCSeleccionar.Name = "DGCSeleccionar";
            this.DGCSeleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGCSeleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGCSeleccionar.ToolTipText = "Seleccione esta respuesta para la pregunta actual";
            this.DGCSeleccionar.Width = 70;
            // 
            // DGCCodigoRespuestaValoracion
            // 
            this.DGCCodigoRespuestaValoracion.DataPropertyName = "CodigoRespuestaValoracion";
            this.DGCCodigoRespuestaValoracion.HeaderText = "Nº";
            this.DGCCodigoRespuestaValoracion.Name = "DGCCodigoRespuestaValoracion";
            this.DGCCodigoRespuestaValoracion.ReadOnly = true;
            this.DGCCodigoRespuestaValoracion.Visible = false;
            this.DGCCodigoRespuestaValoracion.Width = 30;
            // 
            // DGCNombreRespuestaValoracion
            // 
            this.DGCNombreRespuestaValoracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombreRespuestaValoracion.DataPropertyName = "NombreRespuestaValoracion";
            this.DGCNombreRespuestaValoracion.HeaderText = "Respuesta";
            this.DGCNombreRespuestaValoracion.Name = "DGCNombreRespuestaValoracion";
            this.DGCNombreRespuestaValoracion.ReadOnly = true;
            // 
            // DGCPuntaje
            // 
            this.DGCPuntaje.DataPropertyName = "Puntaje";
            this.DGCPuntaje.HeaderText = "Puntaje";
            this.DGCPuntaje.Name = "DGCPuntaje";
            this.DGCPuntaje.ReadOnly = true;
            this.DGCPuntaje.Width = 65;
            // 
            // DGCDescripcion
            // 
            this.DGCDescripcion.DataPropertyName = "Descripcion";
            this.DGCDescripcion.HeaderText = "Descripcion";
            this.DGCDescripcion.Name = "DGCDescripcion";
            this.DGCDescripcion.ReadOnly = true;
            this.DGCDescripcion.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "filesave.png");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.splitter1);
            this.groupBox4.Controls.Add(this.dtGVRespuestasSeleccionadas);
            this.groupBox4.Controls.Add(this.dtGVRespuestas);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox4.Location = new System.Drawing.Point(261, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox4.Size = new System.Drawing.Size(482, 417);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Detalle de Respuestas";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(7, 214);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(468, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // dtGVRespuestasSeleccionadas
            // 
            this.dtGVRespuestasSeleccionadas.AllowUserToAddRows = false;
            this.dtGVRespuestasSeleccionadas.AllowUserToDeleteRows = false;
            this.dtGVRespuestasSeleccionadas.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVRespuestasSeleccionadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtGVRespuestasSeleccionadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVRespuestasSeleccionadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoRespuestaValoracion2,
            this.DGCCodigoPreguntaValoracion2,
            this.DGCNombrePreguntaValoracion2,
            this.DGCNombreRespuestaValoracion2,
            this.DGCPuntajeActual2});
            this.dtGVRespuestasSeleccionadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVRespuestasSeleccionadas.Location = new System.Drawing.Point(7, 214);
            this.dtGVRespuestasSeleccionadas.Margin = new System.Windows.Forms.Padding(2);
            this.dtGVRespuestasSeleccionadas.Name = "dtGVRespuestasSeleccionadas";
            this.dtGVRespuestasSeleccionadas.ReadOnly = true;
            this.dtGVRespuestasSeleccionadas.RowHeadersVisible = false;
            this.dtGVRespuestasSeleccionadas.RowTemplate.Height = 24;
            this.dtGVRespuestasSeleccionadas.Size = new System.Drawing.Size(468, 196);
            this.dtGVRespuestasSeleccionadas.TabIndex = 2;
            // 
            // DGCCodigoRespuestaValoracion2
            // 
            this.DGCCodigoRespuestaValoracion2.DataPropertyName = "CodigoRespuestaValoracion";
            this.DGCCodigoRespuestaValoracion2.HeaderText = "CodRespuesta";
            this.DGCCodigoRespuestaValoracion2.Name = "DGCCodigoRespuestaValoracion2";
            this.DGCCodigoRespuestaValoracion2.ReadOnly = true;
            this.DGCCodigoRespuestaValoracion2.Visible = false;
            // 
            // DGCCodigoPreguntaValoracion2
            // 
            this.DGCCodigoPreguntaValoracion2.DataPropertyName = "CodigoPreguntaValoracion";
            this.DGCCodigoPreguntaValoracion2.HeaderText = "CodPregunta";
            this.DGCCodigoPreguntaValoracion2.Name = "DGCCodigoPreguntaValoracion2";
            this.DGCCodigoPreguntaValoracion2.ReadOnly = true;
            this.DGCCodigoPreguntaValoracion2.Visible = false;
            // 
            // DGCNombrePreguntaValoracion2
            // 
            this.DGCNombrePreguntaValoracion2.DataPropertyName = "NombrePreguntaValoracion";
            this.DGCNombrePreguntaValoracion2.HeaderText = "Pregunta";
            this.DGCNombrePreguntaValoracion2.Name = "DGCNombrePreguntaValoracion2";
            this.DGCNombrePreguntaValoracion2.ReadOnly = true;
            this.DGCNombrePreguntaValoracion2.Width = 150;
            // 
            // DGCNombreRespuestaValoracion2
            // 
            this.DGCNombreRespuestaValoracion2.DataPropertyName = "NombreRespuestaValoracion";
            this.DGCNombreRespuestaValoracion2.FillWeight = 150F;
            this.DGCNombreRespuestaValoracion2.HeaderText = "Respuesta Seleccionada";
            this.DGCNombreRespuestaValoracion2.Name = "DGCNombreRespuestaValoracion2";
            this.DGCNombreRespuestaValoracion2.ReadOnly = true;
            this.DGCNombreRespuestaValoracion2.Width = 230;
            // 
            // DGCPuntajeActual2
            // 
            this.DGCPuntajeActual2.DataPropertyName = "PuntajeActual";
            this.DGCPuntajeActual2.HeaderText = "Puntaje";
            this.DGCPuntajeActual2.Name = "DGCPuntajeActual2";
            this.DGCPuntajeActual2.ReadOnly = true;
            this.DGCPuntajeActual2.Width = 70;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtGVPreguntas);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox5.Location = new System.Drawing.Point(0, 42);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(261, 417);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalle de Preguntas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtPuntajeTotal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(5, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 47);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Suma de Puntaje";
            // 
            // TxtPuntajeTotal
            // 
            this.TxtPuntajeTotal.Location = new System.Drawing.Point(145, 19);
            this.TxtPuntajeTotal.Name = "TxtPuntajeTotal";
            this.TxtPuntajeTotal.ReadOnly = true;
            this.TxtPuntajeTotal.Size = new System.Drawing.Size(59, 20);
            this.TxtPuntajeTotal.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(60, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Puntaje Total :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtCategoria);
            this.groupBox3.Controls.Add(this.TxtRangoPuntaje);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox3.Location = new System.Drawing.Point(5, 365);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 47);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Escala de Puntaje";
            // 
            // TxtCategoria
            // 
            this.TxtCategoria.Location = new System.Drawing.Point(139, 18);
            this.TxtCategoria.Name = "TxtCategoria";
            this.TxtCategoria.ReadOnly = true;
            this.TxtCategoria.Size = new System.Drawing.Size(75, 20);
            this.TxtCategoria.TabIndex = 1;
            // 
            // TxtRangoPuntaje
            // 
            this.TxtRangoPuntaje.Location = new System.Drawing.Point(23, 18);
            this.TxtRangoPuntaje.Name = "TxtRangoPuntaje";
            this.TxtRangoPuntaje.ReadOnly = true;
            this.TxtRangoPuntaje.Size = new System.Drawing.Size(75, 20);
            this.TxtRangoPuntaje.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGuardarNivelSocioeconomico);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 459);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 40);
            this.panel1.TabIndex = 7;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(261, 42);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 417);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // btnGuardarNivelSocioeconomico
            // 
            this.btnGuardarNivelSocioeconomico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarNivelSocioeconomico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarNivelSocioeconomico.ImageIndex = 0;
            this.btnGuardarNivelSocioeconomico.ImageList = this.imageList1;
            this.btnGuardarNivelSocioeconomico.Location = new System.Drawing.Point(661, 6);
            this.btnGuardarNivelSocioeconomico.Name = "btnGuardarNivelSocioeconomico";
            this.btnGuardarNivelSocioeconomico.Size = new System.Drawing.Size(76, 30);
            this.btnGuardarNivelSocioeconomico.TabIndex = 5;
            this.btnGuardarNivelSocioeconomico.Text = "      &Guardar";
            this.btnGuardarNivelSocioeconomico.UseVisualStyleBackColor = true;
            this.btnGuardarNivelSocioeconomico.Click += new System.EventHandler(this.btnGuardarNivelSocioeconomico_Click);
            // 
            // FNivelSocioEconomico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(743, 499);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FNivelSocioEconomico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DETERMINAR EL NIVEL SOCIO - ECONÓMICO";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVPreguntas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVRespuestas)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVRespuestasSeleccionadas)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdSourceRespuestas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSourcePreguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtNombreApellidoPaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarNivelSocioeconomico;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dtGVPreguntas;
        private System.Windows.Forms.DataGridView dtGVRespuestas;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoPreguntaValoracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombrePreguntaValoracion;
        private System.Windows.Forms.BindingSource bdSourcePreguntas;
        private System.Windows.Forms.BindingSource bdSourceRespuestas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoRespuestaValoracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreRespuestaValoracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPuntaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDescripcion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtPuntajeTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtCategoria;
        private System.Windows.Forms.TextBox TxtRangoPuntaje;
        private System.Windows.Forms.DataGridView dtGVRespuestasSeleccionadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoRespuestaValoracion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCCodigoPreguntaValoracion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombrePreguntaValoracion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreRespuestaValoracion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCPuntajeActual2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter2;
    }
}