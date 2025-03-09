using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unifisio_Api.Context;

public class FisioterapeutaDisponibilidadeRepository : IFisioterapeutaDisponibilidadeRepository
{
    private readonly AppDbContext _context;

    public FisioterapeutaDisponibilidadeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<FisioterapeutaDisponibilidade>> ObterTodosAsync()
    {
        return await _context.FisioterapeutaDisponibilidades
            .Include(f => f.Fisioterapeuta)
            .ToListAsync();
    }

    public async Task<FisioterapeutaDisponibilidade> ObterPorIdAsync(int id)
    {
        return await _context.FisioterapeutaDisponibilidades
            .Include(f => f.Fisioterapeuta)
            .FirstOrDefaultAsync(f => f.FisioterapeutaDisponibilidadeId == id);
    }

    public async Task AdicionarAsync(FisioterapeutaDisponibilidade disponibilidade)
    {
        _context.FisioterapeutaDisponibilidades.Add(disponibilidade);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(FisioterapeutaDisponibilidade disponibilidade)
    {
        _context.FisioterapeutaDisponibilidades.Update(disponibilidade);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var disponibilidade = await _context.FisioterapeutaDisponibilidades.FindAsync(id);
        if (disponibilidade != null)
        {
            _context.FisioterapeutaDisponibilidades.Remove(disponibilidade);
            await _context.SaveChangesAsync();
        }
    }
}
