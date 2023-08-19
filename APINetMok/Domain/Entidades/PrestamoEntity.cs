using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINetMok.Dominio.Entidades
{
    [Table("Prestamo")]
    public class PrestamoEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdPrestamo")]
        public long IdPrestamo { get; set; }

        [Column("IdLibro")]
        public long IdLibro { get; set; }

        [Column("IdEstudiante")]
        public long IdEstudiante { get; set; }

        [Column("FechaPrestamo")]
        public DateTime FechaPrestamo { get; set; }

        [Column("FechaDevolucion")]
        public DateTime FechaDevolucion { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }        

        [ForeignKey("IdLibro")]
        public LibroEntity Libro { get; set; }

        [ForeignKey("IdEstudiante")]
        public EstudianteEntity Estudiante { get; set; }
    }
}
