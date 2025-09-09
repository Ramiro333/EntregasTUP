// See https://aka.ms/new-console-template for more information
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services;
Console.WriteLine("los metodos estan comentados en program para probarlos por separado! no me dio tiempo a hacer un menu :(");
//obtener todos los articulos 
{
    //ArticuloServicio oService = new ArticuloServicio();
    //Console.WriteLine("Obtener todos los articulos - GetAll");
    //List<Articulo> la = oService.GetArticulos();
    //if (la.Count > 0)
    //    foreach (Articulo a in la)
    //    {
    //        Console.WriteLine(a.ToString());
    //    }
    //else
    //    Console.WriteLine("no hay articulos");
}

//obtener un articulo por id
{
    //Console.WriteLine("\nObtener un articulo por id - GetById");

    //Articulo? articulo2 = oService.GetArticuloById(5);
    //if (articulo2 != null)
    //{
    //    Console.WriteLine(articulo2);
    //}
    //else
    //{
    //    Console.WriteLine("No hay producto con ese id");
    //}
}

//eliminar un articulo
{ 
    //Console.WriteLine("eliminar articulo 5(deja de estar activo)");
    //if (oService.eliminarArticulo(5))
    //{
    //    Console.WriteLine("se elimino el articulo 5");
    //}
    //else
    //{
    //    Console.WriteLine("no se pudo eliminar el articulo");
    //}
}


//obtener todos los detalles
{
//Console.WriteLine("obtener todos los detalles");
//DetalleFacturasServicio oDetalleFacturaServicio = new DetalleFacturasServicio();
//List<DetalleFactura> ldf = oDetalleFacturaServicio.GetDetalleFacturas();
//if (ldf.Count > 0)
//    foreach (DetalleFactura est in ldf)
//    {
//        Console.WriteLine(est);
//    }
//else
//{
//    Console.WriteLine("no hay detalles");
//}
}


//obtener todas las facturas
{
    //FacturaServicio ofactura = new FacturaServicio();
    //List<Factura> ldf = ofactura.GetFacturas();
    //if (ldf.Count > 0)
    //    foreach (Factura f in ldf)
    //    {
    //        Console.WriteLine(f.ToString());
    //    }
    //else
    //    Console.WriteLine("no hay facturas");
}


//obtener una factura por id
{
    //FacturaServicio ofactura = new FacturaServicio();
    //Factura f = ofactura.GetFacturaById(1);
    //if (f != null)
    //{
    //    Console.WriteLine(f.ToString());
    //}
    //else
    //        Console.WriteLine("no hay detalles de factura");
}


//insertar una factura
{
    //FacturaServicio ofactura = new FacturaServicio();
    //Factura f1 = new Factura();
    //FormaPago fp1 = new FormaPago();
    //fp1.id = 1;
    //f1.FormaPago = fp1;
    //Cliente cliente = new Cliente();
    //cliente.Id = 1;
    //f1.Cliente = cliente;
    //f1.Fecha = DateTime.Now;
    //ofactura.saveFactura(f1);
    //List<Factura> ldf = ofactura.GetFacturas();
    //if (ldf.Count > 0)
    //    foreach (Factura f in ldf)
    //    {
    //        Console.WriteLine(f.ToString());
    //    }
    //else
    //    Console.WriteLine("no hay facturas");
}

//insertar detalle
{
    DetalleFacturasServicio oDetalleFactura = new DetalleFacturasServicio();
    DetalleFactura df1= new DetalleFactura();
    Articulo a1 = new Articulo();
    a1.Id_articulo = 1;
    df1.Articulo = a1;
    Factura f1 = new Factura();
    f1.NroFactura = 1;
    df1.Factura = f1;
    df1.cantidad = 2;
    df1.precio = 13400;
    oDetalleFactura.saveDetalle(df1);
    List<DetalleFactura> ldf = oDetalleFactura.GetDetalleFacturas();
    Console.WriteLine(df1.ToString());
    if (ldf.Count > 0)
        foreach (DetalleFactura est in ldf)
        {
            Console.WriteLine(est);
        }
    else
    {
        Console.WriteLine("no hay detalles");
    }

}