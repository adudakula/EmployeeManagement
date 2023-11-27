using Microsoft.AspNetCore.Mvc;
using WebApiEF.Context;
using WebApiEF.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private CompanyContext _companyContext;

        public EmployeeController(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    var entity = _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
                    return Ok(entity);
                }
                return Ok(_companyContext.Employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in server. see details" + ex.Message);
            }

        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
                if (entity == null)
                {
                    return NotFound("Summary Not Found");
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in server. see details" + ex.Message);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee value)
        {
            try
            {
                _companyContext.Employees.Add(value);
                _companyContext.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in server. see details" + ex.Message);
            }

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee value)
        {
            try
            {
                var employee = _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);

                if (employee != null)
                {
                    _companyContext.Entry<Employee>(employee).CurrentValues.SetValues(value);
                    _companyContext.SaveChanges();
                    return Ok(employee);
                }
                else
                {
                    return NotFound("No Employee Found with ID = " + id.ToString());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in server. see details" + ex.Message);
            }


        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var student = _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);

                if (student != null)
                {

                    _companyContext.Employees.Remove(student);
                    _companyContext.SaveChanges();
                    return StatusCode(204, "Deleted Successfully");
                }
                else
                {
                    return NotFound("No Employee Found with ID = " + id.ToString());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong in server. see details" + ex.Message);
            }

        }
    }
}