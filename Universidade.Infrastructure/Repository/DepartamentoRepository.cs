using Dapper;
using System.Data.SqlClient;
using Universidade.Domain.Entities;
using Universidade.Domain.Interfaces.Repository;

namespace Universidade.Infrastructure.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly SqlConnection _connection;

        public DepartamentoRepository(IDapperDbConnection dapperDbConnection)
        {
            _connection = dapperDbConnection.CreateDbConnection() as SqlConnection;
        }

        public async Task<Departamento> FindAsync(int id)
        {
            var sql = "SELECT [Id], [Ativo], [DataDeCriacao], [DataDeAlteracao], [Nome], [EnderecoId] FROM [Departamentos] WHERE [Id]=@id";
            return await _connection.QueryFirstOrDefaultAsync<Departamento>(sql, new { id });
        }

        public async Task<IEnumerable<Departamento>> ListAsync()
        {
            var sql = "SELECT [Id], [Ativo], [DataDeCriacao], [DataDeAlteracao], [Nome], [EnderecoId] FROM [Departamentos]";
            return await _connection.QueryAsync<Departamento>(sql);
        }

        public async Task<int> AddAsync(Departamento Departamento)
        {
            var sql = "INSERT INTO [Departamentos] VALUES(@Ativo, @DataDeCriacao, @DataDeAlteracao, @Nome, @EnderecoId);SELECT CAST(scope_identity() AS INT)";
            return await _connection.ExecuteScalarAsync<int>(sql, Departamento);
        }

        public async Task AtualizarAsync(Departamento Departamento, int id)
        {
            Departamento.DataDeAlteracao = DateTime.Now;
            var sql = "UPDATE [Departamentos] SET [Ativo] = @Ativo,[DataDeAlteracao] = @DataDeAlteracao,[Nome] = @Nome,[EnderecoId] = @EnderecoId WHERE Id = @id";
            await _connection.ExecuteAsync(sql, new { id, Departamento.Ativo, Departamento.DataDeAlteracao, Departamento.Nome, Departamento.EnderecoId });
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM [Departamentos] WHERE [Id]=@id";
            await _connection.ExecuteAsync(sql, new { id });
        }
    }
}
