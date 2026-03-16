using AutoMapper;
using dgii_api.interfaces;
using dgii_api.models;

namespace dgii_api.Services
{
    public class ComprobanteFiscalService : IComprobanteFiscalService
    {
        private readonly IComprobanteFiscalRepository _repository;
        private readonly IContribuyenteRepository _contribuyenteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ComprobanteFiscalService> _logger;

        public ComprobanteFiscalService(
            IComprobanteFiscalRepository repository,
            IContribuyenteRepository contribuyenteRepository,
            IMapper mapper,
            ILogger<ComprobanteFiscalService> logger)
        {
            _repository = repository;
            _contribuyenteRepository = contribuyenteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<ComprobanteResponseDto> GetAll()
        {
            var comprobantes = _repository.GetAll();
            return _mapper.Map<List<ComprobanteResponseDto>>(comprobantes);
        }

        public ComprobanteResponseDto? GetById(int id)
        {
            var comprobante = _repository.GetOne(id);

            if (comprobante == null)
                return null;

            return _mapper.Map<ComprobanteResponseDto>(comprobante);
        }

        public bool Create(ComprobanteCreateDto dto)
        {
            var exists = _repository.GetAll()
                .Any(c => c.NCF == dto.NCF);

            if (exists)
            {
                _logger.LogWarning("Intento de crear NCF duplicado: {NCF}", dto.NCF);
                return false;
            }

            var contribuyente = _contribuyenteRepository
                .GetAll()
                .FirstOrDefault(c => c.RncCedula == dto.RncCedula);

            if (contribuyente == null)
            {
                _logger.LogWarning("Contribuyente no encontrado para RNC {Rnc}", dto.RncCedula);
                return false;
            }

            var entity = _mapper.Map<ComprobanteFiscal>(dto);
            entity.ContribuyenteId = contribuyente.Id;

            return _repository.Create(entity);
        }

        public bool Update(int id, ComprobanteUpdateDto dto)
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

        public ContribuyenteComprobantesDto? GetComprobantesByRnc(string rnc)
        {
            var contribuyente = _contribuyenteRepository.GetByRncCedula(rnc);

            if (contribuyente == null)
            {
                _logger.LogWarning("Consulta de RNC inexistente {Rnc}", rnc);
                return null;
            }

            var comprobantes = _repository.GetByRnc(rnc);

            if (comprobantes == null || !comprobantes.Any())
            {
                return new ContribuyenteComprobantesDto
                {
                    RncCedula = contribuyente.RncCedula ?? "",
                    Nombre = contribuyente.Nombre ?? "",
                    TotalMonto = 0,
                    TotalItbis = 0,
                    Comprobantes = new List<ComprobanteResponseDto>()
                };
            }

            var comprobantesDto = _mapper.Map<List<ComprobanteResponseDto>>(comprobantes);

            return new ContribuyenteComprobantesDto
            {
                RncCedula = contribuyente.RncCedula ?? "",
                Nombre = contribuyente.Nombre ?? "",
                TotalMonto = comprobantes.Sum(x => x.Monto),
                TotalItbis = comprobantes.Sum(x => x.Itbis18),
                Comprobantes = comprobantesDto
            };
        }
    }
}