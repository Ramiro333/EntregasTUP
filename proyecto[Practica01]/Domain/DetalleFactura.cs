using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Domain
{
    public class DetalleFactura
    {
        public int idDetalleFactura {  get; set; }
        public Articulo Articulo { get; set; }
        public Factura Factura { get; set; }
        public int cantidad {  get; set; }
        public double precio { get; set; }
        public override string ToString()
        {
            return "id factura: "+Factura.NroFactura+ " id detalle = " + idDetalleFactura+ " monto = "+ cantidad* precio + "Articulo = " + Articulo.Nombre;
        }
    }
}
