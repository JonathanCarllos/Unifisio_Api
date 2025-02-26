using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Unifisio_Api.Context;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;

namespace Unifisio_Api.Repository
{
    public class PlanoTratamentoRepository : IPlanoTratamentoRepository
    {
        private readonly AppDbContext _context;

        public PlanoTratamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PlanoTratamento> CriarPlano(PlanoTratamento plano)
        {
            _context.PlanoTratamentos.Add(plano);
            await _context.SaveChangesAsync();
            return plano;
        }

        public async Task<PlanoTratamento> AtualizarPlano(PlanoTratamento plano)
        {
            _context.Entry(plano).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return plano;
        }

        public async Task<PlanoTratamento?> BuscarPlanoPorPaciente(int pacienteId)
        {
            return await _context.PlanoTratamentos
                .FirstOrDefaultAsync(p => p.PacienteId == pacienteId);
        }
    }
}

