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

        public IEnumerable<Departamento> FindAllWithEndereco()
        {
            var sql = "SELECT dp.Id, dp.Ativo, dp.DataDeCriacao, dp.DataDeAlteracao, dp.Nome, dp.EnderecoId, e.Id, e.Ativo, e.DataDeCriacao, e.DataDeAlteracao, e.Rua, e.Cidade, e.Estado, e.Cep, e.Complemento FROM [Departamentos] as dp INNER JOIN [Enderecos] as e ON dp.EnderecoId = e.Id ";
            return _connection.Query<Departamento, Endereco, Departamento>(sql, (p, e) => { p.endereco = e; return p; }, splitOn: "EnderecoId");
        }

        public Departamento FindWithEndereco(int id)
        {
            var sql = "SELECT dp.Id, dp.Ativo, dp.DataDeCriacao, dp.DataDeAlteracao, dp.Nome, dp.EnderecoId, e.Id, e.Ativo, e.DataDeCriacao, e.DataDeAlteracao, e.Rua, e.Cidade, e.Estado, e.Cep, e.Complemento  FROM Departamentos dp INNER JOIN Enderecos e ON dp.EnderecoId = e.Id WHERE dp.Id = @Id";
            return _connection.Query<Departamento, Endereco, Departamento>(sql, (p, e) => { p.endereco = e; return p; }, new { id }, splitOn: "EnderecoId").FirstOrDefault();
        }

        public async Task<IEnumerable<Departamento>> ListAsync()
        {
            var sql = "SELECT [Id], [Ativo], [DataDeCriacao], [DataDeAlteracao], [Nome], [EnderecoId] FROM [Departamentos]";
            return await _connection.QueryAsync<Departamento>(sql);
        }

        public async Task<int> AddAsync(Departamento departamento)
        {
            if(departamento.endereco is null)
            {
                var sqlDep = "INSERT INTO [Departamentos] VALUES(@Ativo, @DataDeCriacao, @DataDeAlteracao, @Nome, @EnderecoId);SELECT CAST(scope_identity() AS INT)";
                return await _connection.ExecuteScalarAsync<int>(sqlDep, departamento);
            }
            var sqlEnd = "INSERT INTO [Enderecos] VALUES(@Ativo, @DataDeCriacao, @DataDeAlteracao, @Rua, @Cidade, @Estado, @Cep, @Complemento);SELECT CAST(scope_identity() AS INT)";
            var enderecoId = await _connection.ExecuteScalarAsync<int>(sqlEnd, departamento.endereco);
            departamento.EnderecoId = enderecoId;
            var sql = "INSERT INTO [Departamentos] VALUES(@Ativo, @DataDeCriacao, @DataDeAlteracao, @Nome, @EnderecoId);SELECT CAST(scope_identity() AS INT)";
            return await _connection.ExecuteScalarAsync<int>(sql, departamento);
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
