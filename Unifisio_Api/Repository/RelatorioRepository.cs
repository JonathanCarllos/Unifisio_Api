using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unifisio_Api.Context;
using Unifisio_Api.DTOs;

public class RelatorioRepository : IRelatorioRepository
{
    private readonly AppDbContext _context;

    public RelatorioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<RelatorioProdutividadeDTO>> ObterRelatorioProdutividadeAsync(DateTime inicio, DateTime fim)
    {
        return await _context.ConsultaProcedimentos
            .Where(c => c.DataConsulta >= inicio && c.DataConsulta <= fim)
            .GroupBy(c => new { c.FisioterapeutaId, c.Fisioterapeuta!.Nome })
            .Select(g => new RelatorioProdutividadeDTO
            {
                FisioterapeutaId = g.Key.FisioterapeutaId,
                NomeFisioterapeuta = g.Key.Nome,
                TotalConsultas = g.Count(),
                PeriodoInicio = inicio,
                PeriodoFim = fim
            })
            .ToListAsync();
    }
}
