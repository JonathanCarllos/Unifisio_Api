using Microsoft.EntityFrameworkCore;
using Unifisio_Api.Context;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;

namespace Unifisio_Api.Repository
{
    public class FisioterapeutaRepository : IFisioterapeutaRepository
    {
        private readonly AppDbContext _context;

        public FisioterapeutaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Fisioterapeuta> Create(Fisioterapeuta fisioterapeuta)
        {
            _context.Fisioterapeutas.Add(fisioterapeuta);
            await _context.SaveChangesAsync();
            return fisioterapeuta;
        }

        public async Task<Fisioterapeuta> Delete(int id)
        {
            var fisioterapeuta = await GetById(id);
            _context.Fisioterapeutas.Remove(fisioterapeuta);
            await _context.SaveChangesAsync();
            return fisioterapeuta;
        }

        public async Task<IEnumerable<Fisioterapeuta>> GetAll()
        {
           return await _context.Fisioterapeutas.Include(x => x.Paciente).ToListAsync();
        }

        public async Task<Fisioterapeuta> GetById(int id)
        {
            return await _context.Fisioterapeutas.Where(f => f.FisioterapeutaId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Fisioterapeuta>> GetFisioterapeutasPacientes()
        {
            return await _context.Fisioterapeutas.Include(f => f.Paciente).ToListAsync();
        }

        public async Task<Fisioterapeuta> Update(Fisioterapeuta fisioterapeuta)
        {
            _context.Fisioterapeutas.Entry(fisioterapeuta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return fisioterapeuta;
        }
    }
}
