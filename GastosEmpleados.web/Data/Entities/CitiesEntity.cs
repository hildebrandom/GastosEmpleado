using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GastosEmpleados.web.Data.Entities
{
    public class CitiesEntity
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        public CountriesEntity Countries { get; set; }

        public ICollection<CitiesEntity> Trips { get; set; }

        
    }
}
