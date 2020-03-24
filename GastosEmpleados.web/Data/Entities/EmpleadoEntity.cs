using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GastosEmpleados.web.Data.Entities
{
    public class EmpleadoEntity
    {
        public int  Id { get; set; }

        [StringLength(25, MinimumLength = 6, ErrorMessage = "The {0} field must have {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Nombre { get; set; }

    }
}
