using AutoMapper;
using EducaMais.Application.Dtos;
using EducaMais.Application.Interfaces;
using EducaMais.Domain.Entities;
using EducaMais.Domain.Repositories;

namespace EducaMais.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository alunoRepository;
        private readonly IMapper mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            this.alunoRepository = alunoRepository;
            this.mapper = mapper;
        }

        public async Task<Response<AlunoDtoResponse>> AdicionaAlunoAsync(AlunoDtoRequest aluno)
        {
            try
            {
                var alunoExistente = await RetornaAlunoPorCpfAsync(aluno.Cpf);
                if(alunoExistente is not null)
                {
                    return new Response<AlunoDtoResponse>(false, "Aluno ja cadastrado", null);
                }
                return new Response<AlunoDtoResponse>(
                    true, 
                    string.Empty, 
                    mapper.Map<AlunoDtoResponse>(await alunoRepository.AdicionaAlunoAsync(mapper.Map<Aluno>(aluno))));
            }
            catch (Exception ex)
            {
                return new Response<AlunoDtoResponse>(false, ex.Message, null);
            }
        }

        public async Task<Response<AlunoDtoResponse>> AtualizaAlunoAsync(AlunoDtoRequest aluno)
        {
            try
            {
                var alunoExistente = await RetornaAlunoPorCpfAsync(aluno.Cpf);
                if (alunoExistente is null)
                {
                    return new Response<AlunoDtoResponse>(false, "Aluno não cadastrado", null);
                }
                await alunoRepository.AtualizaAlunoAsync(mapper.Map<Aluno>(aluno));
                return new Response<AlunoDtoResponse>(true,string.Empty,null);
            }
            catch (Exception ex)
            {
                return new Response<AlunoDtoResponse>(false, ex.Message, null);
            }
        }

        public async Task<Response<AlunoDtoResponse>> RemoveAlunoAsync(string cpf)
        {
            try
            {
                var alunoExistente = await RetornaAlunoPorCpfAsync(cpf);
                if (alunoExistente is null)
                {
                    return new Response<AlunoDtoResponse>(false, "Aluno não cadastrado", null);
                }
                await alunoRepository.RemoveAlunoAsync(cpf);
                return new Response<AlunoDtoResponse>(true, string.Empty, null);
            }
            catch (Exception ex)
            {
                return new Response<AlunoDtoResponse>(false, ex.Message, null);
            }
        }

        public async Task<Response<AlunoDtoResponse>> RetornaAlunoPorCpfAsync(string cpf)
        {
            try
            {
                return new Response<AlunoDtoResponse>(true, string.Empty, mapper.Map<AlunoDtoResponse>(await alunoRepository.RetornaAlunoPorCpfAsync(cpf)));
            }
            catch (Exception ex) {
                return new Response<AlunoDtoResponse>(false, ex.Message, null);
            }
        }

        public async Task<Response<AlunoDtoResponse>> RetornaTodosAlunosAsync()
        {
            try
            {
                return new Response<AlunoDtoResponse>(true, string.Empty, mapper.Map<AlunoDtoResponse>(await alunoRepository.RetornaTodosAlunosAsync()));
            }
            catch (Exception ex)
            {
                return new Response<AlunoDtoResponse>(false, ex.Message, null);
            }
        }
    }
}