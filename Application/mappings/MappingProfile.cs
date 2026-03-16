using AutoMapper;
using dgii_api.models;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Contribuyente
        CreateMap<Contribuyente, ContribuyenteResponseDto>();
        CreateMap<ContribuyenteCreateDto, Contribuyente>();
        CreateMap<ContribuyenteUpdateDto, Contribuyente>();

        // Comprobante
        CreateMap<ComprobanteFiscal, ComprobanteResponseDto>();
        CreateMap<ComprobanteCreateDto, ComprobanteFiscal>();
        CreateMap<ComprobanteUpdateDto, ComprobanteFiscal>();
    }
}