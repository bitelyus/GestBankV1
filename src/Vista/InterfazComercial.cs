using System;
using GestBankV1.src.Modelo;

namespace GestBankV1.src.Vista
{
    static class InterfazComercial {

        public static void listarContratos(Cliente cliente) {
            string cadena = "";
            int indice = 1;

            cadena += "\nLISTADO DE CONTRATOS DEL CLIENTE: "+cliente.nombre + " " + cliente.apellidos + " | " + cliente.dni + "\n";
            cadena += "".PadRight(77,'=');
            Console.WriteLine(cadena);
            cadena = "";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0}{1} {2}{3}{4}", "ID".PadRight(5), "FECHA CONTRATACION".PadRight(20), "NOMBRE PRODUCTO".PadRight(20), "IMPORTE".PadRight(13),"FECHA FINALIZACION".PadRight(5));
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Contrato contrato in cliente.lista_contratos)
            {
                Console.WriteLine("{0}{1} {2}{3}{4}", contrato.id.ToString() + ".".PadRight(4), contrato.fecha_contratacion.PadRight(20), contrato.producto.nombre.PadRight(20), contrato.saldo+" €".PadRight(10),contrato.fecha_finalizacion.PadLeft(1));
                indice++;
            }
            Console.WriteLine();
        }

        public static void listarProductos(Producto[] productos) {
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

    }
}