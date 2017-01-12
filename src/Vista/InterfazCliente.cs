using System;

namespace GestBankV1.src.Vista
{
    static class InterfazCliente {

        public static string leerNombre()
        {
            bool salir = false;
            string aux = null;
            int opcion = 0;
            do
            {
                Console.Write("\n?> NOMBRE DEL CLIENTE: ");
                aux = Console.ReadLine();
                if (!Int32.TryParse(aux, out opcion) && aux!="")
                {
                    salir = true;
                }
                else {
                    Console.Write("!> ¿¡Perdona!?... ?@#!!");
                }
            } while (!salir);
            return aux;
        }


        public static string leerApellidos()
        {
            bool salir = false;
            string aux = null;
            int opcion = 0;
            do
            {
                Console.Write("?> APELLIDOS CLIENTE.: ");
                aux = Console.ReadLine();
                if (!Int32.TryParse(aux, out opcion) && aux != "")
                {
                    salir = true;
                }
                else {
                    CH.lcdColor("!> ¿¡Perdona!?... ?@#!!",ConsoleColor.Red);
                }
            } while (!salir);
            return aux;
        }

        public static string leerDni()
        {
            bool salir = false;
            string aux = null;
            int opcion = 0;
            do
            {
                Console.Write("?> DNI DEL CLIENTE...: ");
                aux = Console.ReadLine();
                if (!Int32.TryParse(aux, out opcion) && aux != "")
                {
                    salir = true;
                }
                else {
                    CH.lcdColor("!> ¿¡Perdona!?... ?@#!!",ConsoleColor.Red);
                }
            } while (!salir);
            return aux;
        }

        public static string leerFecha() {
            bool salir = false;
            string salida = "";
            //int opcion = 0;
            do {
                
            } while (!salir);
            return salida;
        }

    }
}