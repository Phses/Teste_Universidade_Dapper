﻿using Universidade.Domain.Entities;

namespace Universidade.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository
    {
        Task<Endereco> FindAsync(int id);
        Task<IEnumerable<Endereco>> ListAsync();
        Task<int> AddAsync(Endereco endereco);
        Task AtualizarAsync(Endereco endereco, int id);
        Task DeleteAsync(int id);
    }
}
