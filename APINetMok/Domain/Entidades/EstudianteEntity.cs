using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APINetMok.Dominio.Entidades
{

    [Table("Estudiante")]
    public class EstudianteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("IdEstudiante")]
        public long IdEstudiante { get; set; }

        [Column("IdTipoIdentificacion")]
        public int IdTipoIdentificacion { get; set; }

        [Column("NumIdentificacion")]
        public string NumIdentificacion { get; set; }

        [Column("Nombres")]
        public string Nombres { get; set; }

        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [Column("Direccion")]
        public string Direccion { get; set; }

        [Column("Telefono")]
        public string Telefono { get; set; }

        [Column("Activo")]
        public bool Activo { get; set; }

        [ForeignKey("IdTipoIdentificacion")]
        public TipoIdentificacionEntity TipoIdentificacion { get; set; }
    }
}

