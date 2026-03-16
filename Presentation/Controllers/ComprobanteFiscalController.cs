using Microsoft.AspNetCore.Mvc;
using dgii_api.Services;

namespace dgii_api.Controllers
{
    [Route("api/comprobantes")]
    [ApiController]
    public class ComprobanteFiscalController : ControllerBase
    {
        private readonly IComprobanteFiscalService _service;

        public ComprobanteFiscalController(IComprobanteFiscalService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ComprobanteResponseDto>> GetComprobantes()
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ComprobanteResponseDto> GetComprobante(int id)
        {
            var result = _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateComprobante([FromBody] ComprobanteCreateDto payload)
        {
            var result = _service.Create(payload);

            if (!result)
                return BadRequest(new
                {
                    message = "NCF already exists or Contribuyente not found"
                });

            return Created("", new { message = "Successfully created" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComprobante(int id, [FromBody] ComprobanteUpdateDto dto)
        {
            var result = _service.Update(id, dto);

            if (!result)
                return NotFound(new { message = "Comprobante not found" });

            return Ok(new { message = "Successfully updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComprobante(int id)
        {
            var result = _service.Delete(id);

            if (!result)
                return NotFound(new { message = "Comprobante not found" });

            return Ok(new { message = "Successfully deleted" });
        }

        [HttpGet("contribuyente/{rnc}")]
        public ActionResult<ContribuyenteComprobantesDto> GetComprobantesByRnc(string rnc)
        {
            var result = _service.GetComprobantesByRnc(rnc);

            if (result == null)
                return NotFound(new { message = "No comprobantes found for this RNC" });

            return Ok(result);
        }
    }
}