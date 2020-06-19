using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;
using ThomasGreg.Teste.Domain.Interfaces.Services;

namespace ThomasGreg.Teste.Domain.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        private readonly IUsuarioSqlServerRepository _usuarioSqlServerRepository;

        public UsuarioService(IUsuarioSqlServerRepository usuarioSqlServerRepository) : base(usuarioSqlServerRepository)
        {
            _usuarioSqlServerRepository = usuarioSqlServerRepository;
        }

        public async Task<Usuario> Authenticate(string username, string password)
        {
            var usuario = await _usuarioSqlServerRepository.Get(new Usuario { Username = username, Password = password });

            if (usuario == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Username),
                    new Claim("ThomasGreg", usuario.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuario.Token = tokenHandler.WriteToken(token);

            usuario.Password = null;

            return usuario;
        }
    }
}