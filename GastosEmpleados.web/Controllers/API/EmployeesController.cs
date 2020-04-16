using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastosEmpleados.web.Data;
using GastosEmpleados.web.Data.Entities;
using GastosEmpleados.web.Helpers;

namespace GastosEmpleados.web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public EmployeesController(
            DataContext context,
           IConverterHelper converterHelper )
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        
        // GET: api/Employees/5
        [HttpGet("{Document}")]
        public async Task<IActionResult> GetEmployeesEntity([FromRoute] string document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmployeesEntity employeesEntity = await _context.Employees
                .Include(t => t.User)
                .Include(t => t.Trips)
                .ThenInclude(t => t.TripDetails)
                .Include(t => t.Trips)
                .ThenInclude(t => t.User)
                .FirstOrDefaultAsync(t => t.Document == document);


            if (employeesEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHelper.ToEmployeesResponse(employeesEntity));

        }
    }
}