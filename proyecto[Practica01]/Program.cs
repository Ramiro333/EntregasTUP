// See https://aka.ms/new-console-template for more information
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services;

Console.WriteLine("Hello, World!");
ArticuloServicio oService = new ArticuloServicio();
Console.WriteLine("Obtener todos los articulos - GetAll");
List<Articulo> la = oService.GetArticulos();
if (la.Count > 0)
    foreach (Articulo a in la)
    {
        Console.WriteLine(a.ToString());
    }
else
    Console.WriteLine("no hay articulos");

Console.WriteLine("\nObtener un articulo por id - GetById");

Articulo? articulo2 = oService.GetArticuloById(5);
if (articulo2 != null)
{
    Console.WriteLine(articulo2);
}
else
{
    Console.WriteLine("No hay producto con ese id");
}

Console.WriteLine("eliminar articulo 5(deja de estar activo)");
if (oService.eliminarArticulo(5))
{
    Console.WriteLine("se eliomino el articulo 5");
}
else
{
    Console.WriteLine("no se pudo eliminar el articulo");
}
