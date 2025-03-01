using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unifisio_Api.Context;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;

namespace Unifisio_Api.Repository
{
    public class HorarioAtendimentoRepository : IHorarioAtendimentoRepository
    {
        private readonly AppDbContext _context;

        public HorarioAtendimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HorarioAtendimento> CriarHorario(HorarioAtendimento horario)
        {
            _context.HorarioAtendimentos.Add(horario);
            await _context.SaveChangesAsync();
            return horario;
        }

        public async Task<List<HorarioAtendimento>> BuscarHorariosPorFisioterapeuta(int fisioterapeutaId)
        {
            return await _context.HorarioAtendimentos
                .Where(h => h.FisioterapeutaId == fisioterapeutaId)
                .ToListAsync();
        }

        public async Task AtualizarDisponibilidade(int horarioId, bool disponivel)
        {
            var horario = await _context.HorarioAtendimentos.FindAsync(horarioId);
            if (horario != null)
            {
                horario.Disponivel = disponivel;
                await _context.SaveChangesAsync();
            }
        }
    }
}
