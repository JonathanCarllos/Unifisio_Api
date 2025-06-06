﻿using AutoMapper;
using Unifisio_Api.Models;

namespace Unifisio_Api.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
            CreateMap<Fisioterapeuta, FisioterapeutaDTO>().ForMember(x => x.PacienteName, opt => opt.MapFrom(src => src.Paciente.Nome));
            CreateMap<HistoricoClinico, HistoricoClinicoDTO>().ReverseMap();
            CreateMap<EvolucaoPaciente, EvolucaoPacienteDTO>().ReverseMap();
            CreateMap<DocumentoPaciente, DocumentoPacienteDTO>().ReverseMap();
            CreateMap<PlanoTratamento, PlanoTratamentoDTO>().ReverseMap();
            CreateMap<HorarioAtendimento, HorarioAtendimentoDTO>().ReverseMap();
            CreateMap<ConsultaProcedimento, ConsultaProcedimentoDTO>().ReverseMap();
            CreateMap<RelatorioProdutividade, RelatorioProdutividadeDTO>().ReverseMap();
            CreateMap<AgendamentoConsulta, AgendamentoConsultaDTO>().ReverseMap();
            CreateMap<FisioterapeutaDisponibilidade, FisioterapeutaDisponibilidadeDTO>().ReverseMap();
            CreateMap<RegistroPresenca, RegistroPresencaDto>().ReverseMap();
        }
    }
}
