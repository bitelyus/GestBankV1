using System;

namespace GestBankV1.src.Vista
{
    static class InterfazBanka
    {
        public static void menu_principal(string nombre)
        {
            string salida = "\n";
            CH.cls();
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.BackgroundColor = ConsoleColor.Gray; 
            salida += "+==============================+\n";
            salida += "|  MENU DE OPCIONES PRINCIPAL  |\n";
            salida += "|   - - - - - - - - - - - -    |\n";
            salida += "|        GESTBANK V 1.0        |\n";
            salida += "+==============================+\n";
            Console.WriteLine(salida);
            Console.ForegroundColor = ConsoleColor.White;
            //Console.BackgroundColor = ConsoleColor.Black;
            salida = "1. MÓDULO DE ADMINISTRACIÓN";
            CH.lcd(salida);
            salida = "--------------------------------";
            CH.lcdColor(salida,ConsoleColor.DarkGray);
            salida = "2. MÓDULO PARA CLIENTES";
            CH.lcd(salida);
            salida = "--------------------------------";
            CH.lcdColor(salida,ConsoleColor.DarkGray);
            salida = "3. CARGAR DATOS MODO DEBUG\n";
            salida += "--------------------------------";
            CH.lcdColor(salida,ConsoleColor.DarkGray);
            salida = "\n0. SALIR\n\n";
            Console.Write(salida);
        }
    }
}
