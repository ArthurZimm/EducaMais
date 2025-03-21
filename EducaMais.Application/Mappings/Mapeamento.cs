using AutoMapper;
using EducaMais.Application.Dtos;
using EducaMais.Domain.Entities;

namespace EducaMais.Application.Mappings
{
    public class Mapeamento : Profile
    {
        public Mapeamento()
        {
            CreateMap<AlunoDtoRequest,Aluno>();
            CreateMap<Aluno, AlunoDtoResponse>();
        }
    }
}