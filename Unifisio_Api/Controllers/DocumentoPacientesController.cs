//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.IO;
//using System.Threading.Tasks;
//using Unifisio_Api.DTOs;
//using Unifisio_Api.Services.Interface;

//namespace Unifisio_Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DocumentoPacientesController : ControllerBase
//    {
//        private readonly IDocumentoPacienteService _service;
//        private readonly IWebHostEnvironment _env;

//        public DocumentoPacientesController(IDocumentoPacienteService service, IWebHostEnvironment env)
//        {
//            _service = service;
//            _env = env;
//        }

//        [HttpGet("{id:int}")]
//        public async Task<ActionResult> GetDocumento(int id)
//        {
//            try
//            {
//                var documento = await _service.ObterDocumentoPorIdAsync(id);
//                if (documento == null)
//                    return NotFound("Documento não encontrado.");

//                if (!System.IO.File.Exists(documento.CaminhoArquivo))
//                    return NotFound("O arquivo físico não foi encontrado.");

//                var fileBytes = await System.IO.File.ReadAllBytesAsync(documento.CaminhoArquivo);
//                var contentType = "application/octet-stream";

//                return File(fileBytes, contentType, documento.NomeArquivo);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Erro interno ao buscar o documento: {ex.Message}");
//            }
//        }

//        [HttpPost("upload")]
//        public async Task<ActionResult> UploadArquivo([FromForm] int pacienteId, [FromForm] IFormFile arquivo)
//        {
//            if (arquivo == null || arquivo.Length == 0)
//                return BadRequest("Nenhum arquivo foi enviado.");

//            var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
//            var extensaoArquivo = Path.GetExtension(arquivo.FileName).ToLower();

//            if (!extensoesPermitidas.Contains(extensaoArquivo))
//                return BadRequest("Tipo de arquivo não permitido.");

//            try
//            {
//                string uploadsFolder = Path.Combine(_env.ContentRootPath, "uploads");
//                if (!Directory.Exists(uploadsFolder))
//                    Directory.CreateDirectory(uploadsFolder);

//                string fileName = $"{Guid.NewGuid()}{extensaoArquivo}";
//                string filePath = Path.Combine(uploadsFolder, fileName);

//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    await arquivo.CopyToAsync(stream);
//                }

//                var documentoDTO = new DocumentoPacienteDTO
//                {
//                    PacienteId = pacienteId,
//                    NomeArquivo = arquivo.FileName,
//                    CaminhoArquivo = filePath
//                };

//                var documentoCriado = await _service.AdicionarDocumentoAsync(documentoDTO);

//                return Ok(new
//                {
//                    message = "Arquivo enviado com sucesso!",
//                    documentoId = documentoCriado.DocumentoPacienteId
//                });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Erro interno ao fazer upload do arquivo: {ex.Message}");
//            }
//        }
//    }
//}
