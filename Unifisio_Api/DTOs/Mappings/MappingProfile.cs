using AutoMapper;
using Unifisio_Api.Models;

namespace Unifisio_Api.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
            CreateMap<Fisioterapeuta, FisioterapeutaDTO>().ReverseMap();
            CreateMap<HistoricoClinico, HistoricoClinicoDTO>().ReverseMap();
            CreateMap<EvolucaoPaciente, EvolucaoPacienteDTO>().ReverseMap();
            CreateMap<DocumentoPaciente, DocumentoPacienteDTO>().ReverseMap();
            CreateMap<PlanoTratamento, PlanoTratamentoDTO>().ReverseMap();
            CreateMap<HorarioAtendimento, HorarioAtendimentoDTO>().ReverseMap();
        }
    }
}
