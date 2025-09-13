using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Services.Interfaces
{
    public interface IDetalleFacturaServicio
    {
        List<DetalleFactura> GetDetalle();
        DetalleFactura? GetDetalleById(int id);
        bool saveDetalle(DetalleFactura detalleFactura);
    }
}
