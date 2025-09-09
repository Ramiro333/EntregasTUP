using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Data.Interfaces;
using proyecto_Practica01_.Data.Repositorios;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Services
{
    internal class FacturaServicio
    {
        private IFacturaRepository _FacturaRepository;
        public FacturaServicio()
        {
            _FacturaRepository = new FacturaRepository();
        }
        public List<Factura> GetFacturas()
        {
            return _FacturaRepository.GetAll();
        }
        public Factura? GetFacturaById(int id)
        {
            return _FacturaRepository.GetById(id);
        }
        public bool saveFactura(Factura factura)
        {

            return _FacturaRepository.Save(factura);
        }
    }
}
