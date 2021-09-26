namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compras()
        {
            DetalleCompras = new HashSet<DetalleCompras>();
        }

        [Key]
        public int IdCompra { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public int FkProveedor { get; set; }

        public double Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompras> DetalleCompras { get; set; }

        public virtual Proveedores Proveedores { get; set; }
    }
}
