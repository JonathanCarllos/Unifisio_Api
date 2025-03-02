using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;
using Unifisio_Api.Services.Interface;

[Route("api/[controller]")]
[ApiController]
public class RelatorioProdutividadeController : ControllerBase
{
    private readonly IRelatorioProdutividadeService _service;

    public RelatorioProdutividadeController(IRelatorioProdutividadeService service)
    {
        _service = service;
    }

    [HttpGet("produtividade")]
    public async Task<ActionResult<List<RelatorioProdutividadeDTO>>> ObterRelatorioProdutividade([FromQuery] DateTime inicio, [FromQuery] DateTime fim)
    {
        try
        {
            var relatorio = await _service.ObterRelatorioProdutividadeAsync(inicio, fim);

            if (relatorio == null || relatorio.Count == 0)
                return NotFound("Nenhuma produtividade encontrada para o período especificado.");

            return Ok(relatorio);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno ao gerar relatório: {ex.Message}");
        }
    }
}
