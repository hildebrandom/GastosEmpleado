﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GastosEmpleados.web.Data.Entities
{
    public class EmployeesEntity
    {
        public int Id { get; set; }


        [Display(Name = "Document")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "The {0} field must have {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Document { get; set; }


        public ICollection<TripsEntity> Trips { get; set; }

        public UserEntity User { get; set; }


    }
}
