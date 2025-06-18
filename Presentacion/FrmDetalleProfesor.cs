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
            oPServicio.CargarCombo(cboTipoDocumento, oPServicio.RecuperarTiposDocumentos(), "Descripcion", "IdTipo");
            oPServicio.CargarCombo(cboGenero, oPServicio.RecuperarGeneros(), "Descripcion", "IdGenero");
        }
    }
}
