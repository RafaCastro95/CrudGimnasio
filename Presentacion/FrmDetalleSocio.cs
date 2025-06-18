using Grupo06_TP_Programacion1.Dao;
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
        PersonaDao oPServicio;
        public FrmDetalleSocio()
        {
            InitializeComponent();
            oPServicio = new PersonaDao();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmDetalleSocio_Load(object sender, EventArgs e)
        {
            //oPServicio.CargarCombo(cboTipoDocumento, oPServicio.RecuperarTiposDocumentos(), "Descripcion", "IdTipo");
            //oPServicio.CargarCombo(cboGenero, oPServicio.RecuperarGeneros(), "Descripcion", "IdGenero");
        }
    }
}
