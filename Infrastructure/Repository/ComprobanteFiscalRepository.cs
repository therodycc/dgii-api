using dgii_api.data;
using dgii_api.interfaces;
using dgii_api.models;

namespace dgii_api.Repository
{
    public class ComprobanteFiscalRepository : IComprobanteFiscalRepository
    {
        private readonly DataContext _context;

        public ComprobanteFiscalRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<ComprobanteFiscal> GetAll()
        {
            return _context.ComprobantesFiscales.ToList();
        }

        public ComprobanteFiscal? GetOne(int id)
        {
            return _context.ComprobantesFiscales.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<ComprobanteFiscal> GetByRnc(string rncCedula)
        {
            return _context.ComprobantesFiscales
                .Where(c => c.RncCedula == rncCedula)
                .ToList();
        }

        public decimal GetTotalItbisByRnc(string rncCedula)
        {
            return _context.ComprobantesFiscales
                .Where(c => c.RncCedula == rncCedula)
                .Sum(c => c.Itbis18);
        }

        public bool Exists(int id)
        {
            return _context.ComprobantesFiscales.Any(c => c.Id == id);
        }

        public bool Create(ComprobanteFiscal comprobanteFiscal)
        {
            _context.Add(comprobanteFiscal);
            return Save();
        }

        public bool Update(ComprobanteFiscal comprobanteFiscal)
        {
            _context.Update(comprobanteFiscal);
            return Save();
        }

        public bool Delete(ComprobanteFiscal comprobanteFiscal)
        {
            _context.Remove(comprobanteFiscal);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}