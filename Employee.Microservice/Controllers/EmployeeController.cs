using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Microservice.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IApplicationDbContext _context;
        public EmployeeController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChanges();
            return Ok(employee.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            if (employees == null) return NotFound();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Employees.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Employees.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            _context.Employees.Remove(customer);
            await _context.SaveChanges();
            return Ok(customer.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Employee employee)
        {
            var customer = _context.Employees.Where(a => a.Id == id).FirstOrDefault();

            if (customer == null) return NotFound();
            else
            {
                customer.City = employee.City;
                customer.Name = employee.Name;
                customer.Contact = employee.Contact;
                customer.Email = employee.Email;
                await _context.SaveChanges();
                return Ok(customer.Id);
            }
        }
    }
}