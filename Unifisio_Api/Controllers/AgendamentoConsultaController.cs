using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.Services.Interface;

[Route("api/[controller]")]
[ApiController]
public class AgendamentoConsultaController : ControllerBase
{
    private readonly IAgendamentoConsultaService _service;

    public AgendamentoConsultaController(IAgendamentoConsultaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<AgendamentoConsultaDTO>>> ObterConsultas()
    {
        var consultas = await _service.ObterConsultasAsync();
        return Ok(consultas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AgendamentoConsultaDTO>> ObterConsulta(int id)
    {
        var consulta = await _service.ObterConsultaPorIdAsync(id);
        if (consulta == null) return NotFound("Consulta não encontrada.");
        return Ok(consulta);
    }

    [HttpPost("agendar")]
    public async Task<ActionResult> AgendarConsulta([FromBody] AgendamentoConsultaDTO consultaDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var consultaAgendada = await _service.AgendarConsultaAsync(consultaDTO);
        return CreatedAtAction(nameof(ObterConsulta), new { id = consultaAgendada.AgendamentoConsultaId }, consultaAgendada);
    }

    [HttpDelete("cancelar/{id}")]
    public async Task<ActionResult> CancelarConsulta(int id)
    {
        var sucesso = await _service.CancelarConsultaAsync(id);
        if (!sucesso) return NotFound("Consulta não encontrada.");
        return Ok("Consulta cancelada com sucesso.");
    }
}
