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
    internal class FacturaRepository : IFacturaRepository
    {
        public bool DeleteFactura(int id)
        {
            throw new NotImplementedException();
        }

        public List<Factura> GetAll()
        {
            List<Factura> lst = new List<Factura>();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURAS");
            foreach(DataRow row in dt.Rows)
            {
                Factura f = new Factura();
                f.NroFactura = (int)row["id_factura"];
                f.Fecha = (DateTime)row["fecha"];
                f.FormaPago = new FormaPago();
                f.FormaPago.Nombre = (string)row["formaPago"];
                f.FormaPago.id = (int)row["id_forma_pago"];
                f.Cliente = new Cliente();
                f.Cliente.Id = (int)row["id_cliente"];
                f.Detalle = new List<DetalleFactura>();
                List<ParameterSP> param = new List<ParameterSP>
                {
                    new ParameterSP
                    {
                        Name = "@id_factura",
                        Valor = f.NroFactura
                    }
                };
                var dtDetalle = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_DETALLES_POR_FACTURA", param);
                foreach (DataRow rowDetalle in dtDetalle.Rows)
                {
                    DetalleFactura df = new DetalleFactura();
                    df.idDetalleFactura = (int)rowDetalle["id_detalleFactura"];
                    df.Articulo = new Articulo();
                    df.Articulo.Id_articulo = (int)rowDetalle["id_articulo"];
                    df.Articulo.Nombre = (string)rowDetalle["nombre"];
                    df.cantidad = (int)rowDetalle["cantidad"];
                    df.precio = (double)rowDetalle["precio"];
                    f.Detalle.Add(df);
                }
                lst.Add(f);
            }
            return lst;
        }

        public Factura? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Factura detalleFactura)
        {
            throw new NotImplementedException();
        }
    }
}
