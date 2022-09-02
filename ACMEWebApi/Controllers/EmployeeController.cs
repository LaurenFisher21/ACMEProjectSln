using ACMEWebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
