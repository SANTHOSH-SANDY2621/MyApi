using MyApi.BussinessLogic.IBussinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employer : ControllerBase
    {
        private readonly IEmployerBussinessLogic _employerBussinessLogic;

        public Employer(IEmployerBussinessLogic employerBussinessLogic)
        {
            _employerBussinessLogic = employerBussinessLogic;
        }
        [HttpGet("employers")]
        public async Task<IActionResult> GetEmployers()
        {
            return Ok(await _employerBussinessLogic.GetEmployers());
        }
    }
}
