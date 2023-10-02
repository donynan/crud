using crud.Dbcontext;
using crud.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpolyeeController : ControllerBase
    {
        private readonly EmployeeDbcontext _employeeDbcontext;
        public EmpolyeeController(EmployeeDbcontext employeeDbcontext)
        {
            this._employeeDbcontext = employeeDbcontext;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> get()
        {

            var Employees = await _employeeDbcontext.Employee.ToListAsync();

            if (Employees != null )
            {
                return Ok(Employees);
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] employee emp)
        {
            //if (emp == null)
            //{
            //    return BadRequest(new { message = "Invalid data" });
            //}

            emp.Id = new Guid();
            //var Result = await _employeeDbcontext.Employee.AsQueryable().Where(x => x.Email == Employees.Email).AnyAsync();
            //if (Result)
            //{
            //    return Conflict("Email Already Exist");
            //}

           
            
                await _employeeDbcontext.Employee.AddAsync(emp);
                await _employeeDbcontext.SaveChangesAsync();

                return Ok( emp );
            

           
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] employee emp)
        {
            if (emp.Id != id)
            {
                return BadRequest();
            }

            var Employees = await _employeeDbcontext.Employee.FirstOrDefaultAsync(a => a.Id == id);



            if (Employees == null)
            {
                return NotFound();
            }


            Employees.FirstName = emp.FirstName;
            Employees.LastName = emp.LastName;
            Employees.Email = emp.Email;
            Employees.Username = emp.Username;
            Employees.PhoneNumber = emp.PhoneNumber;

            await _employeeDbcontext.SaveChangesAsync();
            return Ok(emp);
        }



        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {


            var Employees = await _employeeDbcontext.Employee.FirstOrDefaultAsync(a => a.Id == id);


            if (Employees != null)
            {
                _employeeDbcontext.Employee.Remove(Employees);
                await _employeeDbcontext.SaveChangesAsync();

                return Ok(Employees);
            }

            return NotFound("Employee Not Found");

        }
    }
}
