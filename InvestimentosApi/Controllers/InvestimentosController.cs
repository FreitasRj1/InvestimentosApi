using InvestimentosData;
using InvestimentosModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvestimentosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvestimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/investimentos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var investimentos = await _context.Investimentos.ToListAsync();
            return Ok(investimentos);
        }

        // GET: api/investimentos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var investimento = await _context.Investimentos.FindAsync(id);
            if (investimento == null) return NotFound();
            return Ok(investimento);
        }

        // POST: api/investimentos
        [HttpPost]
        public async Task<IActionResult> Create(Investimento investimento)
        {
            _context.Investimentos.Add(investimento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = investimento.Id }, investimento);
        }

        // PUT: api/investimentos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Investimento investimento)
        {
            if (id != investimento.Id) return BadRequest();

            _context.Entry(investimento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/investimentos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var investimento = await _context.Investimentos.FindAsync(id);
            if (investimento == null) return NotFound();

            _context.Investimentos.Remove(investimento);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 🔎 Pesquisa com LINQ
        [HttpGet("pesquisar/{valorMinimo}")]
        public IActionResult FiltrarPorValor(decimal valorMinimo)
        {
            var resultados = _context.Investimentos
                .Where(i => i.Valor >= valorMinimo)
                .OrderByDescending(i => i.Valor)
                .ToList();

            return Ok(resultados);
        }
    }
}
