using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidade.Domain.Entities;

namespace Universidade.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T> FindAsync(int id);
        Task<IEnumerable<T>> ListAsync();
        Task<int> AddAsync(T entity);
        Task AtualizarAsync(T entity, int id);
        Task DeleteAsync(int id);
    }
}
