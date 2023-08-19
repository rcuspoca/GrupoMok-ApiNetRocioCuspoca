﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINetMok.Dominio.Entidades
{
    [Table("TipoIdentificacion")]
    public class TipoIdentificacionEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("IdTipoIdentificacion")]
        public int IdTipo { get; set; }

        [Column("Abreviatura")]
        public string Abreviatura { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("Activo")]
        public int EstadoTipo { get; set; }

    }
}
