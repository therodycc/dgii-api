
namespace dgii_api.Services
{
    public interface IContribuyenteService
    {
        IEnumerable<ContribuyenteResponseDto> GetAll();

        ContribuyenteResponseDto? GetById(int id);

        bool Create(ContribuyenteCreateDto dto);

        bool Update(int id, ContribuyenteUpdateDto dto);

        bool Delete(int id);
    }
}