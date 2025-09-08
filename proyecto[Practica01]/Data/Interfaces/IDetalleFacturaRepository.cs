using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Data.Interfaces
{
    internal interface IDetalleFacturaRepository
    {
        List<DetalleFactura> GetAll();
        List<DetalleFactura> GetDetallesByFactura(int id);
        DetalleFactura? GetById(int id);
        bool Save(DetalleFactura detalleFactura);
        bool DeleteDetalleFactura(int id);
    }
}
