using AutoMapper;
using Unifisio_Api.DTOs;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task AddPaciente(PacienteDTO pacienteDTO)
        {
            var pacienteEntity = _mapper.Map<Paciente>(pacienteDTO);
            await _pacienteRepository.Create(pacienteEntity);
            pacienteDTO.PacienteId = pacienteEntity.PacienteId;
        }

        public async Task<IEnumerable<PacienteDTO>> GetPaciente()
        {
            var pacientesEntity = await _pacienteRepository.GetAll();
            return _mapper.Map<IEnumerable<PacienteDTO>>(pacientesEntity);
        }

        public async Task<PacienteDTO> GetPacienteById(int id)
        {
            var pacienteEntity = await _pacienteRepository.GetById(id);
            return _mapper.Map<PacienteDTO>(pacienteEntity);
        }

        public async Task RemovePaciente(int id)
        {
            var pacienteEntity = _pacienteRepository.GetById(id).Result;
            await _pacienteRepository.Delete(pacienteEntity.PacienteId);
        }

        public async Task UpdatePaciente(PacienteDTO pacienteDTO)
        {
            var pacienteEntity = _mapper.Map<Paciente>(pacienteDTO);
            await _pacienteRepository.Update(pacienteEntity);
        }
    }
}
