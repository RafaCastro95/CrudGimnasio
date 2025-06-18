using Grupo06_TP_Programacion1.Dao;
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

        public FrmDetalleSocio()
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmDetalleSocio_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.CargarCombo(cboTipoDocumento, oPServicio.TraerTiposDocumentos(), "Descripcion", "IdTipo");
            ComboBoxHelper.CargarCombo(cboGenero, oPServicio.TraerGeneros(), "Descripcion", "IdGenero");
            ComboBoxHelper.CargarCombo(cboProvincia, oPServicio.TraerProvincias(), "Descripcion", "IdProvincia");
            ComboBoxHelper.CargarCombo(cboContextura, oPServicio.TraerContexturas(), "Descripcion", "IdContextura");
            ComboBoxHelper.CargarCombo(cboTipoSangre, oPServicio.TraerTiposSangre(), "Descripcion", "IdTipoSangre");
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex != -1 && cboProvincia.SelectedValue != null)
            {
                if (int.TryParse(cboProvincia.SelectedValue.ToString(), out int idProvincia))
                {
                    ComboBoxHelper.CargarCombo(cboLocalidad, oPServicio.TraerLocalidades(idProvincia), "Descripcion", "IdLocalidad");
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
                        ComboBoxHelper.CargarCombo(cboBarrio, oPServicio.TraerBarrios(idLocalidad), "Descripcion", "IdBarrio");
                    }
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios

            //insertar socio
            Socio oSocio = new Socio();
            oSocio.Nombre = txtNombre.Text;
            oSocio.Apellido = txtApellido.Text;
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
                MessageBox.Show("El socio se ha guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else
            {
                MessageBox.Show("Error al guardar el socio. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
