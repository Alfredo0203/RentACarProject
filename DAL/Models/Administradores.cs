namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Administradores
    {
        [Key]
        public int IdAdministrador { get; set; }

        [Required]
        [StringLength(55)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(55)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(55)]
        public string Correo { get; set; }

        [Required]
        [StringLength(55)]
        public string Contra { get; set; }

        public int Edad { get; set; }

        public int Telefono { get; set; }

        public int Rol { get; set; }
    }
}
