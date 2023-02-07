

namespace Universidade.Domain.Entities
{
    public class Departamento : BaseEntity
    {
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public Endereco endereco { get; set; }
    }
}
