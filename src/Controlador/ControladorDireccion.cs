using GestBankV1.src.Vista;
using GestBankV1.src.Modelo;

namespace GestBankV1.src.Controlador
{
    static class ControladorDireccion {

        public static void comenzar(ref Banka banka) {
            bool salir = false;
            int opcion;
            do {
                InterfazAdminstracion.menu_administracion_director();
                opcion = CH.leerOpcion(5);
                switch (opcion) {
                    case 1:
                        ControladorDireccion.accion(1, ref banka);
                        break;
                    case 2:
                        ControladorDireccion.accion(2, ref banka);
                        break;
                    case 3:
                        ControladorDireccion.accion(3, ref banka);
                        break;
                    case 4:
                        ControladorDireccion.accion(4, ref banka);
                        break;
                    case 5:
                        ControladorDireccion.accion(5, ref banka);
                        break;
                    case 0:
                        salir = true;
                        break;
                }
            } while (!salir);
        }

        public static void accion(int accion, ref Banka banka) {
            bool salir = false;
            int opcion;
            do {
                switch (accion) {
                    case 1:
                        InterfazDireccion.mostrar_menu_clientes();
                        opcion = CH.leerOpcion(5);
                        if (opcion==0) {
                            salir = true;
                        } else {
                            ControladorCliente.accion(opcion, ref banka);
                        }    
                        break;
                    case 2:
                        InterfazDireccion.mostrar_menu_empleados();
                        opcion = CH.leerOpcion(5);
                        if (opcion==0) {
                            salir = true;
                        } else {
                            ControladorEmpleado.accion(opcion, ref banka);
                        }
                        break;
                    case 3:
                        InterfazDireccion.mostrar_menu_productos();
                        opcion = CH.leerOpcion(5);
                        if (opcion==0) {
                            salir = true;
                        } else {
                            ControladorProducto.accion(opcion, banka);
                        }
                        break;
                    case 4:
                        break;
                    case 0: 
                        salir = true;
                        break;
                }
            } while (!salir);
        }

    }
}