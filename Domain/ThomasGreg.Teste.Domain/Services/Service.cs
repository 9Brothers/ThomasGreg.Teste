using System;
using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;
using ThomasGreg.Teste.Domain.Interfaces.Services;

namespace ThomasGreg.Teste.Domain.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> Add(T entity)
        {
            return await _repository.Add(entity);
        }

        public virtual async Task Delete(Guid guid)
        {
            await _repository.Delete(guid);
        }

        public virtual async Task<T> Get(T entity)
        {
            return await _repository.Get(entity);
        }

        public virtual async Task<T> Update(T entity)
        {
            return await _repository.Update(entity);
        }
    }
}