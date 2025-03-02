using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Services
{
    public class ConsultaProcedimentoService : IConsultaProcedimentosService
    {
        private readonly IConsultaProcedimentoRepository _consultaRepository;
        private readonly IMapper _mapper;

        public ConsultaProcedimentoService(IConsultaProcedimentoRepository consultaRepository, IMapper mapper)
        {
            _consultaRepository = consultaRepository;
            _mapper = mapper;
        }

        public async Task<ConsultaProcedimentoDTO> CriarConsultaAsync(ConsultaProcedimentoDTO consultaDTO)
        {
            var consultaEntity = _mapper.Map<ConsultaProcedimento>(consultaDTO);
            var novaConsulta = await _consultaRepository.CriarConsultaAsync(consultaEntity);
            return _mapper.Map<ConsultaProcedimentoDTO>(novaConsulta);
        }

        public async Task<List<ConsultaProcedimentoDTO>> ObterConsultasPorPacienteAsync(int pacienteId)
        {
            var consultas = await _consultaRepository.ObterConsultasPorPacienteAsync(pacienteId);
            return _mapper.Map<List<ConsultaProcedimentoDTO>>(consultas);
        }

        public async Task<List<ConsultaProcedimentoDTO>> ObterConsultasPorFisioterapeutaAsync(int fisioterapeutaId)
        {
            var consultas = await _consultaRepository.ObterConsultasPorFisioterapeutaAsync(fisioterapeutaId);
            return _mapper.Map<List<ConsultaProcedimentoDTO>>(consultas);
        }
    }
}
