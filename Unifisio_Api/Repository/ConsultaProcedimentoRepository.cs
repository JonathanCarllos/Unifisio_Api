using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unifisio_Api.Context;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;

namespace Unifisio_Api.Repository
{
    public class ConsultaProcedimentoRepository : IConsultaProcedimentoRepository
    {
        private readonly AppDbContext _context;

        public ConsultaProcedimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ConsultaProcedimento> CriarConsultaAsync(ConsultaProcedimento consulta)
        {
            _context.ConsultaProcedimentos.Add(consulta);
            await _context.SaveChangesAsync();
            return consulta;
        }

        public async Task<List<ConsultaProcedimento>> ObterConsultasPorPacienteAsync(int pacienteId)
        {
            return await _context.ConsultaProcedimentos
                .Where(c => c.PacienteId == pacienteId)
                .ToListAsync();
        }

        public async Task<List<ConsultaProcedimento>> ObterConsultasPorFisioterapeutaAsync(int fisioterapeutaId)
        {
            return await _context.ConsultaProcedimentos
                .Where(c => c.FisioterapeutaId == fisioterapeutaId)
                .ToListAsync();
        }
    }
}
