using Dominio.Models;

namespace Dominio.Contratos
{
    public interface IRegisterService
    {
        Task<bool> AddRegisterAsync(Register register);
        Task<IEnumerable<Register>> GetAllAsync();
    }
}