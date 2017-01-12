using System;
using GestBankV1.src.Modelo;
using GestBankV1.src.Vista;

namespace GestBankV1.src.Controlador
{
    static class ControladorAdministracion {

        private static Empleado empleadoLogeado;
        private static int nivel;                   // NIVEL DE ACCESO: 1-DIRECCION 2-COMERCIAL 3-CAJERO
        public static void comenzar(Banka banka) {

            // 1. COMPROBAR SI HAY DIRECTOR (DIOS - PUEDE HACERLO TODO!! .. O CASI). SINO, PEDIRLO

            if (banka.hayDirector()) {
                empleadoLogeado=ControladorAdministracion.logIn(banka.lista_empleados);
                if (empleadoLogeado!=null) {
                    nivel = empleadoLogeado.tipo_empleado.nivel_acceso; 
                    switch (nivel) {
                        case 1:
                            ControladorDireccion.comenzar(ref banka);
                            break;
                        case 2:
                            ControladorCajero.comenzar(ref banka);
                            break;
                        case 3:
                            ControladorComercial.comenzar(banka);
                            break;
                    }
                } else {
                    CH.lcdColor("\n!> EMPLEADO NO ENCONTRADO",ConsoleColor.Red);
                    CH.pausa();
                }
            } else {
                CH.lcdColor("\n!> NO HAY DIRECTOR EN LA BANCA.. CONTRATALO PRIMERO AHORA!",ConsoleColor.Red);
                ControladorAdministracion.contratarDirector(ref banka);
            }     
        }

        // PROCEDIMIENTO PARA CONTRATAR UN DIRECTOR (DIOS) PARA LA BANKA
        public static void contratarDirector(ref Banka banka) {
            
            // 1. Crear objeto cliente y pedir los datos
            // 2. Asignarle el TipoEmpleado DIRECTOR
            // 3. Añadir a plantilla de empleados de la banka

            bool salir = false;
            Cliente cliente = new Cliente();
            Empleado empleado;
            TipoEmpleado tipo = banka.getTipoEmpleado(1);   // COGEMOS EL TIPO DE EMPLEADO 1 -> DIRECCION PARA ASIGNARSELO AL CLIENTE
            Producto producto = banka.lista_productos[0];   // EL PRODUCTO CUENTA DE AHORROS POR DEFECTO...
            Contrato contrato = null;                       // EL CONTRATO PARA EL DIRECTOR - CON SALDO Y TARJETA BLACK

            
            do {
                cliente.nombre=InterfazCliente.leerNombre();
                cliente.apellidos=InterfazCliente.leerApellidos();
                do {
                    try {               
                        cliente.dni=InterfazCliente.leerDni();
                        salir = true;
                    } catch (Exception e) {
                        CH.lcd(e.Message);
                        //CH.lcd(e.StackTrace);
                    }
                } while (!salir);
                salir = false;
                do {
                    try {
                        cliente.fecha_nac=CH.leerCadena("FECHA NACIMIENTO..");
                        salir = true;
                    } catch (Exception e) {
                        CH.lcd(e.Message);
                    }
                } while (!salir);
                salir = false;
                cliente.usuario=CH.leerCadena("NOMBRE DE USUARIO.");
                cliente.password=CH.leerCadena("CONTRASEÑA........");
                salir = true;
            } while (!salir);

            empleado = new Empleado(1,cliente.nombre,cliente.apellidos,cliente.dni,cliente.fecha_nac,cliente.usuario,cliente.password, new TipoCliente("PLATINUM",100000.00F,5000000),cliente,tipo);
            contrato = new Contrato(1,1,1,DateTime.Now.ToString(),null,1000000.0F,true,producto);
            empleado.agregarContrato(contrato);
            banka.contratarEmpleado(empleado);
            banka.agregarCliente(empleado);
            CH.lcd("\ni> Se ha contratado al director de la banka... \n");
            CH.pausa();
        }

        // FUNCIÓN QUE DEVUELVE UN USUARIO EMPLEADO QUE COINCIDA CON USSER Y PASSW
        public static Empleado logIn(Empleado[] empleados) {
            // 1. PEDIR USUARIO Y PASSW
            // 2. VER SI ESTA
            // 3. SI OK.. RETURN EMPLEADO, ELSE RETURN NULL
            string usser = "";
            string passw = "";
            Empleado empleado = null;

            usser = CH.leerString("USUARIO");
            passw = CH.leerPass();
            
            foreach (Empleado e in empleados ) {
                //CH.lcd(e.ToString());
                if (e.cliente.usuario.Equals(usser) && e.cliente.password.Equals(passw)) {
                    empleado = e;
                }
            }
            return empleado;
        } 

    }
}