namespace Grupo06_TP_Programacion1.Presentacion
{
    partial class FrmDetalleSocio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleSocio));
            this.gpbSocio = new System.Windows.Forms.GroupBox();
            this.cboTipoSangre = new System.Windows.Forms.ComboBox();
            this.cboContextura = new System.Windows.Forms.ComboBox();
            this.lblTipoSangre = new System.Windows.Forms.Label();
            this.lblContextura = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.cboBarrio = new System.Windows.Forms.ComboBox();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gpbSocio.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbSocio
            // 
            this.gpbSocio.Controls.Add(this.cboTipoSangre);
            this.gpbSocio.Controls.Add(this.cboContextura);
            this.gpbSocio.Controls.Add(this.lblTipoSangre);
            this.gpbSocio.Controls.Add(this.lblContextura);
            this.gpbSocio.Controls.Add(this.txtTelefono);
            this.gpbSocio.Controls.Add(this.lblTelefono);
            this.gpbSocio.Controls.Add(this.dtpFechaNacimiento);
            this.gpbSocio.Controls.Add(this.cboGenero);
            this.gpbSocio.Controls.Add(this.txtEmail);
            this.gpbSocio.Controls.Add(this.txtDocumento);
            this.gpbSocio.Controls.Add(this.cboLocalidad);
            this.gpbSocio.Controls.Add(this.cboProvincia);
            this.gpbSocio.Controls.Add(this.cboBarrio);
            this.gpbSocio.Controls.Add(this.lblInformacion);
            this.gpbSocio.Controls.Add(this.cboTipoDocumento);
            this.gpbSocio.Controls.Add(this.lblLocalidad);
            this.gpbSocio.Controls.Add(this.lblBarrio);
            this.gpbSocio.Controls.Add(this.lblFechaNacimiento);
            this.gpbSocio.Controls.Add(this.lblDocumento);
            this.gpbSocio.Controls.Add(this.lblTipoDocumento);
            this.gpbSocio.Controls.Add(this.lblGenero);
            this.gpbSocio.Controls.Add(this.lblEmail);
            this.gpbSocio.Controls.Add(this.lblProvincia);
            this.gpbSocio.Controls.Add(this.txtNombre);
            this.gpbSocio.Controls.Add(this.lblNombre);
            this.gpbSocio.Controls.Add(this.txtApellido);
            this.gpbSocio.Controls.Add(this.lblApellido);
            this.gpbSocio.Location = new System.Drawing.Point(29, 22);
            this.gpbSocio.Name = "gpbSocio";
            this.gpbSocio.Size = new System.Drawing.Size(557, 454);
            this.gpbSocio.TabIndex = 0;
            this.gpbSocio.TabStop = false;
            this.gpbSocio.Text = "Datos Socios";
            // 
            // cboTipoSangre
            // 
            this.cboTipoSangre.FormattingEnabled = true;
            this.cboTipoSangre.Location = new System.Drawing.Point(386, 211);
            this.cboTipoSangre.Name = "cboTipoSangre";
            this.cboTipoSangre.Size = new System.Drawing.Size(121, 21);
            this.cboTipoSangre.TabIndex = 15;
            // 
            // cboContextura
            // 
            this.cboContextura.FormattingEnabled = true;
            this.cboContextura.Location = new System.Drawing.Point(132, 205);
            this.cboContextura.Name = "cboContextura";
            this.cboContextura.Size = new System.Drawing.Size(127, 21);
            this.cboContextura.TabIndex = 13;
            // 
            // lblTipoSangre
            // 
            this.lblTipoSangre.AutoSize = true;
            this.lblTipoSangre.Location = new System.Drawing.Point(299, 211);
            this.lblTipoSangre.Name = "lblTipoSangre";
            this.lblTipoSangre.Size = new System.Drawing.Size(69, 13);
            this.lblTipoSangre.TabIndex = 14;
            this.lblTipoSangre.Text = "Tipo Sangre*";
            // 
            // lblContextura
            // 
            this.lblContextura.AutoSize = true;
            this.lblContextura.Location = new System.Drawing.Point(44, 205);
            this.lblContextura.Name = "lblContextura";
            this.lblContextura.Size = new System.Drawing.Size(62, 13);
            this.lblContextura.TabIndex = 12;
            this.lblContextura.Text = "Contextura*";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(386, 271);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(121, 20);
            this.txtTelefono.TabIndex = 19;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(319, 271);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 18;
            this.lblTelefono.Text = "Teléfono";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(386, 151);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaNacimiento.TabIndex = 11;
            // 
            // cboGenero
            // 
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(132, 146);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(127, 21);
            this.cboGenero.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(132, 264);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(127, 20);
            this.txtEmail.TabIndex = 17;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(386, 91);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(121, 20);
            this.txtDocumento.TabIndex = 7;
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(386, 331);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(121, 21);
            this.cboLocalidad.TabIndex = 23;
            this.cboLocalidad.SelectedIndexChanged += new System.EventHandler(this.cboLocalidad_SelectedIndexChanged);
            // 
            // cboProvincia
            // 
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(132, 323);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(127, 21);
            this.cboProvincia.TabIndex = 21;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // cboBarrio
            // 
            this.cboBarrio.FormattingEnabled = true;
            this.cboBarrio.Location = new System.Drawing.Point(132, 382);
            this.cboBarrio.Name = "cboBarrio";
            this.cboBarrio.Size = new System.Drawing.Size(127, 21);
            this.cboBarrio.TabIndex = 25;
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Location = new System.Drawing.Point(26, 434);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(177, 13);
            this.lblInformacion.TabIndex = 26;
            this.lblInformacion.Text = "Los campos con (*) son obligatorios.";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(132, 87);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(127, 21);
            this.cboTipoDocumento.TabIndex = 5;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(311, 331);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(57, 13);
            this.lblLocalidad.TabIndex = 22;
            this.lblLocalidad.Text = "Localidad*";
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(68, 382);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(38, 13);
            this.lblBarrio.TabIndex = 24;
            this.lblBarrio.Text = "Barrio*";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(271, 151);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(93, 13);
            this.lblFechaNacimiento.TabIndex = 10;
            this.lblFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(287, 91);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(81, 13);
            this.lblDocumento.TabIndex = 6;
            this.lblDocumento.Text = "N° Documento*";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(16, 87);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(90, 13);
            this.lblTipoDocumento.TabIndex = 4;
            this.lblTipoDocumento.Text = "Tipo Documento*";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(60, 146);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(46, 13);
            this.lblGenero.TabIndex = 8;
            this.lblGenero.Text = "Género*";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(65, 264);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 13);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "E - mail";
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(51, 323);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(55, 13);
            this.lblProvincia.TabIndex = 20;
            this.lblProvincia.Text = "Provincia*";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(386, 31);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(320, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(48, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre*";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(132, 28);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(127, 20);
            this.txtApellido.TabIndex = 1;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(58, 28);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(48, 13);
            this.lblApellido.TabIndex = 0;
            this.lblApellido.Text = "Apellido*";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(429, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(144, 497);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // FrmDetalleSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 532);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gpbSocio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDetalleSocio";
            this.Text = "Detalle Socio";
            this.Load += new System.EventHandler(this.FrmDetalleSocio_Load);
            this.gpbSocio.ResumeLayout(false);
            this.gpbSocio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbSocio;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.ComboBox cboBarrio;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboTipoSangre;
        private System.Windows.Forms.ComboBox cboContextura;
        private System.Windows.Forms.Label lblTipoSangre;
        private System.Windows.Forms.Label lblContextura;
    }
}