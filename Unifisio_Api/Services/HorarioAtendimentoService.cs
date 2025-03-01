using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Services
{
    public class HorarioAtendimentoService : IHorarioAtendimentoService
    {
        private readonly IHorarioAtendimentoRepository _repository;
        private readonly IMapper _mapper;

        public HorarioAtendimentoService(IHorarioAtendimentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HorarioAtendimentoDTO> CriarHorario(HorarioAtendimentoDTO horarioDTO)
        {
            var horario = _mapper.Map<HorarioAtendimento>(horarioDTO);
            var resultado = await _repository.CriarHorario(horario);
            return _mapper.Map<HorarioAtendimentoDTO>(resultado);
        }

        public async Task<List<HorarioAtendimentoDTO>> BuscarHorariosPorFisioterapeuta(int fisioterapeutaId)
        {
            var horarios = await _repository.BuscarHorariosPorFisioterapeuta(fisioterapeutaId);
            return _mapper.Map<List<HorarioAtendimentoDTO>>(horarios);
        }

        public async Task AtualizarDisponibilidade(int horarioId, bool disponivel)
        {
            await _repository.AtualizarDisponibilidade(horarioId, disponivel);
        }
    }
}
