namespace dgii_api.Services
{
    public interface IComprobanteFiscalService
    {
        IEnumerable<ComprobanteResponseDto> GetAll();

        ComprobanteResponseDto? GetById(int id);

        bool Create(ComprobanteCreateDto dto);

        bool Update(int id, ComprobanteUpdateDto dto);

        bool Delete(int id);
        ContribuyenteComprobantesDto? GetComprobantesByRnc(string rnc);
    }
}