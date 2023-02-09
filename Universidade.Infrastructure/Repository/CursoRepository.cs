using Dapper;
using System.Data.SqlClient;
using Universidade.Domain.Entities;
using Universidade.Domain.Interfaces.Repository;
using Universidade.Infrastructure.Repository.Mapp;

namespace Universidade.Infrastructure.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly SqlConnection _connection;

        public CursoRepository(IDapperDbConnection dapperDbConnection)
        {
            _connection = dapperDbConnection.CreateDbConnection() as SqlConnection;
            SqlMapper.AddTypeHandler(new TipoCursoTypeHandler());
        }

        public async Task<Curso> FindAsync(int id)
        {
            var sql = "SELECT [Id], [Ativo], [DataDeCriacao], [DataDeAlteracao], [Nome], [Turno], [TipoCurso], [DepartamentoId] FROM [Cursos] WHERE [Id]=@id";
            return await _connection.QueryFirstOrDefaultAsync<Curso>(sql, new { id });
        }

        public async Task<IEnumerable<Curso>> ListAsync()
        {
            var sql = "SELECT [Id], [Ativo], [DataDeCriacao], [DataDeAlteracao],[Nome] ,[Turno] ,[TipoCurso] ,[DepartamentoId] FROM [Cursos]";
            return await _connection.QueryAsync<Curso>(sql);
        }

        public async Task<int> AddAsync(Curso Curso)
        {
            var sql = "INSERT INTO [Cursos] VALUES(@Ativo, @DataDeCriacao, @DataDeAlteracao, @Nome, @Turno, @TipoCurso);SELECT CAST(scope_identity() AS INT)";
            return await _connection.ExecuteScalarAsync<int>(sql, Curso);
        }

        public async Task AtualizarAsync(Curso Curso, int id)
        {
            Curso.DataDeAlteracao = DateTime.Now;
            var sql = "UPDATE [Cursos] SET [Ativo] = @Ativo,[DataDeAlteracao] = @DataDeAlteracao,[Nome] = @Nome,[Turno] = @Turno,[TipoCurso] = @TipoCurso WHERE Id = @id";
            await _connection.ExecuteAsync(sql, new { id, Curso.Ativo, Curso.DataDeAlteracao, Curso.Nome, Curso.Turno, Curso.TipoCurso });
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM [Cursos] WHERE [Id]=@id";
            await _connection.ExecuteAsync(sql, new { id });
        }
    }
}
