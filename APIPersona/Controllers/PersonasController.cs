using app.domain.Entities;
using app.domain.VM;
using app.logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPersona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaLogic logic;
        public PersonasController(PersonaLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? filter)
        {
            var result = await logic.GetAsync(filter);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonaVM persona)
        {
            try
            {
                await logic.PostAsync(persona);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Persona persona)
        {
            try
            {
                await logic.PutAsync(persona);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await logic.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return Ok();
        }
    }
}
