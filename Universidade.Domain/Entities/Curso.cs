using Universidade.Domain.Enums;

namespace Universidade.Domain.Entities
{
    public class Curso : BaseEntity
    {
        public string Nome { get; set; }
        public string Turno { get; set; }
        public TipoCurso Tipo { get; set; }

        public int DepartamentoId { get; set; }
    }
}