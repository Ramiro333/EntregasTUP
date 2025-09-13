using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Data;
using proyecto_Practica01_.Data.Interfaces;
using proyecto_Practica01_.Data.Repositorios;
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services.Interfaces;

namespace proyecto_Practica01_.Services.Implementacion
{
    public class DetalleFacturasServicio : IDetalleFacturaServicio
    {
        private IDetalleFacturaRepository _DetalleFacturaRepository;
        public DetalleFacturasServicio()
        {
            _DetalleFacturaRepository = new DetalleFacturaRepository();
        }
        public List<DetalleFactura> GetDetalle()
        {
            return _DetalleFacturaRepository.GetAll();
        }
        public DetalleFactura? GetDetalleById(int id)
        {
            return _DetalleFacturaRepository.GetById(id);
        }
        public bool saveDetalle(DetalleFactura detalleFactura)
        {
            return _DetalleFacturaRepository.Save(detalleFactura);
        }
    }
}
