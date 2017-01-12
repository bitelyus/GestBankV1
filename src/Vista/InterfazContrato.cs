using System;
using GestBankV1.src.Modelo;

namespace GestBankV1.src.Vista
{
    static class InterfazContrato {

         public static void listarProductosIndice(Producto[] productos) {
            string cadena = "";
            int indice = 1;

            cadena += "\nLISTADO DE PRODUCTOS POTENCIALES\n";
            cadena += "================================";
            Console.WriteLine(cadena);
            cadena = "";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0}{1} {2}{3}", "ID".PadRight(5), "NOMBRE PRODUCTO".PadRight(20), "TIPO INT.".PadRight(10),"ACTIVO".PadRight(5));
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Producto producto in productos)
            {
                Console.WriteLine("{0}{1} {2}{3}", producto.id.ToString() + ".".PadRight(4), producto.nombre.PadRight(20), producto.tipo_interes.ToString().PadLeft(8),producto.activo.ToString().PadLeft(6));
                indice++;
            }
            Console.WriteLine();
            //CH.pausa();
        }


        public static byte leerOpcionMsg(byte tope, string msg)
        {
            byte opcion = 0;
            bool salir = false;
            string aux = null;
            do
            {
                Console.Write("?> "+ msg + ": ");
                aux = Console.ReadLine();
                if (byte.TryParse(aux, out opcion))
                {
                    if (opcion > 0 && opcion <= tope)
                    {
                        salir = true;
                    }
                    else {
                        Console.WriteLine(">> OPCIÓN FUERA DE RANGO [1-" + tope + "]");
                    }

                }
                else {
                    Console.WriteLine(">> ¿¡Perdona!?... ?@#!!");
                }
            } while (!salir);
            return opcion;
        }

        public static float leerSaldo() {
            string aux;
            float saldo=0.0F;
            bool salir = false;
            do {
                try {
                    Console.Write("?> SALDO INICIAL.....: ");
                    aux = Console.ReadLine();
                    if (String.IsNullOrEmpty(aux) || float.TryParse(aux,out saldo) ) {
                        salir = true;
                    } else {
                        throw new Exception("!> Valor inválido en saldo! : Formato [9.99]");
                    }
                } catch (Exception e) {
                    CH.lcd(e.Message);
                }
            } while (!salir);


            return saldo;
        }

    }
}