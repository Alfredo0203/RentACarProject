namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedores()
        {
            Compras = new HashSet<Compras>();
        }

        [Key]
        public int IdProveedor { get; set; }


        [Required]
        [StringLength(55)]
        public string NombreProveedor { get; set; }


        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([6,7]{1})\)?[-.]?([0-9]{3})[-.]?[-.]?([0-9]{4})$", ErrorMessage = "El número debe tener 8 dígitos e iniciar con 7 ó 6")]
        public int telefono { get; set; }


        [Required]
        [StringLength(55)]
        public string direccion { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compras> Compras { get; set; }
    }
}
