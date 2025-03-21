using System.ComponentModel.DataAnnotations;
using EducaMais.Domain.Entities.Common;
using EducaMais.Domain.ValueObjects;

namespace EducaMais.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        [Required(ErrorMessage ="O nome do aluno é obrigatório")]
        public string Nome { get; private set; }
        [EmailAddress(ErrorMessage ="O e-mail é obrigatório")]
        public string Email { get; private set; }
        [Required(ErrorMessage ="A data de nascimento é obrigatória")]
        [DataType(DataType.DateTime)]
        [CustomValidation(typeof(Aluno),(nameof(ValidaDataNascimento)))]
        public DateTime DataNascimento { get; private set; }
        [Required(ErrorMessage ="O cpf é obrigatório")]
        [StringLength(11)]
        public string Cpf { get; private set; }
        [Required(ErrorMessage ="A senha é obrigatória")]
        public string Senha { get; private set; }
        [Required(ErrorMessage ="O endereço é obrigatório")]
        public Endereco Endereco { get; private set; }

        public virtual Matricula? Matricula { get; private set; }

        public Aluno()
        {
            
        }
        public Aluno(string nome, string email, DateTime dataNascimento,string cpf, string senha, Endereco endereco)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Senha = senha;
            Endereco = endereco;
        }
        public void AdicionaMatricula(Matricula matricula)
        {
            if (Matricula != null)
            {
                throw new InvalidOperationException("Aluno já está matriculado");
            }

            Matricula = matricula;
        }
        public void AtualizaInformacoesAluno(string nome, string email, string senha, Endereco endereco)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Endereco = endereco;
        }
        public static ValidationResult? ValidaDataNascimento(DateTime dataNascimento)
        {
            return dataNascimento < DateTime.Now.AddYears(-16)
                ? new ValidationResult("É necessário ter mais de 16 anos para se cadastrar na plataforma!")
                : ValidationResult.Success;
        }
    }
}

