using AutoMapper;
using Unifisio_Api.DTOs;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Services
{
    public class EvolucaoPacienteService : IEvolucaoPacienteService
    {
        private readonly IEvolucaoPacienteRepository _evolucaoPacienteRepository;
        private readonly IMapper _mapper;

        public EvolucaoPacienteService(IEvolucaoPacienteRepository evolucaoPacienteRepository, IMapper mapper)
        {
            _evolucaoPacienteRepository = evolucaoPacienteRepository;
            _mapper = mapper;
        }

        public async Task AddEvolucaoPaciente(EvolucaoPacienteDTO evolucaoPacienteDTO)
        {
            var evolucaoPacienteEntity = _mapper.Map<EvolucaoPaciente>(evolucaoPacienteDTO);
            await _evolucaoPacienteRepository.Create(evolucaoPacienteEntity);
            evolucaoPacienteDTO.EvolucaoPacienteId = evolucaoPacienteEntity.EvolucaoPacienteId;
        }

        public async Task<IEnumerable<EvolucaoPacienteDTO>> GetEvolucaoPaciente()
        {
            var evolucoesPacienteEntity = await _evolucaoPacienteRepository.GetAll();
            return _mapper.Map<IEnumerable<EvolucaoPacienteDTO>>(evolucoesPacienteEntity);
        }

        public async Task<EvolucaoPacienteDTO> GetEvolucaoPacienteById(int id)
        {
            var evolucaoPacienteEntity = await _evolucaoPacienteRepository.GetById(id);
            return _mapper.Map<EvolucaoPacienteDTO>(evolucaoPacienteEntity);
        }

        public async Task RemoveEvolucaoPaciente(int id)
        {
            var evolucaoPacienteEntity = _evolucaoPacienteRepository.GetById(id).Result;
            await _evolucaoPacienteRepository.Delete(evolucaoPacienteEntity.EvolucaoPacienteId);
        }

        public async Task UpdateEvolucaoPaciente(EvolucaoPacienteDTO evolucaoPacienteDTO)
        {
            var evolucaoPacienteEntity = _mapper.Map<EvolucaoPaciente>(evolucaoPacienteDTO);
            await _evolucaoPacienteRepository.Update(evolucaoPacienteEntity);
        }
    }
}
