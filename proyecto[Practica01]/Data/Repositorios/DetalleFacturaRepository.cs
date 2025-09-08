using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Data.Interfaces;
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Data.Utilities;
using System.Data;

namespace proyecto_Practica01_.Data.Repositorios
{
    internal class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        public bool DeleteDetalleFactura(int id)
        {
            throw new NotImplementedException();
        }

        public List<DetalleFactura> GetAll()
        {
            List<DetalleFactura> lst = new List<DetalleFactura>();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_DETALLES_FACTURAS");
            foreach (DataRow row in dt.Rows) 
            {
                DetalleFactura df = new DetalleFactura();
                df.idDetalleFactura = (int)row["id_detalleFactura"];
                df.Articulo = new Articulo();
                df.Articulo.Id_articulo = (int)row["id_articulo"];
                df.Articulo.Nombre = (string)row["nombre"];
                df.Factura = new Factura();
                df.Factura.NroFactura = (int)row["id_factura"];
                df.cantidad = (int)row["cantidad"];
                df.precio = (double)row["precio"];
                lst.Add(df);
            }
            return lst;
        }

        public DetalleFactura? GetById(int id)
        {
            List<ParameterSP> param = new List<ParameterSP>();
            {
                new ParameterSP()
                {
                    Name = "@id_detalle_factura",
                    Valor = id
                };
            }
                var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_DETALLES_FACTURAS_POR_CODIGO", param);
                if (dt != null && dt.Rows.Count > 0)
                {
                DetalleFactura df = new DetalleFactura()
                    {
                        idDetalleFactura = (int)dt.Rows[0]["id_detalleFactura"],
                        Articulo = new Articulo()
                        {
                            Id_articulo = (int)dt.Rows[0]["id_articulo"],
                            Nombre = (string)dt.Rows[0]["nombre"]
                        },
                        Factura = new Factura()
                        {
                            NroFactura = (int)dt.Rows[0]["id_factura"]
                        },
                        cantidad = (int)dt.Rows[0]["cantidad"],
                        precio = (float)dt.Rows[0]["precio"],
                    };
                    return df;
                }
                return null;
        }

        public List<DetalleFactura> GetDetallesByFactura(int id)
        {
            List<ParameterSP> param = new List<ParameterSP>
            {
                new ParameterSP
                {
                    Name = "@id_factura",
                    Valor = id
                }
            };
            List<DetalleFactura> lst = new List<DetalleFactura>();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_DETALLES_POR_FACTURA", param);
            foreach (DataRow row in dt.Rows)
            {
                DetalleFactura df = new DetalleFactura();
                df.idDetalleFactura = (int)row["id_detalleFactura"];
                df.Articulo = new Articulo();
                df.Articulo.Id_articulo = (int)row["id_articulo"];
                df.Articulo.Nombre = (string)row["nombre"];
                df.Factura = new Factura();
                df.Factura.NroFactura = (int)row["id_factura"];
                df.cantidad = (int)row["cantidad"];
                df.precio = (double)row["precio"];
                lst.Add(df);
            }
            return lst;
        }

        

        public bool Save(DetalleFactura detalleFactura)
        {
            throw new NotImplementedException();
        }
    }
}
