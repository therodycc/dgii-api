public class ContribuyenteComprobantesDto
{
    public string RncCedula { get; set; }
    public string Nombre { get; set; }

    public decimal TotalMonto { get; set; }
    public decimal TotalItbis { get; set; }

    public List<ComprobanteResponseDto> Comprobantes { get; set; }
}