using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Entities;

namespace ThomasGreg.Teste.Domain.Interfaces.Repositories
{
    public interface ILogradouroSqlServerRepository : ISqlServerRepository<Logradouro>
    {
        Task<IEnumerable<Logradouro>> GetByClienteGuid(Guid ClienteGuid);
    }
}