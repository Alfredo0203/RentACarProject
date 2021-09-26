namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistorialAlquiler")]
    public partial class HistorialAlquiler
    {
        [Key]
        public int IdHistorial { get; set; }

        public int FkCliente { get; set; }

        public int FkAuto { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaEntrega { get; set; }

        public int CantidadDias { get; set; }

        public bool? Averiado { get; set; }

        public double? PrecioTotal { get; set; }

        public virtual Autos Autos { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
