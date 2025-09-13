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
    public class ArticuloServicio : IArticuloService
    {
        private IArticuloRepository _ArticuloRepository;
        public ArticuloServicio()
        {
            _ArticuloRepository = new ArticuloRepository();
        }

        public bool Create(Articulo articulo)
        {
            return _ArticuloRepository.Save(articulo);
        }

        public List<Articulo> GetAll()
        {
            return _ArticuloRepository.GetAll();
        }

        public bool Update(Articulo articulo)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            return _ArticuloRepository.DeleteArticulo(id);
        }

        public Articulo GetById(int id)
        {
            return _ArticuloRepository.GetById(id);
        }
    }
}
