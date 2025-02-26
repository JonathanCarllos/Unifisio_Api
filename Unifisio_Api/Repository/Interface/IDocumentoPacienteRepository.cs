using Unifisio_Api.Models;

namespace Unifisio_Api.Repository.Interface
{
    public interface IDocumentoPacienteRepository
    {
        Task<DocumentoPaciente> CreateAsync(DocumentoPaciente documentoPaciente);
        Task<DocumentoPaciente> UpdateAsync(DocumentoPaciente documentoPaciente);
        Task<DocumentoPaciente?> GetByIdAsync(int id);
    }
}
