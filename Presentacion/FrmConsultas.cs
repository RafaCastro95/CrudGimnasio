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
        private FrmInicio _frmInicio;
        ConsultaServicio oCServicio;
        public FrmConsultas()
        {
            InitializeComponent();
            oCServicio = new ConsultaServicio();
        }
        public FrmConsultas(FrmInicio frmInicio)
        {
            InitializeComponent();
            _frmInicio = frmInicio;
            oCServicio = new ConsultaServicio();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmInicio.Show();
        }

        private void FrmConsultas_Load(object sender, EventArgs e)
        {
            cboConsulta.SelectedIndex = -1;
            cboConsulta.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvConsultas.RowHeadersVisible = false;
            btnConsultar.Enabled = false;
            cboConsulta.SelectedIndexChanged += cboConsulta_SelectedIndexChanged;
        }

        private void cboConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConsultar.Enabled = cboConsulta.SelectedIndex >= 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboConsulta.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione una consulta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (cboConsulta.SelectedIndex)
            {
                case 0:
                    dgvConsultas.DataSource = oCServicio.Resultado1();
                    dgvConsultas.ClearSelection();
                    break;
                case 1:
                    dgvConsultas.DataSource = oCServicio.Resultado2();
                    dgvConsultas.ClearSelection();
                    break;
                case 2:
                    dgvConsultas.DataSource = oCServicio.Resultado3();
                    dgvConsultas.ClearSelection();
                    break;
                case 3:
                    dgvConsultas.DataSource = oCServicio.Resultado4();
                    dgvConsultas.ClearSelection();
                    break;
                case 4:
                    dgvConsultas.DataSource = oCServicio.Resultado5();
                    dgvConsultas.ClearSelection();
                    break;
                case 5:
                    dgvConsultas.DataSource = oCServicio.Resultado6();
                    dgvConsultas.ClearSelection();
                    break;
            }
        }
    }
}
