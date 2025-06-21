using Grupo06_TP_Programacion1.Dao;
using Grupo06_TP_Programacion1.Datos;
using Grupo06_TP_Programacion1.Negocio;
using Grupo06_TP_Programacion1.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo06_TP_Programacion1.Presentacion
{
   
    public partial class FrmDetalleSocio : Form
    {
        private FrmSocio _frmSocio;
        PersonaServicio oPersonaServicio;
        SocioServicio oSServicio;
        string documento;
        Modo accion;
        AccesoDatos AccesoDatos = new AccesoDatos();
        Socio socio = new Socio();

        public FrmDetalleSocio(FrmSocio frmSocio)
        {
            InitializeComponent();
            oSServicio = new SocioServicio();
            oPersonaServicio = new PersonaServicio();
            _frmSocio = frmSocio;
        }
        public FrmDetalleSocio(FrmSocio frmSocio, Modo accion, string documento)
        {
            InitializeComponent();
            this.accion = accion;
            this.documento = documento;
            oSServicio = new SocioServicio();
            oPersonaServicio = new PersonaServicio();
            txtDocumento.Enabled = false;
            _frmSocio = frmSocio;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmSocio.Show();
        }

        private void FrmDetalleSocio_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.CargarCombo(cboTipoDocumento, oPersonaServicio.TraerTiposDocumentos(), "Descripcion", "IdTipo", false);
            ComboBoxHelper.CargarCombo(cboGenero, oPersonaServicio.TraerGeneros(), "Descripcion", "IdGenero", false);
            ComboBoxHelper.CargarCombo(cboProvincia, oPersonaServicio.TraerProvincias(), "Descripcion", "IdProvincia", true);
            ComboBoxHelper.CargarCombo(cboContextura, oPersonaServicio.TraerContexturas(), "Descripcion", "IdContextura", false);
            ComboBoxHelper.CargarCombo(cboTipoSangre, oPersonaServicio.TraerTiposSangre(), "Descripcion", "IdTipoSangre", false);
            if (accion != Modo.Nuevo)
            {
                CargarSocio(documento);
            }
        }


        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex != -1 && cboProvincia.SelectedValue != null)
            {
                if (int.TryParse(cboProvincia.SelectedValue.ToString(), out int idProvincia))
                {
                    ComboBoxHelper.CargarCombo(cboLocalidad, oPersonaServicio.TraerLocalidades(idProvincia), "Descripcion", "IdLocalidad", true);
                }
            }
        }

        private void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex != -1 && cboProvincia.SelectedValue != null)
            {
                if (cboLocalidad.SelectedIndex != -1 && cboLocalidad.SelectedValue != null)
                {
                    if (int.TryParse(cboLocalidad.SelectedValue.ToString(), out int idLocalidad))
                    {
                        ComboBoxHelper.CargarCombo(cboBarrio, oPersonaServicio.TraerBarrios(idLocalidad), "Descripcion", "IdBarrio", true);
                    }
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (ValidarDatos())
            {
                if (accion == Modo.Nuevo)
                {
                    GuardarSocio();
                }
                else if (accion == Modo.Editar)
                {
                    ActualizarSocio(documento);
                }
            }
            
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("El campo Apellido es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (!int.TryParse(txtDocumento.Text, out _))
            {
                MessageBox.Show("Complete con numero el campo Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDocumento.Focus();
                return false;
            }
            if (cboTipoDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoDocumento.Focus();
                return false;
            }
            if (cboGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un género.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGenero.Focus();
                return false;
            }
            if (cboProvincia.SelectedIndex <= 0)
            {
                MessageBox.Show("Complete con una opción el campo Provincia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboProvincia.Focus();
                return false;
            }
            if (cboLocalidad.SelectedIndex <= 0)
            {
                MessageBox.Show("Complete con una opción el campo Localidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLocalidad.Focus();
                return false;
            }
            if (cboBarrio.SelectedIndex <= 0)
            {
                MessageBox.Show("Complete con una opción el campo Barrio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBarrio.Focus();
                return false;
            }
            if (cboContextura.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una contextura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboContextura.Focus();
                return false;
            }
            if (cboTipoSangre.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de sangre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoSangre.Focus();
                return false;
            }
            return true;
        }

        private void ActualizarSocio(string documento)
        {
            int resultado = 0;
            Socio oSocio = new Socio();
            oSocio.IdSocio = socio.IdSocio;
            oSocio.Apellido = txtApellido.Text;
            oSocio.Nombre = txtNombre.Text;
            oSocio.Documento = txtDocumento.Text;
            oSocio.FechaNacimiento = dtpFechaNacimiento.Value;
            oSocio.Email = txtEmail.Text;
            oSocio.Telefono = txtTelefono.Text;
            oSocio.Tipo = (TipoDocumento)cboTipoDocumento.SelectedItem;
            oSocio.Genero = (Genero)cboGenero.SelectedItem;
            oSocio.Barrio = (Barrio)cboBarrio.SelectedItem;
            oSocio.Contextura = (Contextura)cboContextura.SelectedItem;
            oSocio.TipoSangre = (TipoSangre)cboTipoSangre.SelectedItem;
            resultado = oSServicio.EditarSocio(documento, oSocio);
            if (resultado > 0)
            {
                MessageBox.Show("Socio actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
                _frmSocio.Show();
            }
            else
            {
                MessageBox.Show("Error al actualizar el socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo para cargar los datos del socio
        public void CargarSocio(string documento)
        {
            int pk_Provincias = 0;
            int pk_localidades = 0;
            DataTable dt = oSServicio.RecuperarSocio(documento);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                socio.IdSocio = Convert.ToInt32(row[0]);
                socio.Nombre = row[1].ToString();
                socio.Apellido = row[2].ToString();
                socio.Documento = row[3].ToString();
                socio.FechaNacimiento = Convert.ToDateTime(row[4]);
                socio.Telefono = row[5].ToString();
                socio.Email = row[6].ToString();
                socio.Barrio = new Barrio
                {
                    IdBarrio = Convert.ToInt32(row[7])
                };
                socio.Tipo = new TipoDocumento
                {
                    IdTipo = Convert.ToInt32(row[8])
                };
                socio.Genero = new Genero
                {
                    IdGenero = Convert.ToInt32(row[9])
                };
                socio.Contextura = new Contextura
                {
                    IdContextura = Convert.ToInt32(row[10])
                };
                socio.TipoSangre = new TipoSangre
                {
                    IdTipoSangre = Convert.ToInt32(row[11])
                };
                socio.Activo = Convert.ToInt32(row[12]); 
                pk_localidades = Convert.ToInt32(row[13]);
                pk_Provincias = Convert.ToInt32(row[14]);
            }
            // Cargar los datos en los controles del formulario
            txtNombre.Text = socio.Nombre;
            txtApellido.Text = socio.Apellido;
            txtDocumento.Text = socio.Documento;
            dtpFechaNacimiento.Value = socio.FechaNacimiento;
            txtTelefono.Text = socio.Telefono;
            txtEmail.Text = socio.Email;
            cboTipoDocumento.SelectedValue = socio.Tipo.IdTipo;
            cboGenero.SelectedValue = socio.Genero.IdGenero;
            cboProvincia.SelectedValue = pk_Provincias;
            cboLocalidad.SelectedValue = pk_localidades;
            cboBarrio.SelectedValue = socio.Barrio.IdBarrio;
            cboContextura.SelectedValue = socio.Contextura.IdContextura;
            cboTipoSangre.SelectedValue = socio.TipoSangre.IdTipoSangre;
            if (accion == Modo.Editar)
            {
                txtDocumento.Enabled = false;
            }
            else
            {
                txtDocumento.Enabled = true;
            }
        }

        private void GuardarSocio()
        {
            //insertar socio
            Socio oSocio = new Socio();
            oSocio.Apellido = txtApellido.Text;
            oSocio.Nombre = txtNombre.Text;
            oSocio.Documento = txtDocumento.Text;
            oSocio.FechaNacimiento = dtpFechaNacimiento.Value;
            oSocio.Email = txtEmail.Text;
            oSocio.Telefono = txtTelefono.Text;

            // Validar que los objetos seleccionados no sean null
            if (cboTipoDocumento.SelectedItem == null || !(cboTipoDocumento.SelectedItem is TipoDocumento))
            {
                MessageBox.Show("Debe seleccionar un tipo de documento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipoDocumento.Focus();
                return;
            }
            if (cboGenero.SelectedItem == null || !(cboGenero.SelectedItem is Genero))
            {
                MessageBox.Show("Debe seleccionar un género válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboGenero.Focus();
                return;
            }
            if (cboBarrio.SelectedItem == null || !(cboBarrio.SelectedItem is Barrio))
            {
                MessageBox.Show("Debe seleccionar un barrio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBarrio.Focus();
                return;
            }
            if (cboContextura.SelectedItem == null || !(cboContextura.SelectedItem is Contextura))
            {
                MessageBox.Show("Debe seleccionar una contextura válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboContextura.Focus();
                return;
            }
            if (cboTipoSangre.SelectedItem == null || !(cboTipoSangre.SelectedItem is TipoSangre))
            {
                MessageBox.Show("Debe seleccionar un tipo de sangre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipoSangre.Focus();
                return;
            }

            oSocio.Tipo = (TipoDocumento)cboTipoDocumento.SelectedItem;
            oSocio.Genero = (Genero)cboGenero.SelectedItem;
            oSocio.Barrio = (Barrio)cboBarrio.SelectedItem;
            oSocio.Contextura = (Contextura)cboContextura.SelectedItem;
            oSocio.TipoSangre = (TipoSangre)cboTipoSangre.SelectedItem;

            // Validar que el barrio seleccionado tenga un IdBarrio válido (>0)
            if (oSocio.Barrio == null || oSocio.Barrio.IdBarrio <= 0)
            {
                MessageBox.Show("El barrio seleccionado no es válido. Por favor, seleccione un barrio existente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBarrio.Focus();
                return;
            }

            if (oSServicio.GuardarSocio(oSocio) > 0)
            {
                MessageBox.Show("Socio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
                _frmSocio.Show();
            }
            else
            {
                MessageBox.Show("Error al guardar el socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
