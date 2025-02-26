using Microsoft.EntityFrameworkCore;
using Unifisio_Api.Context;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;

namespace Unifisio_Api.Repository
{
    public class DocumentoPacienteRepository : IDocumentoPacienteRepository
    {
        private readonly AppDbContext _context;

        public DocumentoPacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DocumentoPaciente> CreateAsync(DocumentoPaciente documentoPaciente)
        {
            try
            {
                await _context.DocumentoPacientes.AddAsync(documentoPaciente);
                await _context.SaveChangesAsync();
                return documentoPaciente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar documento do paciente.", ex);
            }
        }

        public async Task<DocumentoPaciente> UpdateAsync(DocumentoPaciente documentoPaciente)
        {
            try
            {
                _context.DocumentoPacientes.Update(documentoPaciente);
                await _context.SaveChangesAsync();
                return documentoPaciente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar documento do paciente.", ex);
            }
        }

        public async Task<DocumentoPaciente?> GetByIdAsync(int id)
        {
            return await _context.DocumentoPacientes.FindAsync(id);
        }
    }
}
