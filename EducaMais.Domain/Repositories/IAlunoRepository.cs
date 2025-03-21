using EducaMais.Domain.Entities;

namespace EducaMais.Domain.Repositories
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>?> RetornaTodosAlunosAsync();
        Task<Aluno?> RetornaAlunoPorCpfAsync(string cpf);
        Task<Aluno?> AdicionaAlunoAsync(Aluno aluno);
        Task AtualizaAlunoAsync(Aluno aluno);
        Task RemoveAlunoAsync(string cpf);
    }
}