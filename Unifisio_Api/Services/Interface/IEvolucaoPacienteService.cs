using Unifisio_Api.DTOs;

namespace Unifisio_Api.Services.Interface
{
    public interface IEvolucaoPacienteService
    {
        Task<IEnumerable<EvolucaoPacienteDTO>> GetEvolucaoPaciente();
        Task<EvolucaoPacienteDTO> GetEvolucaoPacienteById(int id);
        Task AddEvolucaoPaciente(EvolucaoPacienteDTO evolucaoPacienteDTO);
        Task UpdateEvolucaoPaciente(EvolucaoPacienteDTO evolucaoPacienteDTO);
        Task RemoveEvolucaoPaciente(int id);
    }
}
