using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Data.Interfaces
{
    internal interface IArticuloRepository
    {
        List<Articulo> GetAll();
        Articulo? GetById(int id);
        bool Save(Articulo articulo);
        bool DeleteArticulo(int id);
    }
}
