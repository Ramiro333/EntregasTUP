using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_Practica01_.Domain
{
    public class Articulo
    {
        public int Id_articulo { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public bool EstaActivo { get; set; }
        public int Stock {  get; set; }
        public override string ToString()
        {
            return Id_articulo + " - " + Nombre + " - " + Stock + "u. - $" + PrecioUnitario+ "esta activo= "+EstaActivo;
        }

    }
}
