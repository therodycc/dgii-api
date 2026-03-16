using dgii_api.models;

namespace dgii_api.interfaces
{
    public interface IContribuyenteRepository
    {
        ICollection<Contribuyente> GetAll();
        Contribuyente? GetOne(int id);
        bool Create(Contribuyente item);
        Contribuyente? GetByRncCedula(string rncCedula);
        bool Update(Contribuyente item);
        bool Delete(Contribuyente item);
        bool Exists(int id);
        bool Save();
    }
}