using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Domain.Interfaces.Repositories
{
    public interface IClienteSqlServerRepository : ISqlServerRepository<Cliente>
    {
        Task<bool> EmailExists(string email);
    }
}