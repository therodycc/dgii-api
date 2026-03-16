using dgii_api.models;

namespace dgii_api.interfaces
{
    public interface IComprobanteFiscalRepository
    {
        ICollection<ComprobanteFiscal> GetAll();
        ComprobanteFiscal? GetOne(int id);
        bool Create(ComprobanteFiscal item);
        bool Update(ComprobanteFiscal item);
        bool Delete(ComprobanteFiscal item);
        bool Exists(int id);
        ICollection<ComprobanteFiscal> GetByRnc(string rncCedula); 
        bool Save();
    }
}