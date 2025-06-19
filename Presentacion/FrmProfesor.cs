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
    public partial class FrmProfesor : Form
    {

        ProfesorServicio oPServicio;
        public FrmProfesor()
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleProfesor fdp = new FrmDetalleProfesor(Modo.Nuevo);
            fdp.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmProfesor_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.CargarCombo(cboCurso, oPServicio.TraerCursos(), "Nombre", "IdCurso", true);
            cboCurso.SelectedIndex = 0;
        }

        private void CargarGridViewProfesores()
        {
            string filtroNombre = txtNombreProfesor.Text;
            int filtroClase = (int)cboCurso.SelectedValue;
            dgvProfesores.Rows.Clear();
            foreach (Profesor p in oPServicio.RecuperarProfesores(filtroNombre, filtroClase))
            {
                int pos = dgvProfesores.Rows.Add(p.IdProfesor, $"{p.Apellido}, {p.Nombre}", p.Documento, p.Telefono, p.Barrio.Descripcion);
                dgvProfesores.Rows[pos].Tag = p.IdProfesor;
            }
            int idProfesor = Convert.ToInt32(dgvProfesores.CurrentRow.Cells["IdProfesor"].Value);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarGridViewProfesores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProfesores.CurrentRow != null)
            {
                int idProfesor = Convert.ToInt32(dgvProfesores.CurrentRow.Cells["IdProfesor"].Value);
                FrmDetalleProfesor fdp = new FrmDetalleProfesor(Modo.Editar, idProfesor);
                fdp.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.");
            }
            Console.WriteLine(dgvProfesores.SelectedRows);
        }

        private void dgvProfesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                int idProfesor = (int)dgvProfesores.Rows[e.RowIndex].Cells[0].Value;
                MostrarDetalleCursos(idProfesor);
            }
        }

        private void MostrarDetalleCursos(int idProfesor)
        {
            FrmDetalleCurso frmDetalleCursosProfesores = new FrmDetalleCurso(idProfesor);
            frmDetalleCursosProfesores.ShowDialog();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(dgvProfesores.CurrentRow != null)
 {
                int id_profesor = Convert.ToInt32(dgvProfesores.CurrentRow.Cells["IdProfesor"].Value); // usa el nombre real de la columna

                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro que querés eliminar este Profesor?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    oPServicio.ElimianarProfesor(id_profesor);
                    CargarGridViewProfesores();
                }
            }
            else
            {
                MessageBox.Show("Seleccioná un profesor primero.");
            }
        }
    }
}
