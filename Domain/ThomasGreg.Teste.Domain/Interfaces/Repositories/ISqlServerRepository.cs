using System.Threading.Tasks;

namespace ThomasGreg.Teste.Domain.Interfaces.Repositories
{
    public interface ISqlServerRepository<T> : IRepository<T> where T : class
    {
    
    }
}