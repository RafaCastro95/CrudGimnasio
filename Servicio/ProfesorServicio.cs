using Grupo06_TP_Programacion1.Dao;
using Grupo06_TP_Programacion1.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo06_TP_Programacion1.Servicio
{
    public class ProfesorServicio
    {
        PersonaDao oDao;

        public ProfesorServicio()
        {
            oDao = new PersonaDao();
        }



        public List<TipoDocumento> RecuperarTiposDocumentos()
        {
            return oDao.RecuperarTiposDocumentos();
        }

        public List<Genero> RecuperarGeneros()
        {
            return oDao.RecuperarGeneros();
        }



        // Cargar combo generico para usarlo en cualquier formulario
        public void CargarCombo<T>(ComboBox combo, List<T> listaTipos, string displayMember, string valueMember )
        {
            combo.DataSource = listaTipos;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.DropDownStyle = ComboBoxStyle.DropDownList; // Para que no se pueda escribir en el combo
            combo.SelectedIndex = -1; // Para que no seleccione un valor por defecto
        }
    }
}
