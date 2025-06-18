using Grupo06_TP_Programacion1.Negocio;
using Grupo06_TP_Programacion1.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo06_TP_Programacion1.Presentacion
{
    public partial class FrmDetalleProfesor : Form
    {
        ProfesorServicio oPServicio;
        public FrmDetalleProfesor()
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmDetalleProfesor_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.CargarCombo(cboTipoDocumento, oPServicio.TraerTiposDocumentos(), "Descripcion", "IdTipo");
            ComboBoxHelper.CargarCombo(cboGenero, oPServicio.TraerGeneros(), "Descripcion", "IdGenero");
            ComboBoxHelper.CargarCombo(cboProvincia, oPServicio.TraerProvincias(), "Descripcion", "IdProvincia");
           
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

            //Guardar los datos del profesor
            Profesor oProfesor = new Profesor();
            oProfesor.Nombre = txtNombre.Text;
            oProfesor.Apellido = txtApellido.Text;
            oProfesor.Documento = txtDocumento.Text;
            oProfesor.FechaNacimiento = dtpFechaNacimiento.Value;
            oProfesor.Telefono = txtTelefono.Text;
            oProfesor.Email = txtEmail.Text;
            oProfesor.Tipo = (TipoDocumento)cboTipoDocumento.SelectedItem;
            oProfesor.Genero = (Genero)cboGenero.SelectedItem;
            if (cboBarrio.SelectedIndex != -1 && cboBarrio.SelectedValue != null)
            {
                oProfesor.Barrio = (Barrio)cboBarrio.SelectedItem;
            }

            if (oPServicio.GuardarProfesor(oProfesor) > 0)
            {
                MessageBox.Show("Profesor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else
            {
                MessageBox.Show("Error al guardar el profesor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
