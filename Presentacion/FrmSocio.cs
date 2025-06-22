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
        private FrmInicio _frmInicio;
        PersonaServicio oPersonaServicio;
        SocioServicio oSServicio;
        public FrmSocio()
        {
            InitializeComponent();
            oSServicio = new SocioServicio();
            oPersonaServicio = new PersonaServicio();
        }
        public FrmSocio(FrmInicio frmInicio)
        {
            InitializeComponent();
            _frmInicio = frmInicio;
            oSServicio = new SocioServicio();
            oPersonaServicio = new PersonaServicio();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleSocio fds = new FrmDetalleSocio(this);
            this.Hide();
            fds.ShowDialog();
        }
        private void FrmSocio_Load(object sender, EventArgs e)
        {
            dgvSocios.RowHeadersVisible = false;
            ComboBoxHelper.CargarCombo(cboCursos, oPersonaServicio.TraerCursos(), "Nombre", "IdCurso", true);
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.MultiSelect = false;
            dgvSocios.CellClick += dgvSocios_CellClick;
            dgvSocios.SelectionChanged += dgvSocios_SelectionChanged;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void dgvSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvSocios.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvSocios_SelectionChanged(object sender, EventArgs e)
        {
            bool rowSelected = dgvSocios.SelectedRows.Count > 0;
            btnEditar.Enabled = rowSelected;
            btnEliminar.Enabled = rowSelected;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            string filtro = txtNombreSocio.Text;
            int valor = Convert.ToInt32(cboCursos.SelectedValue);
            List<Socio> lista = oSServicio.TraerSocios(filtro, valor);

            dgvSocios.Rows.Clear();

            foreach (Socio socio in lista)
            {
                string nombreCompleto = socio.Apellido + ", " + socio.Nombre;
                dgvSocios.Rows.Add(socio.IdSocio, nombreCompleto, socio.Documento, socio.FechaNacimiento.ToString("dd/MM/yyyy"), socio.Barrio.Descripcion);
            }
            dgvSocios.ClearSelection();
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
                    oSServicio.EliminarSocio(id_socio);
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
               
                string documento = dgvSocios.CurrentRow.Cells["Documento"].Value.ToString(); 

                FrmDetalleSocio fds = new FrmDetalleSocio(this, Modo.Editar, documento);
                this.Hide();
                fds.ShowDialog();
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccioná un socio primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Console.WriteLine(dgvSocios.SelectedRows);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.Rows.Count == 0 || dgvSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un socio primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cellValue = dgvSocios.SelectedRows[0].Cells["IdSocio"].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int id_socio))
            {
                MessageBox.Show("No se pudo obtener el ID del socio seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que querés eliminar este Socio?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                oSServicio.EliminarSocio(id_socio);
                CargarGrilla();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmInicio.Show();
        }
    }
}
