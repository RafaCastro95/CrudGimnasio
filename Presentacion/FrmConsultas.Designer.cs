namespace Grupo06_TP_Programacion1.Presentacion
{
    partial class FrmConsultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultas));
            this.gpbProfesores = new System.Windows.Forms.GroupBox();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.cboConsulta = new System.Windows.Forms.ComboBox();
            this.lblConsultas = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gpbProfesores.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbProfesores
            // 
            this.gpbProfesores.Controls.Add(this.lblInformacion);
            this.gpbProfesores.Controls.Add(this.groupBox2);
            this.gpbProfesores.Controls.Add(this.cboConsulta);
            this.gpbProfesores.Controls.Add(this.lblConsultas);
            this.gpbProfesores.Controls.Add(this.btnConsultar);
            this.gpbProfesores.Location = new System.Drawing.Point(23, 42);
            this.gpbProfesores.Name = "gpbProfesores";
            this.gpbProfesores.Size = new System.Drawing.Size(707, 341);
            this.gpbProfesores.TabIndex = 0;
            this.gpbProfesores.TabStop = false;
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Location = new System.Drawing.Point(30, 325);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(177, 13);
            this.lblInformacion.TabIndex = 4;
            this.lblInformacion.Text = "Los campos con (*) son obligatorios.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvConsultas);
            this.groupBox2.Location = new System.Drawing.Point(33, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 239);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.AllowUserToAddRows = false;
            this.dgvConsultas.AllowUserToDeleteRows = false;
            this.dgvConsultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsultas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvConsultas.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultas.Location = new System.Drawing.Point(3, 16);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.ReadOnly = true;
            this.dgvConsultas.Size = new System.Drawing.Size(633, 220);
            this.dgvConsultas.TabIndex = 0;
            // 
            // cboConsulta
            // 
            this.cboConsulta.FormattingEnabled = true;
            this.cboConsulta.Items.AddRange(new object[] {
            "Socios de Musculación o Spinnig con credencial vencida",
            "Informe de Cobros por Provincia",
            "Socios de Córdoba con tipo de Sangre A+/B+/B-",
            "Socios de Córdoba, Mendoza o Buenos Aires inscriptos desde 2023",
            "Socios de Musculacion o Pilates en meses de Agosto, Septiembre o Noviembre",
            "Socios operados o en recuperacion y no asistan al gym en los últimos 18 meses"});
            this.cboConsulta.Location = new System.Drawing.Point(164, 39);
            this.cboConsulta.Name = "cboConsulta";
            this.cboConsulta.Size = new System.Drawing.Size(404, 21);
            this.cboConsulta.TabIndex = 1;
            // 
            // lblConsultas
            // 
            this.lblConsultas.AutoSize = true;
            this.lblConsultas.Location = new System.Drawing.Point(30, 39);
            this.lblConsultas.Name = "lblConsultas";
            this.lblConsultas.Size = new System.Drawing.Size(128, 13);
            this.lblConsultas.TabIndex = 0;
            this.lblConsultas.Text = "Seleccione una consulta*";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(582, 34);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(87, 28);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(623, 406);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 450);
            this.Controls.Add(this.gpbProfesores);
            this.Controls.Add(this.btnSalir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmConsultas";
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.FrmConsultas_Load);
            this.gpbProfesores.ResumeLayout(false);
            this.gpbProfesores.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbProfesores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboConsulta;
        private System.Windows.Forms.Label lblConsultas;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.DataGridView dgvConsultas;
    }
}