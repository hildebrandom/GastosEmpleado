using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GastosEmpleados.web.Data.Entities
{
    public class ExpenseTypeEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Tipo de Gasto")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string TipoGasto { get; set; }
                       
        public ICollection<ExpenseTypeEntity> Trips { get; set; }


    }
}
