using System;
using GestBankV1.src.Modelo;
using GestBankV1.src.Vista;

namespace GestBankV1.src.Controlador
{
    // ESTE ES EL CONTROLADOR DEL TIPO DE EMPLEADO CAJERO. REALIZA LAS OPERACIONES INDICADAS POR LA BANKA
    // CASE: 1. INGRESAR - 2. REINTEGRAR - 3. CONSULTAR DATOS C/AHORROS
    static class ControladorCajero {

        public static void comenzar(ref Banka banka) {
            bool salir = false;
            int opcion;
            do {

                InterfazAdminstracion.menu_administracion_cajero();
                opcion = CH.leerOpcion(3);
                switch (opcion) {
                     case 1:
                        ControladorCajero.ingreso(ref banka);
                        break;
                    case 2:
                        ControladorCajero.reintegro(ref banka);
                        break;
                    case 3:
                        ControladorCliente.mostrarDatosCliente(banka.lista_clientes);
                        break;
                    case 0:
                        salir=true;
                        break;
               }
            } while (!salir);
                            
        }

        public static void ingreso(ref Banka banka) {
            // 1. Pedir dni
            // 2. LocalizarCliente
            // - SI ENCONTRADO -
            // 3. Listar Cuentas Ahorros (indice)
            // 3. Pedir Cuenta de Ahorro (indice)
            // -REPETIR ESTO HASTA CANTIDAD O.K.-
            // 4. Pedir cantidad
            // 5. Evaluar limite segun tipoCliente
            // 6. Si ok, ingresar Cantidad
            
            string dni = "";
            Cliente cliente = null;
            byte numc = 0;
            float cantidad = 0.0F;

            dni = CH.leerDni();
            cliente = banka.obtenerClienteXDNI(dni);
            if (cliente!=null) {
                if (cliente.lista_contratos!=null) {
                    InterfazComercial.listarContratos(cliente);
                    Byte.TryParse(cliente.lista_contratos.Length.ToString(),out numc);
                    numc = CH.leerOpcionMsg(numc,"Elije un contrato de la lista");
                    cantidad=CH.leerCantidad("CANTIDAD A INGRESAR");
                    cliente.lista_contratos[numc-1].ingreso(cantidad);
                    CH.lcdColor("\ni> Se ha ingresado la cantidad en cuenta",ConsoleColor.Green);
                } else {
                    CH.lcdColor("!> EL CLIENTE NO TIENE CONTRATOS!!",ConsoleColor.Red);
                }
            } else {
                CH.lcdColor("!> CLIENTE NO ENCONTRADO",ConsoleColor.Red);
            }

            CH.pausa();


        }

        public static void reintegro(ref Banka banka) {
            // 1. Pedir dni
            // 2. Listar Cuentas Ahorros
            // 3. Pedir Cuentas
            // -REPETIR ESTO HASTA CANTIDAD OK-
            // 4. Pedir cantidad
            // 5. Evaluar limite segun tipoCliente
            // 6. Comprobar si hay saldo
            // 6. Si ok, retirar Cantidad
        }

    }
}