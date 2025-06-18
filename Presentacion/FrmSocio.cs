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
    public partial class FrmSocio : Form
    {
        ProfesorServicio oPServicio;
        public FrmSocio()
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleSocio fds = new FrmDetalleSocio();
            fds.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmSocio_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.CargarCombo(cboCursos, oPServicio.TraerCursos(), "Nombre", "IdCurso");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string filtro = txtNombreSocio.Text;
            List<Socio> lista = oPServicio.TraerSocios(filtro, cboCursos);

            dgvSocios.Rows.Clear();

            foreach (Socio socio in lista)
            {
                string nombreCompleto = socio.Apellido + ", " + socio.Nombre;
                dgvSocios.Rows.Add(socio.IdSocio, nombreCompleto, socio.Documento, socio.Curso.Nombre, socio.FechaInicio.ToString("dd/MM/yyyy"), socio.FechaFin.ToString("dd/MM/yyyy"),
                   $" $ {socio.Monto:N2}");
            }
        }
    }
}
