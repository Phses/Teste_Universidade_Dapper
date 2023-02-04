
namespace Universidade.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Ativo = false;
            DataDeCriacao = DateTime.Now;
        }
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime DataDeAlteracao { get; set; }
    }
}
