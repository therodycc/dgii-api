namespace dgii_api.models
{
    public class Contribuyente : Base
    {
        public string? RncCedula { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? Estatus { get; set; }
        public ICollection<ComprobanteFiscal> ComprobantesFiscales { get; set; } = new List<ComprobanteFiscal>();
    }
}