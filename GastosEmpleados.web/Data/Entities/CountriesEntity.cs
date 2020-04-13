using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GastosEmpleados.web.Data.Entities
{
    public class CountriesEntity
    {
        public int Id { get; set; }

        [Display(Name = "Pais")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        public ICollection<CountriesEntity> Cities { get; set; }

    }
}
