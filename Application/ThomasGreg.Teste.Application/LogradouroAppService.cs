using System;
using System.Threading.Tasks;
using ThomasGreg.Teste.Application.Interfaces;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Services;

namespace ThomasGreg.Teste.Application
{
    public class LogradouroAppService : ILogradouroAppService
    {
        private readonly ILogradouroService _logradouroService;

        public LogradouroAppService(ILogradouroService logradouroService)
        {
            _logradouroService = logradouroService;
        }

        public async Task<Logradouro> Add(Logradouro entity)
        {
            ValidateAdd(entity);
            
            return await _logradouroService.Add(entity);
        }

        public async Task Delete(Guid guid)
        {
            ValidateDelete(guid);

            await _logradouroService.Delete(guid);
        }

        public async Task<Logradouro> Get(Logradouro entity)
        {
            ValidateGet(entity);

            return await _logradouroService.Get(entity);
        }

        public async Task<Logradouro> Update(Logradouro entity)
        {
            ValidateUpdate(entity);

            return await _logradouroService.Update(entity);
        }

        public void ValidateAdd(Logradouro logradouro)
        {
            if (string.IsNullOrEmpty(logradouro.Nome.Trim())) throw new Exception("O logradouro precisa ser informado");            
            else if (logradouro.ClienteId.Equals(default(Guid))) throw new Exception("Informe o ClienteId");
        }

        public void ValidateDelete(Guid guid)
        {
            if (guid.Equals(default(Guid))) throw new Exception("Informe o guid.");
        }

        public void ValidateGet(Logradouro entity)
        {
            if (entity.Id.Equals(default(Guid))) throw new Exception("Informe o guid.");
        }

        public void ValidateUpdate(Logradouro entity)
        {
            if (entity.Id.Equals(default(Guid))) throw new Exception("Informe o guid.");            
            ValidateAdd(entity);
        }
    }
}