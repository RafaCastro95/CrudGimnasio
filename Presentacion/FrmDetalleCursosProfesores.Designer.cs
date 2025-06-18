namespace Grupo06_TP_Programacion1.Presentacion
{
    partial class FrmDetalleCursosProfesores
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gpbDatosProfesor = new System.Windows.Forms.GroupBox();
            this.lstClases = new System.Windows.Forms.ListBox();
            this.lstAlumnos = new System.Windows.Forms.ListBox();
            this.lblClases = new System.Windows.Forms.Label();
            this.lblSocios = new System.Windows.Forms.Label();
            this.gpbDatosProfesor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(365, 359);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(80, 359);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // gpbDatosProfesor
            // 
            this.gpbDatosProfesor.Controls.Add(this.lblSocios);
            this.gpbDatosProfesor.Controls.Add(this.lblClases);
            this.gpbDatosProfesor.Controls.Add(this.lstAlumnos);
            this.gpbDatosProfesor.Controls.Add(this.lstClases);
            this.gpbDatosProfesor.Location = new System.Drawing.Point(21, 12);
            this.gpbDatosProfesor.Name = "gpbDatosProfesor";
            this.gpbDatosProfesor.Size = new System.Drawing.Size(483, 330);
            this.gpbDatosProfesor.TabIndex = 3;
            this.gpbDatosProfesor.TabStop = false;
            this.gpbDatosProfesor.Text = "Apellido, Nombre";
            // 
            // lstClases
            // 
            this.lstClases.FormattingEnabled = true;
            this.lstClases.Location = new System.Drawing.Point(26, 46);
            this.lstClases.Name = "lstClases";
            this.lstClases.Size = new System.Drawing.Size(166, 238);
            this.lstClases.TabIndex = 0;
            // 
            // lstAlumnos
            // 
            this.lstAlumnos.FormattingEnabled = true;
            this.lstAlumnos.Location = new System.Drawing.Point(285, 46);
            this.lstAlumnos.Name = "lstAlumnos";
            this.lstAlumnos.Size = new System.Drawing.Size(166, 238);
            this.lstAlumnos.TabIndex = 1;
            // 
            // lblClases
            // 
            this.lblClases.AutoSize = true;
            this.lblClases.Location = new System.Drawing.Point(86, 30);
            this.lblClases.Name = "lblClases";
            this.lblClases.Size = new System.Drawing.Size(38, 13);
            this.lblClases.TabIndex = 2;
            this.lblClases.Text = "Clases";
            // 
            // lblSocios
            // 
            this.lblSocios.AutoSize = true;
            this.lblSocios.Location = new System.Drawing.Point(353, 30);
            this.lblSocios.Name = "lblSocios";
            this.lblSocios.Size = new System.Drawing.Size(39, 13);
            this.lblSocios.TabIndex = 3;
            this.lblSocios.Text = "Socios";
            // 
            // FrmDetalleCursosProfesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 406);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gpbDatosProfesor);
            this.Name = "FrmDetalleCursosProfesores";
            this.Text = "Detalle Clases";
            this.Load += new System.EventHandler(this.FrmDetalleCursosProfesores_Load);
            this.gpbDatosProfesor.ResumeLayout(false);
            this.gpbDatosProfesor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gpbDatosProfesor;
        private System.Windows.Forms.ListBox lstAlumnos;
        private System.Windows.Forms.ListBox lstClases;
        private System.Windows.Forms.Label lblClases;
        private System.Windows.Forms.Label lblSocios;
    }
}