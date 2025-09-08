using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Data.Interfaces;
using proyecto_Practica01_.Data.Utilities;
using proyecto_Practica01_.Domain;

namespace proyecto_Practica01_.Data.Repositorios
{
    internal class ArticuloRepository : IArticuloRepository
    {
        public bool DeleteArticulo(int id)
        {
            bool resultado = false;
            List<ParameterSP> param = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    Name="@id_articulo",
                    Valor=id
                }
            };
            resultado = DataHelper.GetInstance().ExecuteSPNonQuery("SP_REGISTRAR_BAJA_ARTICULOS", param)>0;
            return resultado;
        }

        public List<Articulo> GetAll()
        {
            List<Articulo> lst = new List<Articulo>();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULOS");
            foreach (DataRow row in dt.Rows) 
            {
                Articulo articulo = new Articulo();
                articulo.Id_articulo = (int)row["Id_articulo"];
                articulo.Nombre = (string)row["nombre"];
                articulo.PrecioUnitario = (double)row["precioUnitario"];
                articulo.EstaActivo = (bool)row["EstaActivo"];
                articulo.Stock = (int)row["stock"];
                lst.Add(articulo);
            }
            return lst;
        }

        public Articulo? GetById(int id)
        {
            List<ParameterSP> param = new List<ParameterSP>()
            {
                new ParameterSP()
                {
                    Name="@id_articulo",
                    Valor=id
                }
            };
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULO_POR_CODIGO", param);
            if (dt != null && dt.Rows.Count > 0) 
            {
                Articulo a = new Articulo()
                {
                    Id_articulo = (int)dt.Rows[0]["Id_articulo"],
                    Nombre = (string)dt.Rows[0]["nombre"],
                    PrecioUnitario = (double)dt.Rows[0]["precioUnitario"],
                    EstaActivo = (bool)dt.Rows[0]["EstaActivo"],
                    Stock = (int)dt.Rows[0]["stock"],
                };
                return a;
            }
            return null;
        }

        public bool Save(Articulo articulo)
        {
            throw new NotImplementedException();
        }
    }
}
