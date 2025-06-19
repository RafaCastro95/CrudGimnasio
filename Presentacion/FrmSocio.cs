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
            ComboBoxHelper.CargarCombo(cboCursos, oPServicio.TraerCursos(), "Nombre", "IdCurso", true);
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.MultiSelect = false;
            dgvSocios.CellClick += dgvSocios_CellClick;
        }

        private void dgvSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvSocios.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            string filtro = txtNombreSocio.Text;
            int valor = Convert.ToInt32(cboCursos.SelectedValue);
            List<Socio> lista = oPServicio.TraerSocios(filtro, valor);

            dgvSocios.Rows.Clear();

            foreach (Socio socio in lista)
            {
                string nombreCompleto = socio.Apellido + ", " + socio.Nombre;
                dgvSocios.Rows.Add(socio.IdSocio, nombreCompleto, socio.Documento, socio.FechaNacimiento.ToString("dd/MM/yyyy"), socio.Barrio.Descripcion);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow != null)
            {
                int id_socio = Convert.ToInt32(dgvSocios.CurrentRow.Cells["IdSocio"].Value);

                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro que querés eliminar este Socio?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    oPServicio.EliminarSocio(id_socio);
                    CargarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccioná un socio primero.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow != null)
            {
                //int id_socio = Convert.ToInt32(dgvSocios.CurrentRow.Cells["IdSocio"].Value); // Correctly retrieve the ID of the selected socio
                string documento = dgvSocios.CurrentRow.Cells["Documento"].Value.ToString(); // Convert the cell value to string

                FrmDetalleSocio fds = new FrmDetalleSocio(Modo.Editar, documento);
                fds.ShowDialog();
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccioná un socio primero.");
            }
            Console.WriteLine(dgvSocios.SelectedRows);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count > 0)
            {
                int id_socio = Convert.ToInt32(dgvSocios.SelectedRows[0].Cells["IdSocio"].Value);
                // Llama a un método que haga: UPDATE Socios SET Activo = 0 WHERE id_socio = @id_socio
                oPServicio.EliminarSocio(id_socio); // Modifica este método para hacer el update, no el delete
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
