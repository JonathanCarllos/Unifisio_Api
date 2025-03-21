using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlanoTratamentosController : ControllerBase
    {
        private readonly IPlanoTratamentoService _service;

        public PlanoTratamentosController(IPlanoTratamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPlano([FromBody] PlanoTratamentoDTO planoDTO)
        {
            try
            {
                var planoCriado = await _service.CriarPlano(planoDTO);
                return Ok(planoCriado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar plano: {ex.Message}");
            }
        }

        [HttpGet("{pacienteId:int}")]
        public async Task<IActionResult> BuscarPlano(int pacienteId)
        {
            var plano = await _service.BuscarPlanoPorPaciente(pacienteId);
            if (plano == null)
                return NotFound("Plano de tratamento não encontrado.");
            return Ok(plano);
        }

        [HttpPut("atualizar-sessao/{pacienteId:int}")]
        public async Task<IActionResult> AtualizarSessao(int pacienteId)
        {
            try
            {
                await _service.AtualizarSessao(pacienteId);
                return Ok("Sessão registrada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao registrar sessão: {ex.Message}");
            }
        }
    }
}
