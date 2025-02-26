using AutoMapper;
using Unifisio_Api.DTOs;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Services
{
    public class DocumentoPacienteService : IDocumentoPacienteService
    {
        private readonly IDocumentoPacienteRepository _documentoPacienteRepository;
        private readonly IMapper _mapper;

        public DocumentoPacienteService(IDocumentoPacienteRepository documentoPacienteRepository, IMapper mapper)
        {
            _documentoPacienteRepository = documentoPacienteRepository;
            _mapper = mapper;
        }

        public async Task<DocumentoPacienteDTO> AdicionarDocumentoAsync(DocumentoPacienteDTO documentoPacienteDTO)
        {
            try
            {
                var documentoPacienteEntity = _mapper.Map<DocumentoPaciente>(documentoPacienteDTO);
                var documentoCriado = await _documentoPacienteRepository.CreateAsync(documentoPacienteEntity);

                return _mapper.Map<DocumentoPacienteDTO>(documentoCriado);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar documento do paciente.", ex);
            }
        }

        public async Task AtualizarDocumentoAsync(DocumentoPacienteDTO documentoPacienteDTO)
        {
            try
            {
                var documentoPacienteEntity = _mapper.Map<DocumentoPaciente>(documentoPacienteDTO);
                await _documentoPacienteRepository.UpdateAsync(documentoPacienteEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar documento do paciente.", ex);
            }
        }

        public async Task<DocumentoPacienteDTO?> ObterDocumentoPorIdAsync(int id)
        {
            var documento = await _documentoPacienteRepository.GetByIdAsync(id);
            return documento != null ? _mapper.Map<DocumentoPacienteDTO>(documento) : null;
        }
    }
}
