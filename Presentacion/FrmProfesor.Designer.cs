namespace Grupo06_TP_Programacion1.Presentacion
{
    partial class FrmProfesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProfesor));
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvProfesores = new System.Windows.Forms.DataGridView();
            this.IdProfesor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profesores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barrio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cursos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cboCurso = new System.Windows.Forms.ComboBox();
            this.lblCursos = new System.Windows.Forms.Label();
            this.txtNombreProfesor = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesores)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(77, 405);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvProfesores
            // 
            this.dgvProfesores.AllowUserToAddRows = false;
            this.dgvProfesores.AllowUserToDeleteRows = false;
            this.dgvProfesores.AllowUserToResizeColumns = false;
            this.dgvProfesores.AllowUserToResizeRows = false;
            this.dgvProfesores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfesores.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvProfesores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfesores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProfesor,
            this.Profesores,
            this.Documento,
            this.Telefono,
            this.Barrio,
            this.Cursos});
            this.dgvProfesores.Location = new System.Drawing.Point(32, 150);
            this.dgvProfesores.Name = "dgvProfesores";
            this.dgvProfesores.ReadOnly = true;
            this.dgvProfesores.Size = new System.Drawing.Size(493, 238);
            this.dgvProfesores.TabIndex = 5;
            this.dgvProfesores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProfesores_CellContentClick);
            // 
            // IdProfesor
            // 
            this.IdProfesor.HeaderText = "IdProfesor";
            this.IdProfesor.Name = "IdProfesor";
            this.IdProfesor.ReadOnly = true;
            this.IdProfesor.Visible = false;
            // 
            // Profesores
            // 
            this.Profesores.HeaderText = "Profesores";
            this.Profesores.Name = "Profesores";
            this.Profesores.ReadOnly = true;
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Barrio
            // 
            this.Barrio.HeaderText = "Barrio";
            this.Barrio.Name = "Barrio";
            this.Barrio.ReadOnly = true;
            // 
            // Cursos
            // 
            this.Cursos.HeaderText = "Cursos";
            this.Cursos.Name = "Cursos";
            this.Cursos.ReadOnly = true;
            this.Cursos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cursos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cursos.Text = "Ver Cursos";
            this.Cursos.UseColumnTextForButtonValue = true;
            // 
            // cboCurso
            // 
            this.cboCurso.FormattingEnabled = true;
            this.cboCurso.Location = new System.Drawing.Point(94, 105);
            this.cboCurso.Name = "cboCurso";
            this.cboCurso.Size = new System.Drawing.Size(296, 21);
            this.cboCurso.TabIndex = 4;
            // 
            // lblCursos
            // 
            this.lblCursos.AutoSize = true;
            this.lblCursos.Location = new System.Drawing.Point(29, 105);
            this.lblCursos.Name = "lblCursos";
            this.lblCursos.Size = new System.Drawing.Size(39, 13);
            this.lblCursos.TabIndex = 3;
            this.lblCursos.Text = "Cursos";
            // 
            // txtNombreProfesor
            // 
            this.txtNombreProfesor.Location = new System.Drawing.Point(94, 66);
            this.txtNombreProfesor.Name = "txtNombreProfesor";
            this.txtNombreProfesor.Size = new System.Drawing.Size(348, 20);
            this.txtNombreProfesor.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(29, 66);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(204, 405);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(331, 405);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 8;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(531, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 450);
            this.panel1.TabIndex = 9;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(10, 393);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(128, 33);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.White;
            this.btnConsultar.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(10, 75);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(128, 33);
            this.btnConsultar.TabIndex = 0;
            this.btnConsultar.Text = "Ver Profesores";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click_1);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Profesores";
            // 
            // FrmProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.cboCurso);
            this.Controls.Add(this.dgvProfesores);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCursos);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.txtNombreProfesor);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnNuevo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProfesor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profesores";
            this.Load += new System.EventHandler(this.FrmProfesor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreProfesor;
        private System.Windows.Forms.ComboBox cboCurso;
        private System.Windows.Forms.Label lblCursos;
        private System.Windows.Forms.DataGridView dgvProfesores;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProfesor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profesores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barrio;
        private System.Windows.Forms.DataGridViewButtonColumn Cursos;
    }
}