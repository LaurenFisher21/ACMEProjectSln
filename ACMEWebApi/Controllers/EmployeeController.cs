using ACMEWebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace ACMEWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IACMEDbRepository _acmeDbRepository;

        public EmployeeController(IACMEDbRepository acmeDbRepository)
        {
            _acmeDbRepository = acmeDbRepository;
        }

        #region CreateEmployee
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee == null || !ModelState.IsValid)
                {
                    return BadRequest("Sorry, employee not valid.");
                }

                bool doesThisEmployeeExist = _acmeDbRepository.DoesEmployeeExistById(employee.EmployeeId);

                if(doesThisEmployeeExist)
                {
                    return BadRequest("This employee already exists.");
                }
                _acmeDbRepository.CreateNewEmployee(employee);
            }
            catch(Exception ex)
            {
                return BadRequest("Employee craetion failed.");
            }
            return Ok(employee);
        }
        #endregion

        #region GetAllEmployees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _acmeDbRepository.GetAllEmployees();
        }
        #endregion

        #region GetEmployeeById
        [HttpGet("ById")]
        public Employee Get([FromQuery] int Id)
        {
            return _acmeDbRepository.GetEmployeeById(Id);
        }
        #endregion

        #region GetEmployeeByEmpNumber
        [HttpGet("Search")]
        public Employee Get([FromQuery] string empNum)
        {
            return _acmeDbRepository.GetEmployeeByEmpNum(empNum);
        }
        #endregion

        #region UpdateEmployee
        [HttpPut("ById")]
        public IActionResult UpdateEmployeeById([FromQuery] Employee employee)
        {
            try
            {
                bool doesEmployeeExist = _acmeDbRepository.DoesEmployeeExistById(employee.EmployeeId);
                if(!doesEmployeeExist)
                {
                    return BadRequest("This employee does not exist.");
                }
                _acmeDbRepository.UpdateEmployee(employee);
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong...");
            }
            return Ok(employee);
        }
        #endregion

        #region DeleteEmployee
        [HttpDelete("ById")]
        public Employee Delete([FromQuery]int Id)
        {
            var deleteEmployee = _acmeDbRepository.GetEmployeeById(Id);
            return _acmeDbRepository.DeleteEmployee(deleteEmployee);
        }
        #endregion
    }
}
