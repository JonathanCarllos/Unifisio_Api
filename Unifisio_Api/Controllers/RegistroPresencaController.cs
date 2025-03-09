using Microsoft.AspNetCore.Mvc;
using Unifisio_Api.DTOs;

[Route("api/[controller]")]
[ApiController]
public class RegistroPresencaController : ControllerBase
{
    private readonly IRegistroPresencaService _service;

    public RegistroPresencaController(IRegistroPresencaService service)
    {
        _service = service;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> RegistrarPresenca([FromBody] RegistroPresencaDto registroDto)
    {
        if (registroDto == null)
            return BadRequest("Dados inválidos");

        await _service.AdicionarRegistroAsync(registroDto);
        return Ok(new { message = "Registro salvo com sucesso!" });
    }

    [HttpGet("paciente/{pacienteId}")]
    public async Task<IActionResult> ObterRegistrosPorPaciente(int pacienteId)
    {
        var registros = await _service.ObterPorPacienteAsync(pacienteId);
        return Ok(registros);
    }

    [HttpGet("fisioterapeuta/{fisioterapeutaId}/data/{data}")]
    public async Task<IActionResult> ObterRegistrosPorFisioterapeutaEData(int fisioterapeutaId, DateTime data)
    {
        var registros = await _service.ObterPorFisioterapeutaEDataAsync(fisioterapeutaId, data);
        return Ok(registros);
    }
}
