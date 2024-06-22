using AutoCheckIn.App.Dto;
using AutoCheckIn.App;
using Microsoft.AspNetCore.Mvc;

namespace AutoCheckIn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService service = new PacienteService();

        [HttpPost]
        public async Task<IActionResult> CadastrarPaciente(PacienteDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            service.Criar(dto);

            return Created($"/{dto.Id}", dto);
        }
    }
}
