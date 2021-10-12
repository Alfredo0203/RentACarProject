namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Administradores
    {
        [Key]
        public int IdAdministrador { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(55)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(55)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(55)]
        [EmailAddress(ErrorMessage = "No es una direccion de correo Electronico")]

        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(55)]
        public string Contra { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [Range(17, int.MaxValue, ErrorMessage = "Cantidad no válida")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-8]{2})\)?[-.]?([0-8]{2})[-.]?[-.]?([0-8]{4})$", ErrorMessage = "Error el numero debe tener 8 digitos")]
        public int Telefono { get; set; }


        public Roles Rol { get; set; }
    }
}
