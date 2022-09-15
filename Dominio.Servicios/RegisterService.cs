using Dominio.Contratos;
using Dominio.Models;
using System.Data.SqlTypes;

namespace Dominio.Servicios
{
    public class RegisterService : IRegisterService
    {
        public async Task<bool> AddRegisterAsync(Register register)
        {
            return true;
        }

        public async Task<IEnumerable<Register>> GetAllAsync()
        {
            List<Register> list = new List<Register>();
            list.Add(new Register() { Email = "maria@hotmail.com" , LastName="Chávez",FirstName="Díaz"});

            return list.ToList();
        }
    }
}