﻿namespace SISTEMA_SEGUIMIENTO_SOCIAL
{
    partial class FCambiarContraseña
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
            this.tBContrasenaActual = new System.Windows.Forms.TextBox();
            this.tBContrasenaNueva = new System.Windows.Forms.TextBox();
            this.tBContrasenaNuevaRepetida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tBContrasenaActual
            // 
            this.tBContrasenaActual.Location = new System.Drawing.Point(168, 66);
            this.tBContrasenaActual.Name = "tBContrasenaActual";
            this.tBContrasenaActual.PasswordChar = '*';
            this.tBContrasenaActual.Size = new System.Drawing.Size(150, 20);
            this.tBContrasenaActual.TabIndex = 0;
            // 
            // tBContrasenaNueva
            // 
            this.tBContrasenaNueva.BackColor = System.Drawing.SystemColors.Info;
            this.tBContrasenaNueva.Location = new System.Drawing.Point(168, 94);
            this.tBContrasenaNueva.Name = "tBContrasenaNueva";
            this.tBContrasenaNueva.PasswordChar = '*';
            this.tBContrasenaNueva.Size = new System.Drawing.Size(150, 20);
            this.tBContrasenaNueva.TabIndex = 1;
            // 
            // tBContrasenaNuevaRepetida
            // 
            this.tBContrasenaNuevaRepetida.BackColor = System.Drawing.Color.Khaki;
            this.tBContrasenaNuevaRepetida.Location = new System.Drawing.Point(168, 122);
            this.tBContrasenaNuevaRepetida.Name = "tBContrasenaNuevaRepetida";
            this.tBContrasenaNuevaRepetida.PasswordChar = '*';
            this.tBContrasenaNuevaRepetida.Size = new System.Drawing.Size(150, 20);
            this.tBContrasenaNuevaRepetida.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contraseña Anterior :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nueva Contraseña :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Repetir Nueva Contraseña :";
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(163, 168);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 3;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.Location = new System.Drawing.Point(244, 168);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 4;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(339, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ingrese en la Primera Caja de Texto la Contaseña Actual, luego Escriba en las otr" +
                "as dos Casillas la Nueva Contaseña.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FCambiarContraseña
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(364, 208);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBContrasenaNuevaRepetida);
            this.Controls.Add(this.tBContrasenaNueva);
            this.Controls.Add(this.tBContrasenaActual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCambiarContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAMBIAR CONTRASEÑA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBContrasenaActual;
        private System.Windows.Forms.TextBox tBContrasenaNueva;
        private System.Windows.Forms.TextBox tBContrasenaNuevaRepetida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Label label4;
    }
}