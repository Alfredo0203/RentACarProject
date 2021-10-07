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

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(55)]
        public string NombreCliente { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(55)]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [EmailAddress(ErrorMessage ="No es una direccion de correo Electronico")]
        [StringLength(55)]
        public string Correo { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(55)]
        public string Contra { get; set; }

        [NotMapped]
        [Compare("Contra")]
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(55)]
        public string ConfirmarPass { get; set; }

        [Range(17, int.MaxValue, ErrorMessage = "Cantidad no válida")]
        [Required(ErrorMessage = "El campo no puede estar vacio")] public int Edad { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-8]{2})\)?[-.]?([0-8]{2})[-.]?[-.]?([0-8]{4})$", ErrorMessage = "Error el numero debe tener 8 digitos")] 
        public int Telefono { get; set; }

        public Roles Rol { get; set; }

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
