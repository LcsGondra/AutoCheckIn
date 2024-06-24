using AutoCheckIn.App.Dto;
using AutoCheckIn.App;
using Microsoft.AspNetCore.Mvc;

namespace AutoCheckIn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalService service = new HospitalService();


        [HttpGet("All")]
        public IActionResult GetHospitais()
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return Ok(service.GetHospitais());                        
        }
    }
}
