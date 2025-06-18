namespace Grupo06_TP_Programacion1
{
    partial class FrmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.PbxGym = new System.Windows.Forms.PictureBox();
            this.BtnSocios = new System.Windows.Forms.Button();
            this.BtnProfesores = new System.Windows.Forms.Button();
            this.BtnConsultas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbxGym)).BeginInit();
            this.SuspendLayout();
            // 
            // PbxGym
            // 
            this.PbxGym.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbxGym.Image = global::Grupo06_TP_Programacion1.Properties.Resources.Gym_final;
            this.PbxGym.Location = new System.Drawing.Point(0, 0);
            this.PbxGym.Name = "PbxGym";
            this.PbxGym.Size = new System.Drawing.Size(821, 588);
            this.PbxGym.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxGym.TabIndex = 0;
            this.PbxGym.TabStop = false;
            // 
            // BtnSocios
            // 
            this.BtnSocios.Location = new System.Drawing.Point(125, 511);
            this.BtnSocios.Name = "BtnSocios";
            this.BtnSocios.Size = new System.Drawing.Size(88, 72);
            this.BtnSocios.TabIndex = 1;
            this.BtnSocios.Text = "Socios";
            this.BtnSocios.UseVisualStyleBackColor = true;
            this.BtnSocios.Click += new System.EventHandler(this.BtnSocios_Click);
            // 
            // BtnProfesores
            // 
            this.BtnProfesores.Location = new System.Drawing.Point(341, 494);
            this.BtnProfesores.Name = "BtnProfesores";
            this.BtnProfesores.Size = new System.Drawing.Size(136, 92);
            this.BtnProfesores.TabIndex = 2;
            this.BtnProfesores.Text = "Profesores";
            this.BtnProfesores.UseVisualStyleBackColor = true;
            this.BtnProfesores.Click += new System.EventHandler(this.BtnProfesores_Click);
            // 
            // BtnConsultas
            // 
            this.BtnConsultas.Location = new System.Drawing.Point(573, 494);
            this.BtnConsultas.Name = "BtnConsultas";
            this.BtnConsultas.Size = new System.Drawing.Size(135, 89);
            this.BtnConsultas.TabIndex = 3;
            this.BtnConsultas.Text = "Consultas";
            this.BtnConsultas.UseVisualStyleBackColor = true;
            this.BtnConsultas.Click += new System.EventHandler(this.BtnConsultas_Click);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 588);
            this.Controls.Add(this.PbxGym);
            this.Controls.Add(this.BtnSocios);
            this.Controls.Add(this.BtnProfesores);
            this.Controls.Add(this.BtnConsultas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxGym)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbxGym;
        private System.Windows.Forms.Button BtnSocios;
        private System.Windows.Forms.Button BtnProfesores;
        private System.Windows.Forms.Button BtnConsultas;
    }
}

