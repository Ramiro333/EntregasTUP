using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Domain
{
    public class Factura
    {

        public int NroFactura {  get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetalleFactura> Detalle { get; set; }
        public override string ToString()
        {
            string detalles= String.Empty;
            double total = 0;
            foreach (DetalleFactura df in Detalle) {
                detalles += df.ToString() + "\n";
                total += df.cantidad * df.precio;
            }
            return $"Nro factura:{NroFactura}\ncliente: {Cliente.Nombre} {Cliente.Apellido}\nDetalles: \n{detalles} total = {total}";
        }
    }
}
