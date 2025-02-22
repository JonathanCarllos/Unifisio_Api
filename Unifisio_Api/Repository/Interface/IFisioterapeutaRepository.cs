using Unifisio_Api.Models;

namespace Unifisio_Api.Repository.Interface
{
    public interface IFisioterapeutaRepository
    {
        Task<IEnumerable<Fisioterapeuta>> GetAll();
        Task<IEnumerable<Fisioterapeuta>> GetFisioterapeutasPacientes();
        Task<Fisioterapeuta> GetById(int id);
        Task<Fisioterapeuta> Create(Fisioterapeuta fisioterapeuta);
        Task<Fisioterapeuta> Update(Fisioterapeuta fisioterapeuta);
        Task<Fisioterapeuta> Delete(int id);
    }
}
