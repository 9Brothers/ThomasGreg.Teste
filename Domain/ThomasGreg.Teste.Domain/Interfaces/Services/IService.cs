using System;
using System.Threading.Tasks;

namespace ThomasGreg.Teste.Domain.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Get(T entity);
        Task Delete(Guid guid);
    }
}