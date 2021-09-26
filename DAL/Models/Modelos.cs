namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Modelos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modelos()
        {
            Autos = new HashSet<Autos>();
        }

        [Key]
        public int IdModelo { get; set; }

        public int FkMarca { get; set; }

        [Required]
        [StringLength(55)]
        public string NombreModelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autos> Autos { get; set; }

        public virtual Marcas Marcas { get; set; }
    }
}
