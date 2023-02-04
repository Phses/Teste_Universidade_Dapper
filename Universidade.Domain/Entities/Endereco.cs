
namespace Universidade.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
    }
}
