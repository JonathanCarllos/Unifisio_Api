using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/disponibilidade")]
[ApiController]
[Authorize]
public class FisioterapeutaDisponibilidadesController : ControllerBase
{
    private readonly IFisioterapeutaDisponibilidadeService _service;

    public FisioterapeutaDisponibilidadesController(IFisioterapeutaDisponibilidadeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<FisioterapeutaDisponibilidadeDTO>>> ObterTodos()
    {
        var result = await _service.ObterTodosAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FisioterapeutaDisponibilidadeDTO>> ObterPorId(int id)
    {
        var result = await _service.ObterPorIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar([FromBody] FisioterapeutaDisponibilidadeDTO dto)
    {
        await _service.AdicionarAsync(dto);
        return CreatedAtAction(nameof(ObterPorId), new { id = dto.FisioterapeutaDisponibilidadeId }, dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, [FromBody] FisioterapeutaDisponibilidadeDTO dto)
    {
        await _service.AtualizarAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remover(int id)
    {
        await _service.RemoverAsync(id);
        return NoContent();
    }
}
