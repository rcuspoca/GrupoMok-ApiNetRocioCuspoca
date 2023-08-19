using APINetMok.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINetMok.Models
{
    public class PrestamoModel
    {
        public long IdPrestamo { get; set; }

        public long IdLibro { get; set; }

        public long IdEstudiante { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaDevolucion { get; set; }    
    }
}
