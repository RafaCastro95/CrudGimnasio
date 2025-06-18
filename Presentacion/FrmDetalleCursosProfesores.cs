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

        public FrmDetalleCursosProfesores(int idProfesor)
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
            this.idProfesor = idProfesor;
        }

        private void FrmDetalleCursosProfesores_Load(object sender, EventArgs e)
        {
            Profesor profesor = oPServicio.RecuperarProfesorPorID(idProfesor);
            //List<Curso> cursos = profesor.Cursos;
        }
    }
}
