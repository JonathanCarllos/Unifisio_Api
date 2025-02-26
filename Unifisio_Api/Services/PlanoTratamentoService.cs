using AutoMapper;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Services
{
    public class PlanoTratamentoService : IPlanoTratamentoService
    {
        private readonly IPlanoTratamentoRepository _repository;
        private readonly IMapper _mapper;

        public PlanoTratamentoService(IPlanoTratamentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PlanoTratamentoDTO> CriarPlano(PlanoTratamentoDTO planoDTO)
        {
            var plano = _mapper.Map<PlanoTratamento>(planoDTO);
            plano.SessoesRealizadas = 0;
            plano.Concluido = false;
            var resultado = await _repository.CriarPlano(plano);
            return _mapper.Map<PlanoTratamentoDTO>(resultado);
        }

        public async Task<PlanoTratamentoDTO?> BuscarPlanoPorPaciente(int pacienteId)
        {
            var plano = await _repository.BuscarPlanoPorPaciente(pacienteId);
            return plano != null ? _mapper.Map<PlanoTratamentoDTO>(plano) : null;
        }

        public async Task AtualizarSessao(int pacienteId)
        {
            var plano = await _repository.BuscarPlanoPorPaciente(pacienteId);
            if (plano != null)
            {
                plano.SessoesRealizadas++;
                if (plano.SessoesRealizadas >= plano.TotalSessoes)
                {
                    plano.Concluido = true;
                }
                await _repository.AtualizarPlano(plano);
            }
        }
    }
}
