using AutoMapper;
using Unifisio_Api.DTOs;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Services
{
    public class FisioterapeutaService : IFisioterapeutaService
    {
        private readonly IFisioterapeutaRepository _fisioterapeutaRepository;
        private readonly IMapper _mapper;

        public FisioterapeutaService(IFisioterapeutaRepository fisioterapeutaRepository, IMapper mapper)
        {
            _fisioterapeutaRepository = fisioterapeutaRepository;
            _mapper = mapper;
        }

        public async Task AddFisioterapeuta(FisioterapeutaDTO fisioterapeutaDTO)
        {
            var fisioterapeutaEntity = _mapper.Map<Fisioterapeuta>(fisioterapeutaDTO);
            await _fisioterapeutaRepository.Create(fisioterapeutaEntity);
            fisioterapeutaDTO.FisioterapeutaId = fisioterapeutaEntity.FisioterapeutaId;
        }

        public async Task<IEnumerable<FisioterapeutaDTO>> GetFisioterapeuta()
        {
            var fisioterapeutasEntity = await _fisioterapeutaRepository.GetAll();
            return _mapper.Map<IEnumerable<FisioterapeutaDTO>>(fisioterapeutasEntity);
        }

        public async Task<FisioterapeutaDTO> GetFisioterapeutaById(int id)
        {
            var fisioterapeutaEntity = await _fisioterapeutaRepository.GetById(id);
            return _mapper.Map<FisioterapeutaDTO>(fisioterapeutaEntity);
        }

        public async Task<IEnumerable<FisioterapeutaDTO>> GetFisioterapeutaPaciente()
        {
            var fisioterapeutasEntity = await _fisioterapeutaRepository.GetFisioterapeutasPacientes();
            return _mapper.Map<IEnumerable<FisioterapeutaDTO>>(fisioterapeutasEntity);
        }

        public async Task RemoveFisioterapeuta(int id)
        {
            var fisioterapeutaEntity = _fisioterapeutaRepository.GetById(id).Result;
            await _fisioterapeutaRepository.Delete(fisioterapeutaEntity.FisioterapeutaId);
        }

        public async Task UpdateFisioterapeuta(FisioterapeutaDTO fisioterapeutaDTO)
        {
            var fisioterapeutaEntity = _mapper.Map<Fisioterapeuta>(fisioterapeutaDTO);
            await _fisioterapeutaRepository.Update(fisioterapeutaEntity);

        }
    }
}
