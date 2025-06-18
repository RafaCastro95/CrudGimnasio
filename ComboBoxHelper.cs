using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo06_TP_Programacion1
{
    public static class ComboBoxHelper
    {

        public static void CargarCombo<T>(ComboBox combo, List<T> listaTipos, string displayMember, string valueMember)
        {
            combo.DataSource = listaTipos;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.DropDownStyle = ComboBoxStyle.DropDownList; 
            combo.SelectedIndex = -1; 
        }
    }
}
