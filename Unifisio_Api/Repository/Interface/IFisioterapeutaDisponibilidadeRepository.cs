using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFisioterapeutaDisponibilidadeRepository
{
    Task<List<FisioterapeutaDisponibilidade>> ObterTodosAsync();
    Task<FisioterapeutaDisponibilidade> ObterPorIdAsync(int id);
    Task AdicionarAsync(FisioterapeutaDisponibilidade disponibilidade);
    Task AtualizarAsync(FisioterapeutaDisponibilidade disponibilidade);
    Task RemoverAsync(int id);
}
