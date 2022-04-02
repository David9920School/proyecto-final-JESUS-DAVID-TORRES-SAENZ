using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final
{
    internal class Cajero : IClienteYBanco
    {
        string nombre = "JESUS DAVID TORRES SAENZ";
        
        public void nombreBanco()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("-----------BBVA Bancomer-----------");
            Console.WriteLine("-----------------------------------");
        }

        public void nombreCliente()
        {
            Console.WriteLine("Nombre cliente :" + nombre);
        }

        public void Ubicacon()
        {
            Console.WriteLine("Meoqui CALLE: JUAN ESCUTIA");
        }
    }
}
