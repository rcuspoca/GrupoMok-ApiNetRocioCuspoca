using System.ComponentModel.DataAnnotations.Schema;

namespace APINetMok.Models
{
    public class LibroModel
    {
        public long IdLibro { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Editorial { get; set; }

        public string Autor { get; set; }

        public decimal Precio { get; set; }

        public string Ubicacion { get; set; }

        public bool Activo { get; set; }
    }
}