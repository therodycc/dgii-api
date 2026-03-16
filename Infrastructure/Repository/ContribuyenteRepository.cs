using dgii_api.data;
using dgii_api.interfaces;
using dgii_api.models;

namespace dgii_api.Repository
{
    public class ContribuyenteRepository : IContribuyenteRepository
    {
        private readonly DataContext _context;

        public ContribuyenteRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Contribuyente> GetAll()
        {
            return _context.Contribuyentes.ToList();
        }

        public Contribuyente? GetOne(int id)
        {
            return _context.Contribuyentes.FirstOrDefault(c => c.Id == id);
        }

        public Contribuyente? GetByRncCedula(string rncCedula)
        {
            return _context.Contribuyentes.FirstOrDefault(c => c.RncCedula == rncCedula);
        }

        public bool Exists(int id)
        {
            return _context.Contribuyentes.Any(c => c.Id == id);
        }

        public bool Create(Contribuyente contribuyente)
        {
            _context.Add(contribuyente);
            return Save();
        }

        public bool Update(Contribuyente contribuyente)
        {
            _context.Update(contribuyente);
            return Save();
        }

        public bool Delete(Contribuyente contribuyente)
        {
            _context.Remove(contribuyente);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}