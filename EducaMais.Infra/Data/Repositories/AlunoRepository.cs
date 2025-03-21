using EducaMais.Domain.Entities;
using EducaMais.Domain.Repositories;
using EducaMais.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace EducaMais.Infra.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ApplicationDbContext _context;

        public AlunoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Aluno?> AdicionaAlunoAsync(Aluno aluno)
        {
            try
            {
                await _context.Alunos.AddAsync(aluno).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return aluno;
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Erro ao adicionar aluno.", ex);
            }
        }

        public async Task AtualizaAlunoAsync(Aluno aluno)
        {
            var alunoAtual = await RetornaAlunoPorCpfAsync(aluno.Cpf).ConfigureAwait(false);
            if (alunoAtual is null)
            {
                throw new KeyNotFoundException("Aluno não encontrado.");
            }

            alunoAtual.AtualizaInformacoesAluno(aluno.Nome, aluno.Email, aluno.Senha, aluno.Endereco);
            _context.Alunos.Update(alunoAtual);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task RemoveAlunoAsync(string cpf)
        {
            var alunoAtual = await RetornaAlunoPorCpfAsync(cpf).ConfigureAwait(false);
            if (alunoAtual == null)
            {
                throw new KeyNotFoundException("Aluno não encontrado.");
            }

            _context.Alunos.Remove(alunoAtual);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Aluno?> RetornaAlunoPorCpfAsync(string cpf)
        {
            return await _context.Alunos
                .AsNoTracking()  
                .FirstOrDefaultAsync(x => x.Cpf == cpf).ConfigureAwait(false);
        }

        public async Task<List<Aluno>?> RetornaTodosAlunosAsync()
        {
            return await _context.Alunos
                .AsNoTracking()  
                .ToListAsync().ConfigureAwait(false);
        }
    }
}
