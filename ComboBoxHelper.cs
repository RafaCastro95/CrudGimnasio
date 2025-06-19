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

        public static void CargarCombo<T>(ComboBox combo, List<T> listaTipos, string displayMember, string valueMember, bool incluirVacio )
        {
            if (incluirVacio)
            {
                T itemVacio = Activator.CreateInstance<T>();

                // Seteamos las propiedades por reflexión
                var propDisplay = typeof(T).GetProperty(displayMember);
                var propValue = typeof(T).GetProperty(valueMember);

                if (propDisplay != null)
                    propDisplay.SetValue(itemVacio, "Seleccione...");

                if (propValue != null && propValue.PropertyType == typeof(int)) // Suponiendo que el ID es int
                    propValue.SetValue(itemVacio, 0);

                listaTipos.Insert(0, itemVacio);
            }


            combo.DataSource = listaTipos;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.DropDownStyle = ComboBoxStyle.DropDownList; 
            combo.SelectedIndex = 0; 
        }
    }
}
