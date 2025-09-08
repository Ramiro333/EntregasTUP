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
    public class ArticuloServicio
    {
        private IArticuloRepository _ArticuloRepository;
        public ArticuloServicio()
        {
            _ArticuloRepository = new ArticuloRepository();
        }
        public List<Articulo> GetArticulos() 
        {
            return _ArticuloRepository.GetAll();
        }
        public Articulo? GetArticuloById(int id) 
        {
            return _ArticuloRepository.GetById(id);
        }
        public bool eliminarArticulo(int id) 
        {
            return _ArticuloRepository.DeleteArticulo(id);
        }
    }
}
