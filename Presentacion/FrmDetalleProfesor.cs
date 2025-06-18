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
            ComboBoxHelper.CargarCombo(cboTipoDocumento, oPServicio.RecuperarTiposDocumentos(), "Descripcion", "IdTipo");
            ComboBoxHelper.CargarCombo(cboGenero, oPServicio.RecuperarGeneros(), "Descripcion", "IdGenero");
            ComboBoxHelper.CargarCombo(cboProvincia, oPServicio.RecuperarProvincias(), "Descripcion", "IdProvincia");
           
        }
        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex != -1 && cboProvincia.SelectedValue != null)
            {
                if (int.TryParse(cboProvincia.SelectedValue.ToString(), out int idProvincia))
                {
                    ComboBoxHelper.CargarCombo(cboLocalidad, oPServicio.RecuperarLocalidades(idProvincia), "Descripcion", "IdLocalidad");
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
                        ComboBoxHelper.CargarCombo(cboBarrio, oPServicio.RecuperarBarrios(idLocalidad), "Descripcion", "IdBarrio");
                    }
                }
            }
        }
    }
}
