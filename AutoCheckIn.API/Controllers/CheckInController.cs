using AutoCheckIn.App;
using AutoCheckIn.App.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AutoCheckIn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly CheckInService service = new CheckInService();

        [HttpPost]
        public async Task<IActionResult> ReazilarCheckIn(CheckInDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            await service.FazerCheckIn(dto);

            return Created($"/{dto.Id}", dto);
        }
    }
}
