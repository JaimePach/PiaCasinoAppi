using AutoMapper;
using PiaCasinoAppi.DTOs;
using PiaCasinoAppi.Entidades;

namespace PiaCasinoAppi.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
      
        public AutoMapperProfiles()
        {

            CreateMap<Boleto, GetBoletosDTO>();
            CreateMap<CreacionBoletoDTO, Boleto>();
            CreateMap<Participante, GetParticipantesDTO>();
            CreateMap<CreacionParticipanteDTO, Participante>();
            CreateMap<Premio, GetPremioDTO>();
            CreateMap<CreacionPremioDTO, Premio>();
            CreateMap<Rifa, GetRifaDTO>();
            CreateMap<CreacionRifaDTO, Rifa>();

        }
    }
}
