using System;
using GestBankV1.src.Modelo;
using GestBankV1.src.Vista;

namespace GestBankV1.src.Controlador
{
    static class ControladorComercial {

        public static void comenzar(Banka banka) {
            bool salir = false;
            int opcion;
            do {
               InterfazAdminstracion.menu_administracion_comercial();
               opcion = CH.leerOpcion(3);
               switch (opcion) {
                    case 1:
                        ControladorComercial.consultarContratosCliente(banka);
                        break;
                    case 2:
                        ControladorComercial.consultarProductos(banka.lista_productos);
                        break;
                    case 3:
                        ControladorComercial.contratarProductos(ref banka);
                        break;
                    case 0:                        
                        salir=true;
                        break;
               }
            } while (!salir);

        }

        public static void consultarContratosCliente(Banka banka) {
            // 1. Mostrar clientes con indice
            // 2. Elegir clientes
            // 3. Mostrar contratos del clientes
            int opcion;
            int numcli=0;
            
            if (banka!=null) {
                numcli=banka.lista_clientes.Length;
            }
            if (numcli>0) {
                InterfazDireccion.listarClientesIndice(banka.lista_clientes);
                opcion = InterfazDireccion.pedirCliente(numcli,"Elige un cliente de la lista");
                Cliente cliente = banka.lista_clientes[opcion-1];
                if (cliente.lista_contratos!=null) {
                    InterfazComercial.listarContratos(cliente);
                } else {
                    CH.lcd("!> El cliente no tiene ningun contrato");
                }
            } else {
                CH.lcd("i> No hay clientes que mostrar!");
            }
            CH.pausa();
        }

        public static void consultarProductos(Producto[] productos) {
            byte opcion; // dado que no habra muchos productos, le ponemos un byte
            Producto producto;
            if (productos!=null) {
                Byte.TryParse(productos.Length.ToString(),out opcion);
                InterfazComercial.listarProductos(productos);
                opcion = CH.leerOpcionMsg(opcion,"Elije un producto de la lista");
                producto = productos[opcion-1];
                CH.lcd("\n"+producto.ToString());
            } else {
                CH.lcd("i> No hay productos en la banka!!");
            }
            CH.pausa();
        }

        public static void contratarProductos(ref Banka banka) {
            // 1. pedir dni
            // 2. buscar dni en lista de clientes
            // 3. si lo encuentra, cargarlo
            // 4. listar productos
            // 5. seleccionar uno
            // 6. pedir datos del contrato (importe-fechafin)
            // 7. cliente.agregarContrato(contrato);

            string dni = "";
            Cliente cliente = null;
            Producto producto = null;
            Contrato contrato = null;
            byte indice;
            int id;

            dni = CH.leerDni();

            foreach (Cliente c in banka.lista_clientes) {
                if (c.dni.ToUpper().Equals(dni.ToUpper())) {
                    cliente = c;
                    break;
                }
            }

            if (cliente!=null) {
                contrato = new Contrato();
                Byte.TryParse(banka.lista_productos.Length.ToString(),out indice);
                InterfazContrato.listarProductosIndice(banka.lista_productos);
                id = CH.leerOpcionMsg(indice,"Selecciona un producto de la lista");
                producto = banka.lista_productos[id-1];
                contrato.id=Contrato.contratos+1;
                contrato.producto=producto;
                contrato.id_producto=producto.id;
                contrato.fecha_contratacion=DateTime.Now.ToString();
                contrato.fecha_finalizacion=DateTime.Now.AddYears(1).ToString();
                contrato.saldo=InterfazContrato.leerSaldo();
                contrato.activo=true;
                Contrato.contratos++;
                cliente.agregarContrato(contrato);
                CH.lcdColor("i> Se ha contratado el producto al cliente",ConsoleColor.DarkGreen);
            } else {
                CH.lcdColor("!> Cliente no encontrado!!",ConsoleColor.DarkRed);
            }
            CH.pausa();
        }

    }
}