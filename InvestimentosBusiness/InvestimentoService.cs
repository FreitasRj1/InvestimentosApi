using InvestimentosData;
using InvestimentosModel;
using Microsoft.EntityFrameworkCore;

namespace InvestimentosBusiness
{
    public class InvestimentoService
    {
        private readonly ApplicationDbContext _context;

        public InvestimentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Investimento>> GetAllAsync() =>
            await _context.Investimentos.ToListAsync();

        public async Task<Investimento?> GetByIdAsync(int id) =>
            await _context.Investimentos.FindAsync(id);

        public async Task AddAsync(Investimento investimento)
        {
            _context.Investimentos.Add(investimento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Investimento investimento)
        {
            _context.Investimentos.Update(investimento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var investimento = await _context.Investimentos.FindAsync(id);
            if (investimento != null)
            {
                _context.Investimentos.Remove(investimento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
