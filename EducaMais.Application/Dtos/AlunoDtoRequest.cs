using EducaMais.Domain.ValueObjects;

namespace EducaMais.Application.Dtos
{
    public class AlunoDtoRequest
    {
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Cpf { get;  set; }
        public string Senha { get;  set; }
        public Endereco Endereco { get;  set; }
    }
}
