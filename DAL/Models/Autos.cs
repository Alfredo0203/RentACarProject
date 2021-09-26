namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Autos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autos()
        {
            Carrito = new HashSet<Carrito>();
            HistorialAlquiler = new HashSet<HistorialAlquiler>();
        }

        [Key]
        public int IdAuto { get; set; }

        public int FkMarca { get; set; }

        public int FKModelo { get; set; }

        [Required]
        [StringLength(8)]
        public string Placa { get; set; }

        [Required]
        [StringLength(10)]
        public string Color { get; set; }

        public double? PrecioDia { get; set; }

        [Required]
        [StringLength(15)]
        public string Categoria { get; set; }

        public int? Pasajeros { get; set; }

        public int? NumeroPuertas { get; set; }

        [StringLength(50)]
        public string Imagen { get; set; }

        [StringLength(50)]
        public string Gif { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carrito> Carrito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialAlquiler> HistorialAlquiler { get; set; }

        public virtual Marcas Marcas { get; set; }

        public virtual Modelos Modelos { get; set; }
    }
}
