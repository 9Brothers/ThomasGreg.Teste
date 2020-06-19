using System;
using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;
using ThomasGreg.Teste.Domain.Interfaces.Services;

namespace ThomasGreg.Teste.Domain.Services
{
    public class LogradouroService : Service<Logradouro>, ILogradouroService
    {
        private readonly ILogradouroSqlServerRepository _logradouroSqlServerRepository;

        public LogradouroService(ILogradouroSqlServerRepository repository) : base(repository)
        {
            _logradouroSqlServerRepository = repository;
        }
    }
}