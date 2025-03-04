using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unifisio_Api.Context;

public class AgendamentoConsultaRepository : IAgendamentoConsultaRepository
{
    private readonly AppDbContext _context;

    public AgendamentoConsultaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AgendamentoConsultaDTO>> ObterConsultasAsync()
    {
        return await _context.AgendamentoConsultas
            .Select(c => new AgendamentoConsultaDTO
            {
                AgendamentoConsultaId = c.AgendamentoConsultaId,
                PacienteId = c.PacienteId,
                FisioterapeutaId = c.FisioterapeutaId,
                DataHora = c.DataHora,
                Observacoes = c.Observacoes
            })
            .ToListAsync();
    }

    public async Task<AgendamentoConsultaDTO?> ObterConsultaPorIdAsync(int id)
    {
        return await _context.AgendamentoConsultas
            .Where(c => c.AgendamentoConsultaId == id)
            .Select(c => new AgendamentoConsultaDTO
            {
                AgendamentoConsultaId = c.AgendamentoConsultaId,
                PacienteId = c.PacienteId,
                FisioterapeutaId = c.FisioterapeutaId,
                DataHora = c.DataHora,
                Observacoes = c.Observacoes
            })
            .FirstOrDefaultAsync();
    }

    public async Task<AgendamentoConsultaDTO> AgendarConsultaAsync(AgendamentoConsultaDTO consultaDTO)
    {
        var novaConsulta = new AgendamentoConsulta
        {
            PacienteId = consultaDTO.PacienteId,
            FisioterapeutaId = consultaDTO.FisioterapeutaId,
            DataHora = consultaDTO.DataHora,
            Observacoes = consultaDTO.Observacoes
        };

        _context.AgendamentoConsultas.Add(novaConsulta);
        await _context.SaveChangesAsync();

        consultaDTO.AgendamentoConsultaId = novaConsulta.AgendamentoConsultaId;
        return consultaDTO;
    }

    public async Task<bool> CancelarConsultaAsync(int id)
    {
        var consulta = await _context.AgendamentoConsultas.FindAsync(id);
        if (consulta == null) return false;

        _context.AgendamentoConsultas.Remove(consulta);
        await _context.SaveChangesAsync();
        return true;
    }
}
