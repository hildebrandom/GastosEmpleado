using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GastosEmpleados.web.Data.Entities
{
    public class TripsEntity
    {

        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime? EndDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime? EndDateLocal => EndDate?.ToLocalTime();

        [MaxLength(100, ErrorMessage = "The {0} field must have {1} characters.")]
        public string Source { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field must have {1} characters.")]
        public string Target { get; set; }

        public string TotalAmount { get; set; }


        public TripDetailsEntity Trips { get; set; }


        public ICollection<TripsEntity> TripDetails { get; set; }
        public UserEntity User { get; set; }
        public EmployeesEntity Employees { get; set; }
    }
}
