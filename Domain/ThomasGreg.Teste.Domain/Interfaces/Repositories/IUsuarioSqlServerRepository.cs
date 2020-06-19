using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Domain.Interfaces.Repositories
{
    public interface IUsuarioSqlServerRepository : ISqlServerRepository<Usuario>
    {
        Task<bool> UsernameExist(string username);
    }
}