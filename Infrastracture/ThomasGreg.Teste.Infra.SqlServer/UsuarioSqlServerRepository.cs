using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;
using Dapper;
using System.Data;
using System;

namespace ThomasGreg.Teste.Infra.SqlServer
{
    public class UsuarioSqlServerRepository : SqlServerRepository<Usuario>, IUsuarioSqlServerRepository
    {
        private readonly string _connectionString;

        public UsuarioSqlServerRepository(IConfiguration configuration) : base(configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");
        }

        public override async Task<Usuario> Add(Usuario entity)
        {
            ProcedureName = "piUsuario";
            Params = new { entity.Username, entity.Password };

            return await base.Add(entity);
        }

        public override async Task Delete(Guid Guid)
        {
            ProcedureName = "pdUsuario";

            await base.Delete(Guid);
        }

        public override async Task<Usuario> Get(Usuario entity)
        {
            ProcedureName = "psUsuario";
            Params = new { entity.Username, entity.Password };

            return await base.Get(entity);
        }

        public override async Task<Usuario> Update(Usuario entity)
        {
            ProcedureName = "puUsuario";
            Params = new { entity.Id, entity.Password };

            return await base.Update(entity);
        }

        public async Task<bool> UsernameExist(string Username)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var exists = await conn.QueryFirstOrDefaultAsync<int>("psUsernameExist", new { Username }, commandType: CommandType.StoredProcedure);

                return exists == 1;
            }
        }
    }
}