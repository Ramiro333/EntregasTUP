using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Data.Interfaces
{
    internal interface IFacturaRepository
    {
        List<Factura> GetAll();
        Factura? GetById(int id);
        bool Save(Factura Factura);
        bool DeleteFactura(int id);
    }
}
