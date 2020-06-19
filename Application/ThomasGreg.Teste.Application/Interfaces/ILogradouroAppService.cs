using System;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Application.Interfaces
{
    public interface ILogradouroAppService : IAppService<Logradouro>
    {
        void ValidateAdd(Logradouro logradouro);
        void ValidateDelete(Guid guid);
        void ValidateGet(Logradouro entity);
        void ValidateUpdate(Logradouro entity);
    }
}