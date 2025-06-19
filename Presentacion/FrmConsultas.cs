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
    public partial class FrmConsultas : Form
    {
        ProfesorServicio oPServicio;
        public FrmConsultas()
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmConsultas_Load(object sender, EventArgs e)
        {
            cboConsulta.SelectedIndex = -1;
            cboConsulta.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            switch (cboConsulta.SelectedIndex)
            {
                case 0:
                    dgvConsultas.DataSource = oPServicio.Resultado1();
                    break;
                case 1:
                    dgvConsultas.DataSource = oPServicio.Resultado2();
                    break;
                case 2:
                    dgvConsultas.DataSource = oPServicio.Resultado3();
                    break;
                case 3:
                    dgvConsultas.DataSource = oPServicio.Resultado4();
                    break;
                case 4:
                    dgvConsultas.DataSource = oPServicio.Resultado5();
                    break;
                case 5:
                    dgvConsultas.DataSource = oPServicio.Resultado6();
                    break;
            }
        }
    }
}
