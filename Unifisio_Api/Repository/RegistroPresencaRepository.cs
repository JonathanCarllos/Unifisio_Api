using Microsoft.EntityFrameworkCore;
using Unifisio_Api.Context;

public class RegistroPresencaRepository : IRegistroPresencaRepository
{
    private readonly AppDbContext _context;

    public RegistroPresencaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarRegistroAsync(RegistroPresenca registro)
    {
        _context.RegistroPresencas.Add(registro);
        await _context.SaveChangesAsync();
    }

    public async Task<List<RegistroPresenca>> ObterPorPacienteAsync(int pacienteId)
    {
        return await _context.RegistroPresencas
            .Where(r => r.PacienteId == pacienteId)
            .ToListAsync();
    }

    public async Task<List<RegistroPresenca>> ObterPorFisioterapeutaEDataAsync(int fisioterapeutaId, DateTime data)
    {
        return await _context.RegistroPresencas
            .Where(r => r.FisioterapeutaId == fisioterapeutaId && r.DataAtendimento.Date == data.Date)
            .ToListAsync();
    }
}
