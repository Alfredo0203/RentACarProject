namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Carrito")]
    public partial class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }

        public int FkCliente { get; set; }

        public int FkAuto { get; set; }

        public int CantidadDias { get; set; }

        public double PrecioTotal { get; set; }

        public virtual Autos Autos { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
