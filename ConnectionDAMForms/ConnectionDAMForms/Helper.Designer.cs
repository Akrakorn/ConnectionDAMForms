﻿namespace ConnectionDAMForms
{
    partial class Helper
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
            this.btConectar = new System.Windows.Forms.Button();
            this.tbDerecha = new System.Windows.Forms.TextBox();
            this.tbIzquierda = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btEscuchar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbEnviar = new System.Windows.Forms.TextBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.cbIPLocal = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btConectar
            // 
            this.btConectar.Location = new System.Drawing.Point(123, 105);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(75, 23);
            this.btConectar.TabIndex = 5;
            this.btConectar.Text = "Conectar";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // tbDerecha
            // 
            this.tbDerecha.Location = new System.Drawing.Point(98, 79);
            this.tbDerecha.Name = "tbDerecha";
            this.tbDerecha.Size = new System.Drawing.Size(100, 20);
            this.tbDerecha.TabIndex = 3;
            // 
            // tbIzquierda
            // 
            this.tbIzquierda.Location = new System.Drawing.Point(98, 53);
            this.tbIzquierda.Name = "tbIzquierda";
            this.tbIzquierda.Size = new System.Drawing.Size(100, 20);
            this.tbIzquierda.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbIPLocal);
            this.groupBox1.Controls.Add(this.btEscuchar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btConectar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbDerecha);
            this.groupBox1.Controls.Add(this.tbIzquierda);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 140);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IPs";
            // 
            // btEscuchar
            // 
            this.btEscuchar.Location = new System.Drawing.Point(10, 105);
            this.btEscuchar.Name = "btEscuchar";
            this.btEscuchar.Size = new System.Drawing.Size(75, 23);
            this.btEscuchar.TabIndex = 4;
            this.btEscuchar.Text = "Escuchar";
            this.btEscuchar.UseVisualStyleBackColor = true;
            this.btEscuchar.Click += new System.EventHandler(this.btEscuchar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP Propia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vecino derecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vecino izquierda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btEnviar);
            this.groupBox2.Controls.Add(this.tbEnviar);
            this.groupBox2.Location = new System.Drawing.Point(225, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 140);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texto a enviar";
            // 
            // tbEnviar
            // 
            this.tbEnviar.Location = new System.Drawing.Point(6, 27);
            this.tbEnviar.Multiline = true;
            this.tbEnviar.Name = "tbEnviar";
            this.tbEnviar.Size = new System.Drawing.Size(188, 72);
            this.tbEnviar.TabIndex = 7;
            // 
            // btEnviar
            // 
            this.btEnviar.Location = new System.Drawing.Point(119, 105);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(75, 23);
            this.btEnviar.TabIndex = 7;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // cbIPLocal
            // 
            this.cbIPLocal.FormattingEnabled = true;
            this.cbIPLocal.Location = new System.Drawing.Point(98, 19);
            this.cbIPLocal.Name = "cbIPLocal";
            this.cbIPLocal.Size = new System.Drawing.Size(100, 21);
            this.cbIPLocal.TabIndex = 8;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 164);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.TextBox tbDerecha;
        private System.Windows.Forms.TextBox tbIzquierda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btEscuchar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.TextBox tbEnviar;
        private System.Windows.Forms.ComboBox cbIPLocal;
    }
}