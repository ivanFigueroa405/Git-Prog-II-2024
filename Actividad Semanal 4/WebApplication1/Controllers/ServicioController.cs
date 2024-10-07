using Microsoft.AspNetCore.Mvc;
using WebApiTurnos.Data.Models;
using WebApiTurnos.Data.Repositories;
using WebApiTurnos.Data.Service;


namespace WebApiTurnos.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ServicioController : Controller
    {
        private readonly IServicioService _service;
        public ServicioController(IServicioService service)
        {
                _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TServicio servicio)
        {
            return Ok(await _service.Create(servicio));
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromQuery]int id, [FromBody]TServicio servicio)
        {
            return Ok(await _service.Update(id, servicio));
        }
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpGet("IdServicio/{id}")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpGet("Servicios Activos/{active}")]
        public async Task<IActionResult> GetByActive(bool active)
        {
            return Ok(await _service.GetByActive(active));
        }
        [HttpGet("Nombre Servicio/{name}")]
        public async Task<IActionResult> GetName(string name)
        {
            return Ok(await _service.GetName(name));
        }

    }
}
