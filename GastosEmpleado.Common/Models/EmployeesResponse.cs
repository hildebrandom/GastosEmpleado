using System;
using System.Collections.Generic;
using System.Text;

namespace GastosEmpleado.Common.Models
{
    public class EmployeesResponse
    {
        public int Id { get; set; }

        public string Document { get; set; }

        public List<TripResponse> Trips { get; set; }

        public UserResponse User { get; set; }

                
    }
}

