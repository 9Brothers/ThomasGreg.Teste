using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Application.Interfaces
{
    public interface IUsuarioAppService : IAppService<Usuario>
    {
        Task ValidateAdd(Usuario usuario);
        Task ValidateUpdate(Usuario usuario);
        void ValidateGet(Usuario usuario);
        void ValidateDelete(System.Guid guid);
        Task<Usuario> Authenticate(Usuario usuario);
        void ValidateAuthenticate(Usuario usuario);
    }
}