using EducaMais.Application.Dtos;

namespace EducaMais.Application.Interfaces
{
    public interface IAlunoService
    {
        Task<Response<AlunoDtoResponse>> RetornaTodosAlunosAsync();
        Task<Response<AlunoDtoResponse>> RetornaAlunoPorCpfAsync(string cpf);
        Task<Response<AlunoDtoResponse>> AdicionaAlunoAsync(AlunoDtoRequest aluno);
        Task<Response<AlunoDtoResponse>> AtualizaAlunoAsync(AlunoDtoRequest aluno);
        Task<Response<AlunoDtoResponse>> RemoveAlunoAsync(string cpf);
    }
}