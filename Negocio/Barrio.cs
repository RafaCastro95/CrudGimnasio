namespace Grupo06_TP_Programacion1.Negocio
{
    public class Barrio
    {
        // Atributos
        private int idBarrio;
        private string descripcion;
        private Localidad idLocalidad;

        // Properties
        public int IdBarrio
        {
            get { return idBarrio; }
            set { idBarrio = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public Localidad IdLocalidad
        {
            get { return idLocalidad; }
            set { idLocalidad = value; }
        }
    }
}