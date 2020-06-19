using System;
using System.Linq;
using System.Threading.Tasks;
using ThomasGreg.Teste.Application.Interfaces;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;
using ThomasGreg.Teste.Domain.Interfaces.Services;

namespace ThomasGreg.Teste.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteSqlServerRepository _clienteSqlServerRepository;

        public ClienteAppService(IClienteService clienteService, IClienteSqlServerRepository clienteSqlServerRepository)
        {
            _clienteService = clienteService;
            _clienteSqlServerRepository = clienteSqlServerRepository;
        }

        public async Task<Cliente> Add(Cliente entity)
        {
            await ValidateAdd(entity);

            return await _clienteService.Add(entity);
        }

        public async Task Delete(Guid guid)
        {
            ValidateDelete(guid);

            await _clienteService.Delete(guid);
        }

        public async Task<Cliente> Get(Cliente entity)        
        {
            ValidateGet(entity);

            return await _clienteService.Get(entity);
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            await ValidateUpdate(entity);
            
            return await _clienteService.Update(entity);
        }

        public async Task ValidateAdd(Cliente entity)
        {
            if (string.IsNullOrEmpty(entity.Nome.Trim())) throw new Exception("Informe o nome do cliente.");
            else if (string.IsNullOrEmpty(entity.Email.Trim())) throw new Exception("Informe um email.");
            else if (!Validator.Email(entity.Email)) throw new Exception("Informe um email válido.");
            else if(await _clienteSqlServerRepository.EmailExists(entity.Email.Trim())) throw new Exception("Email já cadastrado");
            else if (string.IsNullOrEmpty(entity.Logotipo.Trim())) throw new Exception("Carregue um logotipo no formato base64.");
            else if (entity.Logradouros.Count() == 0) throw new Exception("Informe pelo menos um logradouro.");
        }

        public void ValidateDelete(Guid guid)
        {
            if (guid.Equals(default(Guid))) throw new Exception("Informe o guid.");
        }

        public void ValidateGet(Cliente entity)
        {
            if (entity.Id.Equals(default(Guid)) && !Validator.Email(entity.Email)) throw new Exception("Informe o guid ou um e-mail válido.");
        }

        public async Task ValidateUpdate(Cliente entity)
        {
            if (entity.Id.Equals(default(Guid))) throw new Exception("Informe o guid.");
            else if (string.IsNullOrEmpty(entity.Nome.Trim())) throw new Exception("Informe o nome do cliente.");
            else if (string.IsNullOrEmpty(entity.Email.Trim())) throw new Exception("Informe um email.");
            else if (!Validator.Email(entity.Email)) throw new Exception("Informe um email válido.");
            else if(!await _clienteSqlServerRepository.EmailExists(entity.Email.Trim())) throw new Exception("Email não cadastrado");
            else if (string.IsNullOrEmpty(entity.Logotipo.Trim())) throw new Exception("Carregue um logotipo no formato base64.");
            else if (entity.Logradouros.Count() == 0) throw new Exception("Informe pelo menos um logradouro.");
        }
    }
}