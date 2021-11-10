namespace Globi
{
    partial class formEspecialidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEspecialidad));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lstEspecialidades = new System.Windows.Forms.ListBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAgregarEspe = new System.Windows.Forms.Button();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEditarPr = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBorrarPrac = new System.Windows.Forms.Button();
            this.lstPracticas = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEditarDiag = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBorrarDiag = new System.Windows.Forms.Button();
            this.lstDiagnosticos = new System.Windows.Forms.ListBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnEditar);
            this.panel2.Controls.Add(this.btnBorrar);
            this.panel2.Controls.Add(this.lstEspecialidades);
            this.panel2.Controls.Add(this.btnNuevo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 318);
            this.panel2.TabIndex = 15;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(8, 234);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(56, 23);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(72, 234);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(56, 23);
            this.btnBorrar.TabIndex = 11;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // lstEspecialidades
            // 
            this.lstEspecialidades.FormattingEnabled = true;
            this.lstEspecialidades.Location = new System.Drawing.Point(8, 29);
            this.lstEspecialidades.Name = "lstEspecialidades";
            this.lstEspecialidades.Size = new System.Drawing.Size(120, 199);
            this.lstEspecialidades.TabIndex = 1;
            this.lstEspecialidades.SelectedIndexChanged += new System.EventHandler(this.lstEspecialidades_SelectedIndexChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(8, 277);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 32);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "Nueva Especialidad";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Especialidades";
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Location = new System.Drawing.Point(97, 11);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(139, 20);
            this.txtEspecialidad.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Especialidad";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(210, 345);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAgregarEspe);
            this.panel1.Controls.Add(this.btnAgregarItem);
            this.panel1.Controls.Add(this.txtItem);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEspecialidad);
            this.panel1.Location = new System.Drawing.Point(159, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 83);
            this.panel1.TabIndex = 19;
            // 
            // btnAgregarEspe
            // 
            this.btnAgregarEspe.Location = new System.Drawing.Point(242, 9);
            this.btnAgregarEspe.Name = "btnAgregarEspe";
            this.btnAgregarEspe.Size = new System.Drawing.Size(59, 23);
            this.btnAgregarEspe.TabIndex = 8;
            this.btnAgregarEspe.Text = "Agregar";
            this.btnAgregarEspe.UseVisualStyleBackColor = true;
            this.btnAgregarEspe.Click += new System.EventHandler(this.btnAgregarEspe_Click);
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Location = new System.Drawing.Point(242, 47);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(59, 23);
            this.btnAgregarItem.TabIndex = 7;
            this.btnAgregarItem.Text = "Agregar";
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(97, 49);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(139, 20);
            this.txtItem.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Agregar Item";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnEditarPr);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnBorrarPrac);
            this.panel3.Controls.Add(this.lstPracticas);
            this.panel3.Location = new System.Drawing.Point(159, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(161, 229);
            this.panel3.TabIndex = 20;
            // 
            // btnEditarPr
            // 
            this.btnEditarPr.Location = new System.Drawing.Point(18, 197);
            this.btnEditarPr.Name = "btnEditarPr";
            this.btnEditarPr.Size = new System.Drawing.Size(56, 23);
            this.btnEditarPr.TabIndex = 14;
            this.btnEditarPr.Text = "Editar";
            this.btnEditarPr.UseVisualStyleBackColor = true;
            this.btnEditarPr.Click += new System.EventHandler(this.btnEditarPr_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Practicas";
            // 
            // btnBorrarPrac
            // 
            this.btnBorrarPrac.Location = new System.Drawing.Point(82, 197);
            this.btnBorrarPrac.Name = "btnBorrarPrac";
            this.btnBorrarPrac.Size = new System.Drawing.Size(56, 23);
            this.btnBorrarPrac.TabIndex = 13;
            this.btnBorrarPrac.Text = "Borrar";
            this.btnBorrarPrac.UseVisualStyleBackColor = true;
            this.btnBorrarPrac.Click += new System.EventHandler(this.btnBorrarPrac_Click);
            // 
            // lstPracticas
            // 
            this.lstPracticas.FormattingEnabled = true;
            this.lstPracticas.Location = new System.Drawing.Point(11, 18);
            this.lstPracticas.Name = "lstPracticas";
            this.lstPracticas.Size = new System.Drawing.Size(137, 173);
            this.lstPracticas.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnEditarDiag);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btnBorrarDiag);
            this.panel4.Controls.Add(this.lstDiagnosticos);
            this.panel4.Location = new System.Drawing.Point(326, 101);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(158, 229);
            this.panel4.TabIndex = 21;
            // 
            // btnEditarDiag
            // 
            this.btnEditarDiag.Location = new System.Drawing.Point(18, 197);
            this.btnEditarDiag.Name = "btnEditarDiag";
            this.btnEditarDiag.Size = new System.Drawing.Size(56, 23);
            this.btnEditarDiag.TabIndex = 16;
            this.btnEditarDiag.Text = "Editar";
            this.btnEditarDiag.UseVisualStyleBackColor = true;
            this.btnEditarDiag.Click += new System.EventHandler(this.btnEditarDiag_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Diagnosticos";
            // 
            // btnBorrarDiag
            // 
            this.btnBorrarDiag.Location = new System.Drawing.Point(82, 197);
            this.btnBorrarDiag.Name = "btnBorrarDiag";
            this.btnBorrarDiag.Size = new System.Drawing.Size(56, 23);
            this.btnBorrarDiag.TabIndex = 15;
            this.btnBorrarDiag.Text = "Borrar";
            this.btnBorrarDiag.UseVisualStyleBackColor = true;
            this.btnBorrarDiag.Click += new System.EventHandler(this.btnBorrarDiag_Click);
            // 
            // lstDiagnosticos
            // 
            this.lstDiagnosticos.FormattingEnabled = true;
            this.lstDiagnosticos.Location = new System.Drawing.Point(11, 18);
            this.lstDiagnosticos.Name = "lstDiagnosticos";
            this.lstDiagnosticos.Size = new System.Drawing.Size(134, 173);
            this.lstDiagnosticos.TabIndex = 1;
            // 
            // formEspecialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 389);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formEspecialidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Especialidades";
            this.Load += new System.EventHandler(this.formEspecialidad_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.ListBox lstEspecialidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstPracticas;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstDiagnosticos;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditarPr;
        private System.Windows.Forms.Button btnBorrarPrac;
        private System.Windows.Forms.Button btnEditarDiag;
        private System.Windows.Forms.Button btnBorrarDiag;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.Button btnAgregarEspe;
    }
}