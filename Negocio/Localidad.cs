namespace Grupo06_TP_Programacion1.Negocio
{
    public class Localidad
    {
        // Atributos
        private int idLocalidad;
        private string descripcion;
        private Provincia idProvincia;

        // Properties
        public int IdLocalidad
        {
            get { return idLocalidad; }
            set { idLocalidad = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public Provincia IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }
    }
}