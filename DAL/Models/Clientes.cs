namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            Carrito = new HashSet<Carrito>();
            HistorialAlquiler = new HashSet<HistorialAlquiler>();
            Notificaciones = new HashSet<Notificaciones>();
        }

        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(55)]
        public string NombreCliente { get; set; }

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

        [StringLength(20)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carrito> Carrito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialAlquiler> HistorialAlquiler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notificaciones> Notificaciones { get; set; }
    }
}
