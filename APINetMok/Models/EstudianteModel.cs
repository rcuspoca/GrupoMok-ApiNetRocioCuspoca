namespace APINetMok.Models
{
    public class EstudianteModel
    {
        public long IdEstudiante { get; set; }

        public int IdTipoIdentificacion { get; set; }

        public string TipoIdentificacion { get; set; }

        public string NumIdentificacion { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public bool Activo { get; set; }
    }
}
