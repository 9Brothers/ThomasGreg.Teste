using System;
using System.Linq;
using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;
using ThomasGreg.Teste.Domain.Interfaces.Services;

namespace ThomasGreg.Teste.Domain.Services
{
    public class ClienteService : Service<Cliente>, IClienteService
    {
        private readonly IClienteSqlServerRepository _repository;
        private readonly ILogradouroSqlServerRepository _logradouroSqlServerRepository;

        public ClienteService(IClienteSqlServerRepository repository, ILogradouroSqlServerRepository logradouroSqlServerRepository) : base(repository)
        {
            _repository = repository;
            _logradouroSqlServerRepository = logradouroSqlServerRepository;
        }

        public override async Task<Cliente> Add(Cliente entity)
        {
            var logradouros = entity.Logradouros?.ToArray();

            entity = await base.Add(entity);

            var logradouroLength = logradouros.Length;

            for (int i = 0; i < logradouroLength; i++)
            {
                var logradouro = logradouros[i];
                logradouro.ClienteId = entity.Id;

                logradouros[i] = await _logradouroSqlServerRepository.Add(logradouro);
            }

            entity.Logradouros = logradouros;
            
            return entity;
        }

        public override async Task Delete(Guid guid)
        {
            await base.Delete(guid);
        }

        public override async Task<Cliente> Get(Cliente entity)
        {
            entity = await base.Get(entity);

            if (entity != null)
            {
                entity.Logradouros = await _logradouroSqlServerRepository.GetByClienteGuid(entity.Id);    
            }

            return entity;
        }

        public override async Task<Cliente> Update(Cliente entity)
        {
            var logradouros = entity.Logradouros.ToArray();
            
            entity = await base.Update(entity);
            
            var logradouroLength = logradouros.Length;

            for (int i = 0; i < logradouroLength; i++)
            {
                var logradouro = logradouros[i];
                logradouro.ClienteId = entity.Id;

                logradouros[i] = await _logradouroSqlServerRepository.Update(logradouro);
            }

            entity.Logradouros = logradouros;
            
            return entity;
        }
    }
}