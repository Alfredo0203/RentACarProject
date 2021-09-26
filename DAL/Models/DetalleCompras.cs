namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DetalleCompras
    {
        [Key]
        public int IdDetalleCompra { get; set; }

        [Required]
        [StringLength(10)]
        public string Marca { get; set; }

        [Required]
        [StringLength(10)]
        public string Modelo { get; set; }

        public double PrecioUnitario { get; set; }

        public int FkCompra { get; set; }

        public virtual Compras Compras { get; set; }
    }
}
