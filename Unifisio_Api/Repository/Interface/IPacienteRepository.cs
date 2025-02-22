using Unifisio_Api.Models;

namespace Unifisio_Api.Repository.Interface
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAll();
        Task<Paciente> GetById(int id);
        Task<Paciente> Create(Paciente paciente);
        Task<Paciente> Update(Paciente paciente);
        Task<Paciente> Delete(int id);
    }
}
