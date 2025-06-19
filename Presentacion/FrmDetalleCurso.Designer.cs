namespace Grupo06_TP_Programacion1.Presentacion
{
    partial class FrmDetalleCurso
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
            this.lblProfesor = new System.Windows.Forms.Label();
            this.dgvClases = new System.Windows.Forms.DataGridView();
            this.IdClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstSocios = new System.Windows.Forms.ListBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblHorario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProfesor
            // 
            this.lblProfesor.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblProfesor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProfesor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfesor.Location = new System.Drawing.Point(0, 0);
            this.lblProfesor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProfesor.Name = "lblProfesor";
            this.lblProfesor.Padding = new System.Windows.Forms.Padding(8);
            this.lblProfesor.Size = new System.Drawing.Size(611, 40);
            this.lblProfesor.TabIndex = 0;
            this.lblProfesor.Text = "Profesor/a: Apellido, Nombre";
            // 
            // dgvClases
            // 
            this.dgvClases.AllowUserToAddRows = false;
            this.dgvClases.AllowUserToDeleteRows = false;
            this.dgvClases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClases.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvClases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdClase,
            this.Curso,
            this.Horario});
            this.dgvClases.Location = new System.Drawing.Point(21, 93);
            this.dgvClases.Name = "dgvClases";
            this.dgvClases.ReadOnly = true;
            this.dgvClases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClases.Size = new System.Drawing.Size(300, 200);
            this.dgvClases.TabIndex = 1;
            this.dgvClases.SelectionChanged += new System.EventHandler(this.dgvClases_SelectionChanged);
            // 
            // IdClase
            // 
            this.IdClase.HeaderText = "IdClase";
            this.IdClase.Name = "IdClase";
            this.IdClase.ReadOnly = true;
            this.IdClase.Visible = false;
            // 
            // Curso
            // 
            this.Curso.HeaderText = "Curso";
            this.Curso.Name = "Curso";
            this.Curso.ReadOnly = true;
            // 
            // Horario
            // 
            this.Horario.HeaderText = "Horario";
            this.Horario.Name = "Horario";
            this.Horario.ReadOnly = true;
            // 
            // lstSocios
            // 
            this.lstSocios.FormattingEnabled = true;
            this.lstSocios.ItemHeight = 17;
            this.lstSocios.Location = new System.Drawing.Point(353, 93);
            this.lstSocios.Name = "lstSocios";
            this.lstSocios.Size = new System.Drawing.Size(235, 208);
            this.lstSocios.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.CausesValidation = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(347, 49);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(167, 30);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Socios Inscriptos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnVolver.Location = new System.Drawing.Point(300, 370);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.CausesValidation = false;
            this.lblHorario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario.Location = new System.Drawing.Point(30, 49);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(91, 30);
            this.lblHorario.TabIndex = 5;
            this.lblHorario.Text = "Horarios";
            this.lblHorario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmDetalleCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 411);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lstSocios);
            this.Controls.Add(this.dgvClases);
            this.Controls.Add(this.lblProfesor);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDetalleCurso";
            this.Text = "Detalle Curso";
            this.Load += new System.EventHandler(this.FrmDetalleCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProfesor;
        private System.Windows.Forms.DataGridView dgvClases;
        private System.Windows.Forms.ListBox lstSocios;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horario;
    }
}