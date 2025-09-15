using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Services.Interfaces
{
    public interface IFacturaServicio
    {
        List<Factura> GetFacturas();
        Factura? GetFacturaById(int id);
        bool SaveFactura(Factura factura);
        bool DeleteFactura(int id);
    }
}
