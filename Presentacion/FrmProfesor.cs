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
        private FrmInicio _frmInicio;
        PersonaServicio oPersonaServicio;
        ProfesorServicio oPServicio;
        public FrmProfesor()
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
            oPersonaServicio = new PersonaServicio();
        }
        public FrmProfesor(FrmInicio frmInicio)
        {
            InitializeComponent();
            _frmInicio = frmInicio;
            oPServicio = new ProfesorServicio();
            oPersonaServicio = new PersonaServicio();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleProfesor fdp = new FrmDetalleProfesor(this, Modo.Nuevo);
            this.Hide();
            fdp.ShowDialog();
        }

        private void FrmProfesor_Load(object sender, EventArgs e)
        {
            dgvProfesores.RowHeadersVisible = false;
            ComboBoxHelper.CargarCombo(cboCurso, oPersonaServicio.TraerCursos(), "Nombre", "IdCurso", true);
            cboCurso.SelectedIndex = 0;
            dgvProfesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesores.MultiSelect = false;
            dgvProfesores.SelectionChanged += dgvProfesores_SelectionChanged;
            btnEditar.Enabled = false;
            btnBorrar.Enabled = false;
        }

        private void dgvProfesores_SelectionChanged(object sender, EventArgs e)
        {
            bool rowSelected = dgvProfesores.SelectedRows.Count > 0;
            btnEditar.Enabled = rowSelected;
            btnBorrar.Enabled = rowSelected;
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
            dgvProfesores.ClearSelection();
            int idProfesor = Convert.ToInt32(dgvProfesores.CurrentRow.Cells["IdProfesor"].Value);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProfesores.CurrentRow != null)
            {
                int idProfesor = Convert.ToInt32(dgvProfesores.CurrentRow.Cells["IdProfesor"].Value);
                FrmDetalleProfesor fdp = new FrmDetalleProfesor(this, Modo.Editar, idProfesor);
                this.Hide();
                fdp.ShowDialog();
                CargarGridViewProfesores();
            }
            else
            {
                MessageBox.Show("Seleccioná un profesor primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvProfesores.Rows.Count == 0 || dgvProfesores.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un profesor primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cellValue = dgvProfesores.CurrentRow.Cells["IdProfesor"].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int id_profesor))
            {
                MessageBox.Show("No se pudo obtener el ID del profesor seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            CargarGridViewProfesores();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmInicio.Show();
        }
    }
}
