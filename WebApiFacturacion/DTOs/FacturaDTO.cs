namespace WebApiFacturacion.DTOs
{
    public class FacturaDTO
    {
        
    public DateTime Fecha { get; set; }
        public int IdFormaPago { get; set; }
        public int IdCliente { get; set; }
        public List<DetalleDTO> Detalle { get; set; }
    
    }
}
