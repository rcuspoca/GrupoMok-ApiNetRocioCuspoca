﻿using System.ComponentModel.DataAnnotations.Schema;

namespace APINetMok.Models
{
    public class TipoIdentificacionModel
    {
        public int IdTipoIdentificacion { get; set; }

        public string Abreviatura { get; set; }
       
        public string Descripcion { get; set; }
       
        public bool Activo { get; set; }
    }
}
