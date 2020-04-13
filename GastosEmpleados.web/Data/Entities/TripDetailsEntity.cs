using GastosEmpleado.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GastosEmpleados.web.Data.Entities
{
    public class TripDetailsEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime DateLocal => DateLocal.ToLocalTime();


        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        public string Cantidad { get; set; }
        public string Descripcion { get; set; }

        public EmployeesEntity Viaje { get; set; }

        public TripsEntity Trips { get; set; }

        
    }

    
}
