using EducaMais.Domain.ValueObjects;

namespace EducaMais.Application.Dtos
{
    public class AlunoDtoResponse
    {
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public Endereco Endereco { get;  set; }
    }
}