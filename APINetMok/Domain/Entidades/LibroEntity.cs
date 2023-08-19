using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINetMok.Dominio.Entidades
{

    [Table("Libro")]
    public class LibroEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("IdLibro")]
        public long IdLibro { get; set; }

        [Column("Codigo")]
        public string Codigo { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Editorial")]
        public string Editorial { get; set; }

        [Column("Autor")]
        public string Autor { get; set; }

        [Column("Precio")]
        public decimal Precio { get; set; }

        [Column("Ubicacion")]
        public string Ubicacion { get; set; }

        [Column("Activo")]
        public bool Activo { get; set; }

    }
}
