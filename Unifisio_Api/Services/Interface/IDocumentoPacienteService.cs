using Unifisio_Api.DTOs;

namespace Unifisio_Api.Services.Interface
{
    public interface IDocumentoPacienteService
    {
        Task<DocumentoPacienteDTO> AdicionarDocumentoAsync(DocumentoPacienteDTO documentoPacienteDTO);
        Task AtualizarDocumentoAsync(DocumentoPacienteDTO documentoPacienteDTO);
        Task<DocumentoPacienteDTO?> ObterDocumentoPorIdAsync(int id);
    }
}
