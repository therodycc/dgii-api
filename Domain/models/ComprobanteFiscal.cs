
namespace dgii_api.models
{
    public class ComprobanteFiscal : Base
    {
        public string? RncCedula { get; set; }
        public string? NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }
        public int ContribuyenteId { get; set; }
        public Contribuyente? Contribuyente { get; set; }
    }
}