using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grupo06_TP_Programacion1.Negocio;
using Grupo06_TP_Programacion1.Servicio;

namespace Grupo06_TP_Programacion1.Presentacion
{
    public partial class FrmDetalleCursosProfesores : Form
    {
        private int idProfesor = 0;
        ProfesorServicio oPServicio;
        List<Clase> listaClases;

        public FrmDetalleCursosProfesores(int idProfesor)
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
            this.idProfesor = idProfesor;
        }

        private void FrmDetalleCursosProfesores_Load(object sender, EventArgs e)
        {
            Profesor profesor = oPServicio.RecuperarProfesorPorID(idProfesor);
            gpbDatosProfesor.Text = $"{profesor.Apellido}, {profesor.Nombre}";

            listaClases = oPServicio.TraerClasesPorProfesor(idProfesor);
            foreach(Clase clase in listaClases)
            {
                lstClases.Items.Add(clase.Curso);
                lstClases.DisplayMember = "Nombre";
                lstClases.ValueMember = "IdCurso";
            }
        }

        private void lstClases_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clase clase = listaClases[lstClases.SelectedIndex];

            CargarSociosPorClase(clase.IdClase, clase.Profesor.IdProfesor);
        }

        private void CargarSociosPorClase(int idClase, int idProfesor)
        {
            List<Socio> listaSocios = oPServicio.TraerSociosPorClase(idClase, idProfesor);
            lstAlumnos.Items.Clear();
            foreach (Socio s in listaSocios)
            {
                lstAlumnos.Items.Add($"{s.Apellido}, {s.Nombre}");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
