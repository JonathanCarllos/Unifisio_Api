using Microsoft.EntityFrameworkCore;
using Unifisio_Api.Context;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;

namespace Unifisio_Api.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente> Create(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente> Delete(int id)
        {
            var paciente = await GetById(id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<IEnumerable<Paciente>> GetAll()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> GetById(int id)
        {
            return await _context.Pacientes.Where(p => p.PacienteId == id).FirstOrDefaultAsync();
        }

        public async Task<Paciente> Update(Paciente paciente)
        {
            _context.Pacientes.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return paciente;

        }
    }
}
