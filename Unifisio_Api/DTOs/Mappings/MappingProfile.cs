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
        }
    }
}
