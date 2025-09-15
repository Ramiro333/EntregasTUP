namespace WebApiFacturacion.DTOs
{
    public class DetalleDTO
    {
        public int IdDetalleFactura { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
