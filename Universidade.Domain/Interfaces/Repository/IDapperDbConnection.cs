using System.Data;


namespace Universidade.Domain.Interfaces.Repository
{
    public interface IDapperDbConnection
    {
        public IDbConnection CreateDbConnection();
    }
}
