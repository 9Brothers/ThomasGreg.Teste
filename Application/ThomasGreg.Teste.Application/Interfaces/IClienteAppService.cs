using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Application.Interfaces
{
    public interface IClienteAppService : IAppService<Cliente>
    {
        Task ValidateAdd(Cliente cliente);
        Task ValidateUpdate(Cliente cliente);
        void ValidateGet(Cliente cliente);
        void ValidateDelete(System.Guid guid);
    }
}