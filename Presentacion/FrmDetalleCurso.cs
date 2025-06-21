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
    public partial class FrmDetalleCurso : Form
    {
        private int idProfesor = 0;
        ProfesorServicio oPServicio;
        List<Clase> listaClases;
        public FrmDetalleCurso(int idProfesor)
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
            this.idProfesor = idProfesor;
        }

        private void FrmDetalleCurso_Load(object sender, EventArgs e)
        {
            dgvClases.RowHeadersVisible = false;
            Profesor profesor = oPServicio.RecuperarProfesorPorID(idProfesor);
            lblProfesor.Text = $"Profesor/a: {profesor.Apellido}, {profesor.Nombre}";

            listaClases = oPServicio.TraerClasesPorProfesor(idProfesor);
            foreach (Clase clase in listaClases)
            {
                // con formato hora
                string horario = $"{clase.Horario.HoraInicio.ToString(@"hh\:mm")} A {clase.Horario.HoraFin.ToString(@"hh\:mm")}";
                dgvClases.Rows.Add(clase.IdClase, clase.Curso.Nombre, horario);
            }
            dgvClases.ClearSelection();
        }

        private void dgvClases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClases.SelectedRows.Count > 0)
            {
                int index = dgvClases.SelectedRows[0].Index;
                if (index >= 0 && index < listaClases.Count)
                {
                    Clase clase = listaClases[index];
                    CargarSociosPorClase(clase.IdClase, clase.Profesor.IdProfesor);
                }
            }
        }

        private void CargarSociosPorClase(int idClase, int idProfesor)
        {
            List<Socio> listaSocios = oPServicio.TraerSociosPorClase(idClase, idProfesor);
            lstSocios.Items.Clear();
            foreach (Socio s in listaSocios)
            {
                lstSocios.Items.Add($"{s.Apellido}, {s.Nombre}");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e) => this.Close();
    }
}
