using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFisioterapeutaDisponibilidadeService
{
    Task<List<FisioterapeutaDisponibilidadeDTO>> ObterTodosAsync();
    Task<FisioterapeutaDisponibilidadeDTO> ObterPorIdAsync(int id);
    Task AdicionarAsync(FisioterapeutaDisponibilidadeDTO dto);
    Task AtualizarAsync(int id, FisioterapeutaDisponibilidadeDTO dto);
    Task RemoverAsync(int id);
}
