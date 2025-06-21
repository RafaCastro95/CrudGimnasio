using Grupo06_TP_Programacion1.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo06_TP_Programacion1
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PbxGym.Enabled = false;
        }

        private void BtnSocios_Click(object sender, EventArgs e)
        {
            FrmSocio fs = new FrmSocio(this);
            this.Hide();
            fs.Show();
        }

        private void BtnProfesores_Click(object sender, EventArgs e)
        {
            FrmProfesor fp = new FrmProfesor(this);
            this.Hide();
            fp.ShowDialog();
        }

        private void BtnConsultas_Click(object sender, EventArgs e)
        {
            FrmConsultas fc = new FrmConsultas(this);
            this.Hide();
            fc.ShowDialog();
        }
    }
}
