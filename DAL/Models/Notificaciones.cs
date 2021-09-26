namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notificaciones
    {
        [Key]
        public int IdNotificacion { get; set; }

        public int FkCliente { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
