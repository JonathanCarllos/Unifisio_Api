using Microsoft.EntityFrameworkCore;
using Unifisio_Api.Context;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;

namespace Unifisio_Api.Repository
{
    public class EvolucaoPacienteRepository : IEvolucaoPacienteRepository
    {
        private readonly AppDbContext _context;

        public EvolucaoPacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EvolucaoPaciente> Create(EvolucaoPaciente evolucaoPaciente)
        {
            _context.EvolucaoPacientes.Add(evolucaoPaciente);
            await _context.SaveChangesAsync();
            return evolucaoPaciente;
        }

        public async Task<EvolucaoPaciente> Delete(int id)
        {
            var evolucaoPaciente = await GetById(id);
            _context.EvolucaoPacientes.Remove(evolucaoPaciente);
            await _context.SaveChangesAsync();
            return evolucaoPaciente;
        }

        public async Task<IEnumerable<EvolucaoPaciente>> GetAll()
        {
            return await _context.EvolucaoPacientes.ToListAsync();
        }

        public async Task<EvolucaoPaciente> GetById(int id)
        {
            return await _context.EvolucaoPacientes.Where(e => e.EvolucaoPacienteId == id).FirstOrDefaultAsync();
        }

        public async Task<EvolucaoPaciente> Update(EvolucaoPaciente evolucaoPaciente)
        {
            _context.EvolucaoPacientes.Entry(evolucaoPaciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return evolucaoPaciente;
        }
    }
}
