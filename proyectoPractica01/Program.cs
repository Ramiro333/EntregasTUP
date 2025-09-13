//See https://aka.ms/new-console-template for more information
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services.Implementacion;

FacturaServicio ofactura = new FacturaServicio();
ArticuloServicio articuloServicio = new ArticuloServicio();
bool salir = false;

while (!salir)
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("   SISTEMA DE FACTURACIÓN v1.0   ");
    Console.WriteLine("=================================");
    Console.WriteLine("1) obtener todas las facturas");
    Console.WriteLine("2) obtener una factura por id");
    Console.WriteLine("3) Crear Factura");
    Console.Write("\nSeleccione una opción: ");

    string input = Console.ReadLine()?.Trim();


    switch (input)
    {
        case "1":
            List<Factura> ldf = ofactura.GetFacturas();
            if (ldf.Count > 0)
                foreach (Factura f in ldf)
                {
                    Console.WriteLine(f.ToString());
                }

            else
            {
                Console.WriteLine("no hay facturas");
            }
            Console.WriteLine("presione una tecla para seguir");
            Console.ReadKey();
            break;
        case "2":
            Console.WriteLine("ingrese el id de la factura");
            int idFactura = Convert.ToInt32(Console.ReadLine());
            Factura? f1 = ofactura.GetFacturaById(idFactura);
            if (f1 != null)
            {
                Console.WriteLine(f1.ToString());
            }
            else
            {
                Console.WriteLine("no existe la factura");
            }
            Console.WriteLine("presione una tecla para seguir");
            Console.ReadKey();
            break;
        //
        case "3":
            Console.WriteLine("Ingrese el id de la forma de pago:");
            int idFormaPago = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el id del cliente:");
            int idCliente = Convert.ToInt32(Console.ReadLine());
            Factura nuevaFactura = new Factura(idFormaPago, idCliente);
            bool agregarMas = true;
            while (agregarMas)
            {
                Console.WriteLine("Seleccione un artículo");
                Console.WriteLine("Artículos disponibles:");
                List<Articulo> lsArticulos = articuloServicio.GetAll();
                int contador = 1;
                foreach (Articulo a in lsArticulos)
                {
                    Console.WriteLine($"{contador} - {a.Nombre} (Precio: {a.PrecioUnitario})");
                    contador++;
                }
                Console.WriteLine("Ingrese el número del artículo elegido:");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Articulo articuloElegido = lsArticulos[opcion - 1];
                Console.WriteLine("Ingrese la cantidad:");
                int cantidad = Convert.ToInt32(Console.ReadLine());
                DetalleFactura detalle = new DetalleFactura()
                {
                    Articulo = articuloElegido,
                    cantidad = cantidad,
                    precio = articuloElegido.PrecioUnitario,
                    Factura = nuevaFactura
                };
                nuevaFactura.Detalle.Add(detalle);
                Console.WriteLine("¿Desea agregar otro artículo? (s/n)");
                string resp = Console.ReadLine();
                agregarMas = resp.ToLower() == "s";
            }
            bool ok = ofactura.saveFactura(nuevaFactura);
            if (ok)
            {
                Console.WriteLine("Factura guardada correctamente.");
            }
            else
            {
                Console.WriteLine("Error al guardar la factura.");
            }
            Console.WriteLine("Presione una tecla para seguir...");
            Console.ReadKey();
            break;
        case "0":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción inválida, presione una tecla para continuar...");
            Console.ReadKey();
            break;
    }
}
