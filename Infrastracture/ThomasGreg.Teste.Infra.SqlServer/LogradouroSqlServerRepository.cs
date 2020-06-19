using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;

namespace ThomasGreg.Teste.Infra.SqlServer
{
    public class LogradouroSqlServerRepository : SqlServerRepository<Logradouro>, ILogradouroSqlServerRepository
    {
        private readonly string _connectionString;

        public LogradouroSqlServerRepository(IConfiguration configuration) : base(configuration)
        { 
            _connectionString = configuration.GetConnectionString("SqlServer");
        }

        public override async Task<Logradouro> Add(Logradouro entity)
        {
            ProcedureName = "piLogradouro";
            Params = new { entity.Nome, entity.ClienteId };

            return await base.Add(entity);
        }

        public override async Task Delete(Guid Guid)
        {
            ProcedureName = "pdLogradouro";

            await base.Delete(Guid);
        }

        public override async Task<Logradouro> Get(Logradouro entity)
        {
            ProcedureName = "psLogradouro";
            Params = new { entity.Id };

            return await base.Get(entity);
        }

        public async Task<IEnumerable<Logradouro>> GetByClienteGuid(Guid ClienteGuid)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var logradouros = await conn.QueryAsync<Logradouro>("psLogradouroPorClienteGuid", new { ClienteGuid }, commandType: CommandType.StoredProcedure);

                return logradouros;
            }
        }

        public override async Task<Logradouro> Update(Logradouro entity)
        {
            ProcedureName = "puLogradouro";
            Params = new { entity.Id, entity.Nome, entity.ClienteId };
            
            return await base.Update(entity);
        }
    }
}