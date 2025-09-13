using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Services.Interfaces
{
    public interface IArticuloService
    {
        bool Create(Articulo articulo);
        List<Articulo> GetAll();
        bool Update(Articulo articulo);
        bool Delete(int id);
        Articulo? GetById(int id);
    }
}
