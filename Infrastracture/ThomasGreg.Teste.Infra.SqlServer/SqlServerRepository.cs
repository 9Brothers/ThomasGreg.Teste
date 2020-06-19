using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using ThomasGreg.Teste.Domain.Entities;
using ThomasGreg.Teste.Domain.Interfaces.Repositories;

namespace ThomasGreg.Teste.Infra.SqlServer
{
    public class SqlServerRepository<T> : ISqlServerRepository<T> where T : SqlEntity
    {
        protected string ProcedureName;
        protected object Params;
        private readonly string _connectionString;

        public SqlServerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");
        }

        public virtual async Task<T> Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = entity.CreatedAt;

            using (var conn = new SqlConnection(_connectionString))
            {
                entity = await conn.QueryFirstOrDefaultAsync<T>(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }

            return entity;
        }

        public virtual async Task Delete(Guid Guid)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.ExecuteAsync(ProcedureName, new { Guid }, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual async Task<T> Get(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cliente = await conn.QueryFirstOrDefaultAsync<T>(ProcedureName, Params, commandType: CommandType.StoredProcedure);

                return cliente;
            }
        }

        public virtual async Task<T> Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;

            using (var conn = new SqlConnection(_connectionString))
            {
                entity = await conn.QueryFirstOrDefaultAsync<T>(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }

            return entity;
        }
    }
}