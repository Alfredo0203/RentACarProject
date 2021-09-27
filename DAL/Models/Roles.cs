using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public enum Roles
    {
        [Description("Administrador")]
        admin = 1,
        [Description("Cliente")]
        cliente = 2
    }
}
