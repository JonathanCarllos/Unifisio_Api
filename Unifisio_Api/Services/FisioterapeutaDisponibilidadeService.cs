using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

public class FisioterapeutaDisponibilidadeService : IFisioterapeutaDisponibilidadeService
{
    private readonly IFisioterapeutaDisponibilidadeRepository _repository;
    private readonly IMapper _mapper;

    public FisioterapeutaDisponibilidadeService(IFisioterapeutaDisponibilidadeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<FisioterapeutaDisponibilidadeDTO>> ObterTodosAsync()
    {
        var disponibilidades = await _repository.ObterTodosAsync();
        return _mapper.Map<List<FisioterapeutaDisponibilidadeDTO>>(disponibilidades);
    }

    public async Task<FisioterapeutaDisponibilidadeDTO> ObterPorIdAsync(int id)
    {
        var disponibilidade = await _repository.ObterPorIdAsync(id);
        return _mapper.Map<FisioterapeutaDisponibilidadeDTO>(disponibilidade);
    }

    public async Task AdicionarAsync(FisioterapeutaDisponibilidadeDTO dto)
    {
        var disponibilidade = _mapper.Map<FisioterapeutaDisponibilidade>(dto);
        await _repository.AdicionarAsync(disponibilidade);
    }

    public async Task AtualizarAsync(int id, FisioterapeutaDisponibilidadeDTO dto)
    {
        var disponibilidade = await _repository.ObterPorIdAsync(id);
        if (disponibilidade != null)
        {
            _mapper.Map(dto, disponibilidade);
            await _repository.AtualizarAsync(disponibilidade);
        }
    }

    public async Task RemoverAsync(int id)
    {
        await _repository.RemoverAsync(id);
    }
}
