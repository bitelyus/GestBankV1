using System;
using GestBankV1.src.Modelo;
namespace GestBankV1.src.Vista

{
    static class InterfazDireccion
    {

        public static void mostrar_menu_clientes()
        {
            CH.cls();
            string salida = "\n";
            Console.ForegroundColor = ConsoleColor.Green;
            salida += "+------------------------------+\n";
            salida += "|   MÓDULO DE ADMINISTRACION   |\n";
            salida += "+------------------------------+\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            salida = "  *** INTERFAZ DE DIRECCIÓN ***  \n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            salida = "     * GESTIÓN DE CLIENTES *    \n\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "1. REGISTRAR NUEVO CLIENTE\n";
            salida += "2. CONSULTAR DATOS CLIENTE\n";
            salida += "3. MODIFICAR DATOS CLIENTE\n";
            salida += "4. ELIMINAR UN CLIENTE\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            salida = "----------------------------\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;            
            salida = "5. LISTAR TODOS LOS CLIENTES\n\n";
            salida += "0. VOLER AL MENÚ PRINCIPAL\n\n";
            Console.Write(salida);
        }

 public static void mostrar_menu_empleados()
        {
            CH.cls();
            string salida = "\n";
            Console.ForegroundColor = ConsoleColor.Green;
            salida += "+------------------------------+\n";
            salida += "|   MÓDULO DE ADMINISTRACION   |\n";
            salida += "+------------------------------+\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            salida = "  *** INTERFAZ DE DIRECCIÓN ***  \n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            salida = "    * GESTIÓN DE EMPLEADOS  *    \n\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "1. REGISTRAR NUEVO EMPLEADO\n";
            salida += "2. CONSULTAR DATOS EMPLEADO\n";
            salida += "3. MODIFICAR DATOS EMPLEADO\n";
            salida += "4. ELIMINAR UN EMPLEADO\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            salida = "-----------------------------\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;            
            salida = "5. LISTAR TODOS LOS EMPLEADOS\n\n";
            salida += "0. VOLER AL MENÚ PRINCIPAL\n\n";
            Console.Write(salida);
        }

        public static void mostrar_menu_productos()
        {
            CH.cls();
            string salida = "\n";
            Console.ForegroundColor = ConsoleColor.Green;
            salida += "+------------------------------+\n";
            salida += "|   MÓDULO DE ADMINISTRACION   |\n";
            salida += "+------------------------------+\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            salida = "  *** INTERFAZ DE DIRECCIÓN ***  \n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            salida = "    * GESTIÓN DE PRODUCTOS  *    \n\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;
            salida = "1. C. - CONSULT > UN PRODUCTO\n";
            salida += "2. R. - REGISTR > UN NUEVO PRODUCTO\n";
            salida += "3. U. - UPDATE > MODIFICAR UN PRODUCTO\n";
            salida += "4. D. - DELETE > BORRAR UN PRODCUTO\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            salida = "-----------------------------\n";
            Console.Write(salida);
            Console.ForegroundColor = ConsoleColor.Gray;            
            salida = "5. LISTAR TODOS LOS PRODUCTOS\n\n";
            salida += "0. VOLER AL MENÚ PRINCIPAL\n\n";
            Console.Write(salida);
        }

        public static void listarClientes(Cliente[] clientes)
        {
            string cadena = "";
            Empleado empleado = null;
            CH.cls();
            cadena += "\nLISTADO DE CLIENES GESTBANKV1\n";
            cadena += "=============================";
            Console.WriteLine(cadena);
            cadena = "";
            if (clientes == null)
            {
                Console.WriteLine("LA BANKA TODAVÍA NO TIENE CLIENTES\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0} {1}{2}", "APELLIDOS".PadRight(20), "NOMBRE".PadRight(15), "D.N.I.  ".PadRight(10));
                Console.ForegroundColor = ConsoleColor.White;

                foreach (Cliente cliente in clientes)
                {   
                    if (cliente is Empleado) {
                        empleado = (Empleado) cliente;
                        Console.WriteLine("{0} {1}{2}", empleado.cliente.apellidos.PadRight(20), empleado.cliente.nombre.PadRight(15), empleado.cliente.dni.PadRight(10));
                    } else {
                        Console.WriteLine("{0} {1}{2}", cliente.apellidos.PadRight(20), cliente.nombre.PadRight(15), cliente.dni.PadRight(10));
                    }
                }
            }
            CH.pausa();
        }

        public static void listarEmpleados(Empleado[] empleados)
        {
            string cadena = "";
            CH.cls();
            cadena += "\nLISTADO DE EMPLEADOS GESTBANKV1\n";
            cadena += "===============================";
            CH.lcdColor(cadena,ConsoleColor.DarkBlue);
            cadena = "";
            if (empleados != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0}{1}{2}{3}", "APELLIDOS".PadRight(20), "NOMBRE".PadRight(15), "D.N.I.  ".PadRight(10),"CARGO".PadRight(10));
                Console.ForegroundColor = ConsoleColor.White;

                foreach (Empleado empleado in empleados)
                {
                    //CH.lcd(empleado.ToString()); -- COMO COÑO LLEGO AL los datos del cliente heredado....!! 
                    Console.WriteLine("{0}{1}{2}{3}", empleado.cliente.apellidos.PadRight(20), empleado.cliente.nombre.PadRight(15), empleado.cliente.dni.PadRight(10),empleado.tipo_empleado.nombre.PadRight(10));
                }
            }
            else
            {
                 Console.WriteLine("LA BANKA TODAVÍA NO TIENE EMPLEADOS\n");
            }
            CH.pausa();
        }

        public static void listarClientesIndice(Cliente[] clientes)
        {
            string cadena = "";
            int indice = 1;
            int numc;

            CH.cls();
            cadena += "\nLISTADO DE CLIENES GESTBANKV1\n";
            cadena += "=============================";
            Console.WriteLine(cadena);
            cadena = "";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0}{1} {2}{3}{4}", "ID".PadRight(5), "APELLIDOS".PadRight(20), "NOMBRE".PadRight(15), "D.N.I.  ".PadRight(10),"CONTRATOS".PadRight(5));
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Cliente cliente in clientes)
            {
                numc=0;
                if (cliente.lista_contratos!=null) {
                    numc = cliente.lista_contratos.Length;
                }
                Console.WriteLine("{0}{1} {2}{3}{4}", indice.ToString() + ".".PadRight(4), cliente.apellidos.PadRight(20), cliente.nombre.PadRight(15), cliente.dni.PadRight(10),numc.ToString().PadLeft(9));
                indice++;
            }
            Console.WriteLine();

        }

public static void listarEmpleadosIndice(Empleado[] empleados)
        {
            string cadena = "";
            int indice = 1;
            CH.cls();
            cadena += "\nLISTADO DE EMPLEADOS GESTBANKV1\n";
            cadena += "===============================";
            CH.lcdColor(cadena,ConsoleColor.DarkBlue);
            cadena = "";
            if (empleados != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0}{1}{2}{3}{4}","ID". PadRight(5),"APELLIDOS".PadRight(20), "NOMBRE".PadRight(15), "D.N.I.  ".PadRight(10),"CARGO".PadRight(10));
                Console.ForegroundColor = ConsoleColor.White;

                foreach (Empleado empleado in empleados)
                {
                    //CH.lcd(empleado.ToString()); -- COMO COÑO LLEGO AL los datos del cliente heredado....!! 
                    Console.WriteLine("{0}{1}{2}{3}{4}", indice.ToString() + ".".PadRight(4),empleado.cliente.apellidos.PadRight(20), empleado.cliente.nombre.PadRight(15), empleado.cliente.dni.PadRight(10),empleado.tipo_empleado.nombre.PadRight(10));
                    indice++;
                }
            }
            else
            {
                 Console.WriteLine("LA BANKA TODAVÍA NO TIENE EMPLEADOS\n");
                 CH.pausa();
            }
        }
        // FUNCIÓN QUE DEVUELTE EL INDICE DE UN CLIENTE LISTADO
        public static int pedirCliente(int tope, string msg)
        {
            int opcion = 0;
            bool salir = false;
            string aux = null;
            do
            {
                Console.Write("?> " + msg + ": ");
                aux = Console.ReadLine();
                if (Int32.TryParse(aux, out opcion))
                {
                    if (opcion > 0 && opcion <= tope)
                    {
                        salir = true;
                    }
                    else
                    {
                        Console.WriteLine("!> OPCIÓN FUERA DE RANGO [1-" + tope + "]");
                    }

                }
                else
                {
                    CH.lcdColor("!> ¿¡Perdona!?... ?@#!!",ConsoleColor.Red);
                }
            } while (!salir);
            return opcion;
        }

    }

}