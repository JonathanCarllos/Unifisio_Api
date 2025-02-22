using Unifisio_Api.DTOs;

namespace Unifisio_Api.Services.Interface
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDTO>> GetPaciente();      
        Task<PacienteDTO> GetPacienteById(int id);
        Task AddPaciente(PacienteDTO pacienteDTO);
        Task UpdatePaciente(PacienteDTO pacienteDTO);
        Task RemovePaciente(int id);
    }
}
