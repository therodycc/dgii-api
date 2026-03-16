using Microsoft.AspNetCore.Mvc;
using dgii_api.Services;

namespace dgii_api.Controllers
{
    [Route("api/contribuyentes")]
    [ApiController]
    public class ContribuyentesController : ControllerBase
    {
        private readonly IContribuyenteService _service;

        public ContribuyentesController(IContribuyenteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContribuyenteResponseDto>> GetContribuyentes()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ContribuyenteResponseDto> GetContribuyente(int id)
        {
            var result = _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContribuyente([FromBody] ContribuyenteCreateDto dto)
        {
            var result = _service.Create(dto);

            if (!result)
                return BadRequest(new { message = "Contribuyente already exists" });

            return Created("", new { message = "Successfully created" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContribuyente(int id, [FromBody] ContribuyenteUpdateDto dto)
        {
            var result = _service.Update(id, dto);

            if (!result)
                return NotFound(new { message = "Contribuyente not found" });

            return Ok(new { message = "Successfully updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContribuyente(int id)
        {
            var result = _service.Delete(id);

            if (!result)
                return NotFound(new { message = "Contribuyente not found" });

            return Ok(new { message = "Successfully deleted" });
        }
    }
}