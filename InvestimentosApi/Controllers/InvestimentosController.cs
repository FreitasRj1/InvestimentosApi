using InvestimentosBusiness;
using InvestimentosModel;
using Microsoft.AspNetCore.Mvc;

namespace InvestimentosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentosController : ControllerBase
    {
        private readonly InvestimentoService _service;

        // Injeção de dependência via interface (boa prática)
        public InvestimentosController(InvestimentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var investimentos = await _service.GetAllAsync();
            return Ok(investimentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var investimento = await _service.GetByIdAsync(id);
            if (investimento == null)
                return NotFound();

            return Ok(investimento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Investimento investimento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(investimento);

            return CreatedAtAction(nameof(GetById), new { id = investimento.Id }, investimento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Investimento investimento)
        {
            if (id != investimento.Id)
                return BadRequest("O ID da URL não corresponde ao ID do objeto.");

            await _service.UpdateAsync(investimento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
