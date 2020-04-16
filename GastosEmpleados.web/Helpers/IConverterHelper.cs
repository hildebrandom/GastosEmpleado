using GastosEmpleado.Common.Models;
using GastosEmpleados.web.Data.Entities;
using System.Collections.Generic;

namespace GastosEmpleados.web.Helpers
{
    public interface IConverterHelper
    {
        EmployeesResponse ToEmployeesResponse(EmployeesEntity employeesEntity);
    }
}

