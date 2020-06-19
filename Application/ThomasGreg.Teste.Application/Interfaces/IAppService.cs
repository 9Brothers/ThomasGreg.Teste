using System;
using System.Threading.Tasks;

namespace ThomasGreg.Teste.Application.Interfaces
{
    public interface IAppService<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Get(T entity);
        Task Delete(Guid guid);
        
    }
}