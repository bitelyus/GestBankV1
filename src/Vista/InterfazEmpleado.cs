using System;
using GestBankV1.src.Modelo;

namespace GestBankV1.src.Vista
{
    static class InterfazEmpleado {

        public static void listarTiposEmpleadosIndice(TipoEmpleado[] tiposEmpleados) {
            string cadena = "";
            int indice = 1;

            cadena += "\nLISTADO DE TIPOS DE EMPLEADOS\n";
            cadena += "=============================";
            Console.WriteLine(cadena);
            cadena = "";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0}{1}", "ID".PadRight(5), "TIPO".PadRight(20));
            Console.ForegroundColor = ConsoleColor.White;

            foreach (TipoEmpleado tipoe in tiposEmpleados)
            { 
                Console.WriteLine("{0}{1}", indice.ToString() + ".".PadRight(4), tipoe.nombre.PadRight(20));
                indice++;
            }
            Console.WriteLine();
        }

    }
}