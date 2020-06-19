using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<Usuario>
    {
        Task<Usuario> Authenticate(string username, string password);
    }
}