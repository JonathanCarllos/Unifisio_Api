using AutoMapper;
using Unifisio_Api.DTOs;
using Unifisio_Api.Models;
using Unifisio_Api.Repository.Interface;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Services
{
    public class HistoricoClinicoService : IHistoricoClinicoService
    {
        private readonly IHistoricoClinicoRepository _historicoClinico;
        private readonly IMapper _mapper;

        public HistoricoClinicoService(IHistoricoClinicoRepository historicoClinico, IMapper mapper)
        {
            _historicoClinico = historicoClinico;
            _mapper = mapper;
        }

        public async Task AddHistoricoClinico(HistoricoClinicoDTO historicoClinicoDTO)
        {
            var historicoClinicoEntity = _mapper.Map<HistoricoClinico>(historicoClinicoDTO);
            await _historicoClinico.Create(historicoClinicoEntity);
            historicoClinicoDTO.HistoricoClinicoId = historicoClinicoEntity.HistoricoClinicoId;
        }

        public async Task<IEnumerable<HistoricoClinicoDTO>> GetHistoricoClinico()
        {
            var historicoClinicoEntity = await _historicoClinico.GetAll();
            return _mapper.Map<IEnumerable<HistoricoClinicoDTO>>(historicoClinicoEntity);
        }

        public async Task<HistoricoClinicoDTO> GetHisToricoCLinicoById(int id)
        {
            var historicoClinicoEntity = await _historicoClinico.GetById(id);
            return _mapper.Map<HistoricoClinicoDTO>(historicoClinicoEntity);
        }

        public async Task RemoveHistoricoClinico(int id)
        {
            var historicoClinicoEntity = _historicoClinico.GetById(id).Result;
            await _historicoClinico.Delete(historicoClinicoEntity.HistoricoClinicoId);
        }

        public async Task UpdateHistoricoClinico(HistoricoClinicoDTO historicoClinicoDTO)
        {
            var historicoClinicoEntity = _mapper.Map<HistoricoClinico>(historicoClinicoDTO);
            await _historicoClinico.Update(historicoClinicoEntity);
        }
    }
}
