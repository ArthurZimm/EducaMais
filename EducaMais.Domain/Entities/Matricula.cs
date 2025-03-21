using EducaMais.Domain.Entities.Common;

namespace EducaMais.Domain.Entities
{
    public class Matricula : BaseEntity
    {
        public Matricula(Guid alunoId, bool status, DateTime dataInicial, DateTime dataExpiracao)
        {
            AlunoId = alunoId;
            Status = status;
            DataInicial = dataInicial;
            DataExpiracao = dataExpiracao;
        }

        public Guid AlunoId { get; private set; }
        public bool Status { get; private set; }
        public DateTime DataInicial { get; private set; }
        public DateTime DataExpiracao { get; private set; }
    }
}