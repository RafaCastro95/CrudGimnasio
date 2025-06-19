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
        ProfesorServicio oPServicio;
        string documento;
        Modo accion;
        AccesoDatos AccesoDatos = new AccesoDatos();
        Socio socio = new Socio();

        public FrmDetalleSocio()
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
        }
        public FrmDetalleSocio(Modo accion, string documento)
        {
            InitializeComponent();
            this.accion = accion;
            this.documento = documento;
            oPServicio = new ProfesorServicio();
            txtDocumento.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmDetalleSocio_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.CargarCombo(cboTipoDocumento, oPServicio.TraerTiposDocumentos(), "Descripcion", "IdTipo", false);
            ComboBoxHelper.CargarCombo(cboGenero, oPServicio.TraerGeneros(), "Descripcion", "IdGenero", false);
            ComboBoxHelper.CargarCombo(cboProvincia, oPServicio.TraerProvincias(), "Descripcion", "IdProvincia", true);
            ComboBoxHelper.CargarCombo(cboContextura, oPServicio.TraerContexturas(), "Descripcion", "IdContextura", false);
            ComboBoxHelper.CargarCombo(cboTipoSangre, oPServicio.TraerTiposSangre(), "Descripcion", "IdTipoSangre", false);
            if (accion != Modo.Nuevo)
            {
                CargarSocio(documento);
            }
        }

        //Metodo para cargar los datos del socio
        public void CargarSocio(string documento)
        {
            int pk_Provincias = 0;
            int pk_localidades = 0;
            DataTable dt = oPServicio.RecuperarSocio(documento);
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
                pk_localidades = Convert.ToInt32(row[12]);
                pk_Provincias = Convert.ToInt32(row[13]);
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
        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex != -1 && cboProvincia.SelectedValue != null)
            {
                if (int.TryParse(cboProvincia.SelectedValue.ToString(), out int idProvincia))
                {
                    ComboBoxHelper.CargarCombo(cboLocalidad, oPServicio.TraerLocalidades(idProvincia), "Descripcion", "IdLocalidad", true);
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
                        ComboBoxHelper.CargarCombo(cboBarrio, oPServicio.TraerBarrios(idLocalidad), "Descripcion", "IdBarrio", true);
                    }
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios

            //insertar socio
            Socio oSocio = new Socio();
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


            if (oPServicio.GuardarSocio(oSocio) > 0)
            {
                MessageBox.Show("Socio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Dispose();
            }
            else
            {
                MessageBox.Show("Error al guardar el socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
