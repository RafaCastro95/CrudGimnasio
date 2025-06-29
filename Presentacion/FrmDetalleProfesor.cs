﻿using Grupo06_TP_Programacion1.Datos;
using Grupo06_TP_Programacion1.Negocio;
using Grupo06_TP_Programacion1.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo06_TP_Programacion1.Presentacion
{
    public enum Modo
    {
        Nuevo,
        Ver,
        Editar,
        Eliminar
    }
    public partial class FrmDetalleProfesor : Form
    {
        private FrmProfesor _frmProfesor;
        PersonaServicio oPersonaServicio;
        ProfesorServicio oPServicio;
        int idProfesor;
        Modo accion;
        AccesoDatos AccesoDatos = new AccesoDatos();
        Profesor profesor = new Profesor();
        public FrmDetalleProfesor(FrmProfesor frmProfesor ,Modo accion)
        {
            InitializeComponent();
            oPServicio = new ProfesorServicio();
            oPersonaServicio = new PersonaServicio();
            this.accion = accion;
            _frmProfesor = frmProfesor;
        }
        public FrmDetalleProfesor(FrmProfesor frmProfesor, Modo accion, int idProfesor)
        {
            InitializeComponent();
            this.accion = accion;
            this.idProfesor = idProfesor;
            oPServicio = new ProfesorServicio();
            oPersonaServicio = new PersonaServicio();
            txtDocumento.Enabled = false;
            _frmProfesor = frmProfesor;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmProfesor.Show();
        }

        private void FrmDetalleProfesor_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.CargarCombo(cboTipoDocumento, oPersonaServicio.TraerTiposDocumentos(), "Descripcion", "IdTipo", false);
            ComboBoxHelper.CargarCombo(cboGenero, oPersonaServicio.TraerGeneros(), "Descripcion", "IdGenero", false);
            ComboBoxHelper.CargarCombo(cboProvincia, oPersonaServicio.TraerProvincias(), "Descripcion", "IdProvincia", true);
            if (accion != Modo.Nuevo)
            {
                CargarProfesor(idProfesor);
            }
        }
        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex != -1 && cboProvincia.SelectedValue != null)
            {
                if (int.TryParse(cboProvincia.SelectedValue.ToString(), out int idProvincia))
                {
                    ComboBoxHelper.CargarCombo(cboLocalidad, oPersonaServicio.TraerLocalidades(idProvincia), "Descripcion", "IdLocalidad", true);
                }
            }
        }

        private void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex != -1 && cboProvincia.SelectedValue != null)
            {
                if (cboLocalidad.SelectedIndex != -1 && cboLocalidad.SelectedValue != null)
                {
                    if (int.TryParse(cboLocalidad.SelectedValue.ToString(), out int idLocalidad))
                    {
                        ComboBoxHelper.CargarCombo(cboBarrio, oPersonaServicio.TraerBarrios(idLocalidad), "Descripcion", "IdBarrio", true);
                    }
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (ValidarDatos())
            {
                if (accion == Modo.Nuevo)
                {
                    GuardarProfesor();
                }
                else if (accion == Modo.Editar)
                {
                    EditarProfesor(idProfesor);
                }
            }
        }

        private bool ValidarDatos()
        {
            if (!int.TryParse(txtDocumento.Text, out _))
            {
                MessageBox.Show("Complete con numero el campo Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDocumento.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Complete con letras el campo Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Complete con letras el campo Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               txtNombre.Focus();
                return false;
            }
            if (cboTipoDocumento.SelectedItem == null)
            {
                MessageBox.Show("Complete con una opcion el campo Tipo Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipoDocumento.Focus();
                return false;
            }
            if (cboProvincia.SelectedIndex <= 0)
            {
                MessageBox.Show("Complete con una opción el campo Provincia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboProvincia.Focus();
                return false;
            }
            if (cboLocalidad.SelectedIndex <= 0)
            {
                MessageBox.Show("Complete con una opción el campo Localidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLocalidad.Focus();
                return false;
            }
            if (cboBarrio.SelectedIndex <= 0)
            {
                MessageBox.Show("Complete con una opción el campo Barrio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBarrio.Focus();
                return false;
            }
            return true;
        }

        private void GuardarProfesor()
        {
            //Guardar los datos del profesor
            Profesor oProfesor = new Profesor();
            oProfesor.Nombre = txtNombre.Text;
            oProfesor.Apellido = txtApellido.Text;
            oProfesor.Documento = txtDocumento.Text;
            oProfesor.FechaNacimiento = dtpFechaNacimiento.Value;
            oProfesor.Telefono = txtTelefono.Text;
            oProfesor.Email = txtEmail.Text;
            oProfesor.Tipo = (TipoDocumento)cboTipoDocumento.SelectedItem;
            oProfesor.Genero = (Genero)cboGenero.SelectedItem;
            if (cboBarrio.SelectedIndex != -1 && cboBarrio.SelectedValue != null)
            {
                oProfesor.Barrio = (Barrio)cboBarrio.SelectedItem;
            }

            if (oPServicio.GuardarProfesor(oProfesor) > 0)
            {
                MessageBox.Show("Profesor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                _frmProfesor.Show();
            }
            else
            {
                MessageBox.Show("Error al guardar el profesor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void EditarProfesor(int idProfesor)
        {
            int resultado = 0;
            Profesor profesor = new Profesor();
            profesor.IdProfesor = idProfesor;
            profesor.Nombre = txtNombre.Text;
            profesor.Apellido = txtApellido.Text;
            profesor.FechaNacimiento = dtpFechaNacimiento.Value;
            profesor.Telefono = txtTelefono.Text;
            profesor.Email = txtEmail.Text;
            profesor.Tipo = (TipoDocumento)cboTipoDocumento.SelectedItem;
            profesor.Genero = (Genero)cboGenero.SelectedItem;
            profesor.Barrio = (Barrio)cboBarrio.SelectedItem;

            resultado = oPServicio.ActualizarProfesor(idProfesor, profesor);
            if (resultado == 0)
            {
                MessageBox.Show("Error al actualizar el profesor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Profesor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                _frmProfesor.Show();
            }
        }

        private void CargarProfesor(int idProfesor)
        {
            int pk_Provincias = 0;
            int pk_Localidades = 0;

            DataTable dt = oPServicio.RecuperarProfesor(idProfesor);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                profesor.IdProfesor = Convert.ToInt32(row[0]);
                profesor.Nombre = row[1].ToString();
                profesor.Apellido = row[2].ToString();
                profesor.Documento = row[3].ToString();
                profesor.FechaNacimiento = Convert.ToDateTime(row[4]);
                profesor.Telefono = row[5].ToString();
                profesor.Email = row[6].ToString();
                profesor.Genero = new Genero
                {
                    IdGenero = Convert.ToInt32(row[7])
                };
                profesor.Tipo = new TipoDocumento
                {
                    IdTipo = Convert.ToInt32(row[8])
                };
                profesor.Barrio = new Barrio
                {
                    IdBarrio = Convert.ToInt32(row[9])
                };
                profesor.Activo = Convert.ToInt32(row[10]);
                pk_Provincias = Convert.ToInt32(row[11]);
                pk_Localidades = Convert.ToInt32(row[12]);
            }
            // Cargar los datos en los controles del formulario
            txtNombre.Text = profesor.Nombre;
            txtApellido.Text = profesor.Apellido;
            txtDocumento.Text = profesor.Documento;
            dtpFechaNacimiento.Value = profesor.FechaNacimiento;
            txtTelefono.Text = profesor.Telefono;
            txtEmail.Text = profesor.Email;
            cboTipoDocumento.SelectedValue = profesor.Tipo.IdTipo;
            cboGenero.SelectedValue = profesor.Genero.IdGenero;
            cboProvincia.SelectedValue = pk_Provincias;
            cboLocalidad.SelectedValue = pk_Localidades;
            cboBarrio.SelectedValue = profesor.Barrio.IdBarrio;
            cboGenero.SelectedValue = profesor.Genero.IdGenero;
        }

    }
}
