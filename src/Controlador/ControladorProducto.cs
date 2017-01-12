using System;
using GestBankV1.src.Modelo;
using GestBankV1.src.Vista;

namespace GestBankV1.src.Controlador
{
    static class ControladorProducto {

        public static void accion(int accion,Banka banka) {
            switch (accion)
            {
                case 1:
                    ControladorProducto.consultarProducto(banka.lista_productos);
                    break;
                case 2:
                    ControladorProducto.registrarProducto(ref banka);
                    break;
                case 3:
                    CH.lcd("A MODIFICAR CLIENTE");
                    CH.pausa();
                    // MODIFICAR CLIENTE
                    break;
                case 4:
                    // ELIMINAR CLIENTE
                    break;
                case 5:
                    // LISTAR TODOS LOS CLIENTES
                    ControladorProducto.listarProductos(banka.lista_productos);
                    break;
            }
        
        }

        public static void consultarProducto(Producto[] productos) {
            // 1. Listar Producto con Indice
            // 2. Elegir producto
            // 3. Mostrar datos

            byte opcion = 0;
            byte elementos_byte; // SUPONIENDO QUE NO HAYA MAS DE 255 PRODUCTOS.... 
            int elementos = 0;

            elementos = productos.Length;
            if (elementos>0) {
                Byte.TryParse(elementos.ToString(),out elementos_byte);
                InterfazContrato.listarProductosIndice(productos);
                opcion = CH.leerOpcionMsg(elementos_byte,"Selecciona un producto de la lista");
                CH.lcd(productos[opcion-1].ToString());
            } else {
                CH.lcdColor("No hay productos en la banka!!",ConsoleColor.Magenta);
            }
            CH.pausa();
            
        }

        public static void registrarProducto(ref Banka banka) {
            Producto producto = new Producto();
            producto.id=banka.lista_productos.Length+1;
            producto.nombre=CH.leerString("NOMBRE PRODUCTO");
            producto.descripcion=CH.leerCadena("DESCRIPCION....");
            producto.tipo_interes=CH.leerFloat("TIPO DE INTERES");
            banka.agregarProducto(producto);
            CH.lcdColor("\ni> Se ha agreado un nuevo producto a la banka!",ConsoleColor.Green);
            CH.pausa();
            
        }

        public static void listarProductos(Producto[] productos) {
            if (productos!=null) {
                InterfazComercial.listarProductos(productos);
            } else {
                CH.lcdColor("!> NO HAY PRODUCTOS EN LA BANKA",ConsoleColor.Red);
            }
            CH.pausa();
        }

    }
}