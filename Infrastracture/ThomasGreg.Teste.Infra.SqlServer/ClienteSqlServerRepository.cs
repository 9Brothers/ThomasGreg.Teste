using System;
using System.Threading.Tasks;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data;

namespace ThomasGreg.Teste.Infra.SqlServer
{
    public class ClienteSqlServerRepository : SqlServerRepository<Cliente>, IClienteSqlServerRepository
    {
        private readonly string _connectionString;

        public ClienteSqlServerRepository(IConfiguration configuration) : base(configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");
        }

        public override async Task<Cliente> Add(Cliente entity)
        {
            ProcedureName = "piCliente";
            Params = new { entity.Nome, entity.Email, entity.Logotipo };

            return await base.Add(entity);
        }

        public override async Task Delete(Guid Guid)
        {
            ProcedureName = "pdCliente";
            
            await base.Delete(Guid);
        }

        public async Task<bool> EmailExists(string Email)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync("psEmailClienteExist", new { Email }, commandType: CommandType.StoredProcedure);

                return result.Count() == 1;
            }
        }

        public override async Task<Cliente> Get(Cliente entity)
        {
            ProcedureName = "psCliente";
            Params = new { entity.Id, entity.Email };

            return await base.Get(entity);
        }

        public override async Task<Cliente> Update(Cliente entity)
        {
            ProcedureName = "puCliente";
            Params = new { entity.Id, entity.Nome, entity.Email, entity.Logotipo };

            return await base.Update(entity);
        }
    }
}