using Microsoft.EntityFrameworkCore;
using Unifisio_Api.Context;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;

namespace Unifisio_Api.Repository
{
    public class HistoricoClinicoRepository : IHistoricoClinicoRepository
    {
        private readonly AppDbContext _context;

        public HistoricoClinicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HistoricoClinico> Create(HistoricoClinico historicoClinico)
        {
            _context.HistoricoClinico.Add(historicoClinico);
            await _context.SaveChangesAsync();
            return historicoClinico;
        }

        public async Task<HistoricoClinico> Delete(int id)
        {
           var historicoClinico = await GetById(id);
            _context.HistoricoClinico.Remove(historicoClinico);
            await _context.SaveChangesAsync();
            return historicoClinico;
        }

        public async Task<IEnumerable<HistoricoClinico>> GetAll()
        {
            return await _context.HistoricoClinico.ToListAsync();
        }

        public async Task<HistoricoClinico> GetById(int id)
        {
            return await _context.HistoricoClinico.Where(h => h.HistoricoClinicoId == id).FirstOrDefaultAsync();
        }

        public async Task<HistoricoClinico> Update(HistoricoClinico historicoClinico)
        {
            _context.HistoricoClinico.Entry(historicoClinico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return historicoClinico;
        }
    }
}
