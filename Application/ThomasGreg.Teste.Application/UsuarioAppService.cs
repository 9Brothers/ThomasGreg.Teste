using System;
using System.Threading.Tasks;
using ThomasGreg.Teste.Application.Interfaces;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;
using ThomasGreg.Teste.Domain.Interfaces.Services;

namespace ThomasGreg.Teste.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioSqlServerRepository _usuarioSqlServerRepository;

        public UsuarioAppService(IUsuarioService usuarioService, IUsuarioSqlServerRepository usuarioSqlServerRepository)
        {
            _usuarioService = usuarioService;
            _usuarioSqlServerRepository = usuarioSqlServerRepository;
        }

        public async Task<Usuario> Add(Usuario entity)
        {
            await ValidateAdd(entity);

            return await _usuarioService.Add(entity);
        }

        public async Task<Usuario> Authenticate(Usuario usuario)
        {
            ValidateAuthenticate(usuario);

            return await _usuarioService.Authenticate(usuario.Username, usuario.Password);
        }

        public async Task Delete(Guid guid)
        {
            ValidateDelete(guid);

            await _usuarioService.Delete(guid);
        }

        public async Task<Usuario> Get(Usuario entity)
        {
            ValidateGet(entity);

            return await _usuarioService.Get(entity);
        }

        public async Task<Usuario> Update(Usuario entity)
        {
            await ValidateUpdate(entity);

            return await _usuarioService.Update(entity);
        }

        public async Task ValidateAdd(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Username?.Trim())) throw new Exception("Informe um nome de usuário.");
            else if (await _usuarioSqlServerRepository.UsernameExist(usuario.Username)) throw new Exception("Usuário já cadastrado.");
            else if (string.IsNullOrEmpty(usuario.Password?.Trim())) throw new Exception("Informe uma senha.");
        }

        public void ValidateAuthenticate(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Username?.Trim()) || string.IsNullOrEmpty(usuario.Password?.Trim())) throw new Exception("Informe o username e a senha.");
        }

        public void ValidateDelete(Guid guid)
        {
            if (guid.Equals(default(Guid))) throw new Exception("Informe o guid.");
        }

        public void ValidateGet(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Username.Trim()) || string.IsNullOrEmpty(usuario.Password.Trim())) throw new Exception("O nome de usuário e a senha precisam ser preenchidos.");
        }

        public async Task ValidateUpdate(Usuario usuario)
        {
            if (usuario.Id.Equals(default(Guid))) throw new Exception("Informe o id do usuário");
            else if (!string.IsNullOrEmpty(usuario.Username?.Trim())) throw new Exception("Não é possível alterar o username.");
            else if (string.IsNullOrEmpty(usuario.Password?.Trim())) throw new Exception("Informe uma senha.");
        }
    }
}