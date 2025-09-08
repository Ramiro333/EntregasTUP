using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Data;
using proyecto_Practica01_.Data.Interfaces;
using proyecto_Practica01_.Data.Repositorios;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Services
{
    public class DetalleFacturasServicio
    {
        private IDetalleFacturaRepository _DetalleFacturaRepository;
        public DetalleFacturasServicio()
        {
            _DetalleFacturaRepository = new DetalleFacturaRepository();
        }
        public List<DetalleFactura> GetDetalleFacturas()
        {
            return _DetalleFacturaRepository.GetAll();
        }
        public DetalleFactura? GetDetalleById(int id)
        {
            return _DetalleFacturaRepository.GetById(id);
        }
        public List<DetalleFactura> GetDetallePorFactura(int id)
        {
            return _DetalleFacturaRepository.GetDetallesByFactura(id);
        }

    }
}
