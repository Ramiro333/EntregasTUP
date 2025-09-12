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
                f.Cliente.email = (string)row["email"];
                f.Cliente.Apellido = (string)row["apellido"];
                f.Cliente.Nombre = (string)row["nombre_cliente"];
                f.Detalle = GetDetallesPorIdFactura(f.NroFactura);
                lst.Add(f);
            }
            return lst;
        }

        public Factura? GetById(int id)
        {
            List<ParameterSP> param = new List<ParameterSP>()
            {

                new ParameterSP()
                {
                    Name = "@id_factura",
                    Valor = id
                }
            };

            Factura factura = new Factura();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURA_POR_ID", param);

            if (dt != null && dt.Rows.Count > 0)
            {
                Factura f = new Factura()
                {
                    NroFactura = (int)dt.Rows[0]["id_Factura"],
                    Fecha = (DateTime)dt.Rows[0]["fecha"],
                    FormaPago = new FormaPago()
                    {
                        id = (int)dt.Rows[0]["id_forma_pago"],
                        Nombre = (string)dt.Rows[0]["formaPago"]
                    },
                    Cliente = new Cliente()
                    {
                        Id = (int)dt.Rows[0]["id_cliente"],
                        Nombre = (string)dt.Rows[0]["nombre_cliente"],
                        Apellido = (string)dt.Rows[0]["Apellido"],
                        email = (string)dt.Rows[0]["email"]
                    },
                    Detalle = GetDetallesPorIdFactura(id)
                };
                return f;
            }
            return null;
        }

        public bool Save(Factura factura)
        {
            return DataHelper.GetInstance().ExecuteTransaction(factura);
        }
        public List<DetalleFactura> GetDetallesPorIdFactura(int id)
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

    }
}
