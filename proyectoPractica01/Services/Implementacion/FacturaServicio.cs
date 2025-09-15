using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Data.Interfaces;
using proyecto_Practica01_.Data.Repositorios;
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services.Interfaces;

namespace proyecto_Practica01_.Services.Implementacion
{
    public class FacturaServicio : IFacturaServicio
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
        public bool SaveFactura(Factura factura)
        {

            return _FacturaRepository.Save(factura);
        }
        public bool DeleteFactura(int id)
        
        {
            return _FacturaRepository.DeleteFactura(id);
        }
    }
}
