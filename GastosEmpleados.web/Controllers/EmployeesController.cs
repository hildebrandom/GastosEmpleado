
using GastosEmpleados.web.Data;
using GastosEmpleados.web.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GastosEmpleados.web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeesEntity employeesEntity = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeesEntity == null)
            {
                return NotFound();
            }

            return View(employeesEntity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeesEntity employeesEntity)
        {
            if (ModelState.IsValid)
            {

                _context.Add(employeesEntity);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))

                    {

                        ModelState.AddModelError(string.Empty, "Already exists a Viaje  with the same Documento.");
                    }

                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(employeesEntity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                return NotFound();
            }


            EmployeesEntity employeesEntity = await _context.Employees.FindAsync(id);
            if (employeesEntity == null)
            {
                return NotFound();
            }
            return View(employeesEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeesEntity employeesEntity)
        {
            if (id != employeesEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(employeesEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already exists a Viaje with the same Documento.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(employeesEntity);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeesEntity employeesEntity = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeesEntity == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employeesEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
