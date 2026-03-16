using AutoMapper;
using dgii_api.interfaces;
using dgii_api.models;

namespace dgii_api.Services
{
    public class ContribuyenteService : IContribuyenteService
    {
        private readonly IContribuyenteRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ContribuyenteService> _logger;

        public ContribuyenteService(
            IContribuyenteRepository repository,
            IMapper mapper,
            ILogger<ContribuyenteService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<ContribuyenteResponseDto> GetAll()
        {
            var contribuyentes = _repository.GetAll();
            return _mapper.Map<List<ContribuyenteResponseDto>>(contribuyentes);
        }

        public ContribuyenteResponseDto? GetById(int id)
        {
            var contribuyente = _repository.GetOne(id);

            if (contribuyente == null)
                return null;

            return _mapper.Map<ContribuyenteResponseDto>(contribuyente);
        }

        public bool Create(ContribuyenteCreateDto dto)
        {
            var exists = _repository.GetAll()
                .Any(c => c.RncCedula == dto.RncCedula);

            if (exists)
            {
                _logger.LogWarning("Intento de crear contribuyente con RNC duplicado: {Rnc}", dto.RncCedula);
                return false;
            }

            var entity = _mapper.Map<Contribuyente>(dto);

            return _repository.Create(entity);
        }

        public bool Update(int id, ContribuyenteUpdateDto dto)
        {
            var entity = _repository.GetOne(id);

            if (entity == null)
                return false;

            _mapper.Map(dto, entity);

            return _repository.Update(entity);
        }

        public bool Delete(int id)
        {
            var entity = _repository.GetOne(id);

            if (entity == null)
                return false;

            return _repository.Delete(entity);
        }
    }
}