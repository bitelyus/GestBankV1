using System;

namespace GestBankV1.src.Vista
{
    static class InterfazAdminstracion {
        public static void menu_administracion_director()
        {
            CH.cls();
            string salida = "\n";
            Console.ForegroundColor = ConsoleColor.Green;
            salida += "+------------------------------+\n";
            salida += "|   MÓDULO DE ADMINISTRACION   |\n";
            salida += "+------------------------------+\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            salida = "  *** INTERFAZ DE DIRECCIÓN ***  \n\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "1. GESTIÓN DE CLIENTES\n";
            salida += "2. GESTIÓN DE EMPLEADOS\n";
            salida += "3. GESTIÓN DE PRODUCTOS\n\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            salida = " ---- TABLAS AUXILIARES ----\n\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "4. TIPOS DE CLIENTES\n";
            salida += "5. TIPOS DE EMPLEADOS\n\n";
            salida += "0. VOLER AL MENÚ PRINCIPAL\n\n";
            Console.Write(salida);
        }

        public static void menu_administracion_cajero()
        {
            CH.cls();
            string salida = "\n";
            Console.ForegroundColor = ConsoleColor.Green;
            salida += "+------------------------------+\n";
            salida += "|   MÓDULO DE ADMINISTRACION   |\n";
            salida += "+------------------------------+\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            salida = "    * INTERFAZ DE CAJERO *    \n\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "1. REALIZAR UN INGRESO EN CUENTA\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Green;
            salida = "----------------------------------\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "2. REALIZAR UN REINTREGO EN CUENTA\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Green;
            salida = "----------------------------------\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "3. CONSULTAR DATOS CTA. DE AHORROS \n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Green;
            salida = "----------------------------------\n\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "0. VOLER AL MENÚ PRINCIPAL\n\n";
            Console.Write(salida);
        }


        public static void menu_administracion_comercial()
        {
            CH.cls();
            string salida = "\n";
            Console.ForegroundColor = ConsoleColor.Green;
            salida += "+------------------------------+\n";
            salida += "|   MÓDULO DE ADMINISTRACION   |\n";
            salida += "+------------------------------+\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            salida = "  ** INTERFAZ DE COMERCIALES **    \n\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "1. CONSULTAR PRODUCTOS CONTRATADOS\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Yellow;
            salida = "----------------------------------\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "2. CONSULTAR INFORMACIÓN DE PRODUCTOS\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Yellow;
            salida = "-------------------------------------\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "3. REALIZAR CONTRATOS CON CLIENTES/EMPLEADOS\n\n";
            salida += "0. VOLER AL MENÚ PRINCIPAL\n\n";
            Console.Write(salida);
        }
       

    }   // END CLASS
}   // END NAMESPACE