using ACMEWebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace ACMEWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IACMEDbRepository _acmeDbRepository;

        public PersonController(IACMEDbRepository acmeDbRepository)
        {
            _acmeDbRepository = acmeDbRepository;
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            try
            {
                if(person == null || !ModelState.IsValid)
                {
                    return BadRequest("Sorry, person not valid.");
                }

                bool doesThisPersonExist = _acmeDbRepository.DoesPersonExistById(person.PersonId);

                if(doesThisPersonExist)
                {
                    return BadRequest("This person already exists.");
                }
                _acmeDbRepository.CreateNewPerson(person);
            }
            catch(Exception ex)
            {
                return BadRequest("Person creation failed.");
            }
            return Ok(person);
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _acmeDbRepository.GetAllPeople();
        }

        [HttpGet("byid")]
        public Person Get([FromQuery] int Id)
        {
            return _acmeDbRepository.GetPersonById(Id);
        }

        [HttpGet("search")]
        public Person Get([FromQuery] string lastname)
        {
            return _acmeDbRepository.GetPersonByLastName(lastname);
        }

        [HttpPut("byid")]
        public IActionResult UpdatePersonById([FromQuery] Person person)
        {
            try
            {
                bool doesThisPersonExist = _acmeDbRepository.DoesPersonExistById(person.PersonId);
                if(!doesThisPersonExist)
                {
                    return BadRequest("This person does not exist");
                }
                _acmeDbRepository.UpdatePerson(person);
            }
            catch(Exception ex)
            {
                return BadRequest("Something Happened...");
            }
            return Ok(person);
        }
    }
}
