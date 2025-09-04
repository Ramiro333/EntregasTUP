using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Data;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Services
{
    public class ArticuloServicio
    {
        private IArticuloRepository _Repository;
        public ArticuloServicio()
        {
            _Repository = new ArticuloRepository();
        }
        public List<Articulo> GetArticulos() 
        {
            return _Repository.GetAll();
        }
        public Articulo? GetArticuloById(int id) 
        {
            return _Repository.GetById(id);
        }
        public bool eliminarArticulo(int id) 
        {
            return _Repository.DeleteArticulo(id);
        }
    }
}
