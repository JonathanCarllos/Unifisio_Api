using Unifisio_Api.Models;

namespace Unifisio_Api.Repository.Interface
{
    public interface IEvolucaoPacienteRepository
    {
        Task<IEnumerable<EvolucaoPaciente>> GetAll();
        Task<EvolucaoPaciente> GetById(int id);
        Task<EvolucaoPaciente> Create(EvolucaoPaciente evolucaoPaciente);
        Task<EvolucaoPaciente> Update(EvolucaoPaciente evolucaoPaciente);
        Task<EvolucaoPaciente> Delete(int id);
    }
}
