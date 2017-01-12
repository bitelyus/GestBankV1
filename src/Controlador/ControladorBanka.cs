using System;
using GestBankV1.src.Vista;
using GestBankV1.src.Modelo;

namespace GestBankV1.src.Controlador
{
    static class ControladorBanka
    {
        // ZONA DE ATRIBITOS Y CONSTANTES

         // CREAMOS NUESTRO OBJETO BANKA!!
        public static Banka banka;     


        // OPCION FÁCIL PARA TIPOS EMPLEADOS... YO COMO ES NATURAL ME COMPLICARÉ!!
        // public static string[] tiposEmpleados = new string[3]{"DIRECTOR","CAJERO","COMERCIAL"};

        // ZONA DE MÉTODOS
        public static void comenzar()
        {
            // ZONA DE VARIABLES E INICIALIZACIÓN
            // 1. CREAR BANKA CON DATOS POR DEFECTO -Y-O-U- CONSTANTES
            // 2. MOSTRAR MENU
            // 3. PEDIR OPCION
            // 4. ACTUAR EN CONSECUENCIA

            banka = new Banka();
            bool salir = false;
            int opcion = 0;

            // ENTRADA

            // PROCESO 
            do
            {
                InterfazBanka.menu_principal(banka.nombre);
                opcion = CH.leerOpcion(3);
                switch (opcion)
                {
                    case 1: // INICIAMOS EL MÓDULO DE AMINISTRACIÓN
                        ControladorAdministracion.comenzar(banka);
                        break;
                    case 2: // INICIAMOS EL MÓDULO PARA LOS CLIENTES DE LA BANCA
                        CH.pausa();
                        break;
                    case 3: // CARGAMOS DATOS A LA BANKA PARA MODO DEBUG
                        ControladorBanka.debug();
                        CH.pausa();
                        break;
                    case 0:
                        salir = true;
                        break;
                }
            } while (!salir); 

            // SALIDA
            Console.WriteLine("\nBYE BYE!! .. MiK.. VUELVE PRONTO :)\n");
        }


        // PROCEDIMIENTO PARA CARGAR DE DATOS POR DEFECTO A LA APLICACIÓN
        // 1. CREAMOS LOS TIPOS PREDEFINIDOS DE TIPOCLIENTE Y TIPOEMPLEADO
        // 2. CREAMOS VARIOS CLIENTES, EMPLEADOS, PRODUCTOS ...  CONTRATOS
        // 3. RALIZAMOS CONTRATOS DE PRODUCTOS Y LO AGREGAMOS A CLIENTES O EMPLEADOS.
        public static void debug()
        {
            try
            {
                
                TipoCliente tipoCSilver = new TipoCliente("SILVER", 500.00F, 1000.00F);
                TipoCliente tipoCGold = new TipoCliente("GOLD", 5000.00F, 6000.00F);
                TipoCliente tipoCPlatinum = new TipoCliente("PLATINUM", 15000.00F, 30000.00F);
                CH.lcd(tipoCSilver.ToString());
                CH.lcd(tipoCGold.ToString());
                CH.lcd(tipoCPlatinum.ToString());

                TipoEmpleado tipoEDireccion = new TipoEmpleado("DIRECCIÓN", 1);
                TipoEmpleado tipoECajero = new TipoEmpleado("CAJERO", 2);
                TipoEmpleado tipoEComercial = new TipoEmpleado("COMERCIAL", 3);


                CH.lcd(tipoEDireccion.ToString());
                CH.lcd(tipoECajero.ToString());
                CH.lcd(tipoEComercial.ToString());
                

                Cliente cliente1 = new Cliente(1,"Juan", "Perez Navas", "11111111H","12/08/1978 20:45:30","admin","12345678");
                Cliente cliente2 = new Cliente(2,"Rosa", "Diaz Valderrama", "12345678Z","12/08/1978 20:45:30","abcdefg","99999999");
                Cliente cliente3 = new Cliente(3,"Carmen", "Soler Días", "55555555K","12/08/1978 20:45:30","abcdefg","12345678",tipoCGold);
                CH.lcd(cliente1.ToString());
                CH.lcd(cliente2.ToString());
                CH.lcd(cliente3.ToString());

                Empleado empleado1 = new Empleado(1,cliente1.nombre,cliente1.apellidos,cliente1.dni,cliente1.fecha_nac,cliente1.usuario,cliente1.password, new TipoCliente("EXCELSIOR-BLACK",10000000.00F,5000000),cliente1,tipoEDireccion); 
                Empleado empleado2 = new Empleado(1,cliente1.nombre,cliente1.apellidos,cliente1.dni,cliente1.fecha_nac,cliente1.usuario,cliente1.password, new TipoCliente("EXCELSIOR-BLACK",10000000.00F,5000000),cliente2,tipoEComercial); 
                Empleado empleado3 = new Empleado(1,cliente1.nombre,cliente1.apellidos,cliente1.dni,cliente1.fecha_nac,cliente1.usuario,cliente1.password, new TipoCliente("EXCELSIOR-BLACK",10000000.00F,5000000),cliente3,tipoECajero); 
                CH.lcd(empleado1.ToString());
                CH.lcd(empleado2.ToString());
                CH.lcd(empleado3.ToString());

                Producto producto1 = new Producto(001,"CUENTA DE AHORRO","Cuenta a la vista donde poder realizar operaciones de ingreso y reintegro",1.2F,true);
                Producto producto2 = new Producto(002,"PLAZO FIJO","Depósito que mantiene un saldo fijo por un período de tiempo y ofrece una rentabilidad fija asegurada",2.5F,true);
                Producto producto3 = new Producto(003,"FONDO DE INVERSIÓN","Depósito que mantiene un saldo fijo por un período de tiempo y ofrece rentabilidad variable",5.2F,true);
                Producto producto4 = new Producto(004,"PRÉSTAMO","Cantidad de dinero prestada al cliente que tiene que devolverlo en un plazo con un interés asociado",16.5F,true);
                CH.lcd(producto1.ToString());
                CH.lcd(producto2.ToString());
                CH.lcd(producto3.ToString());
                CH.lcd(producto4.ToString());

                Contrato contrato1 = new Contrato(1,2,1,"07/01/2017","07/01/2020",5000.55F,true,producto1);
                CH.lcd(contrato1.ToString());

                cliente1.agregarContrato(contrato1);
                CH.lcd(cliente1.ToString());


                // AGREGAMOS LOS OBJETOS A NUESTRA BANKA!!
                /* 
                banka.agregarTipoCliente(tipoCSilver);
                banka.agregarTipoCliente(tipoCGold);
                banka.agregarTipoCliente(tipoCPlatinum);

                banka.agregarTipoEmpleado(tipoEDireccion);
                banka.agregarTipoEmpleado(tipoECajero);
                banka.agregarTipoEmpleado(tipoEComercial);
               
                banka.agregarProducto(producto1);
                banka.agregarProducto(producto2);
                banka.agregarProducto(producto3);
                banka.agregarProducto(producto4);
                */
                
                banka.contratarEmpleado(empleado1);
                banka.contratarEmpleado(empleado2);
                banka.contratarEmpleado(empleado3);

                banka.agregarCliente(cliente1);
                banka.agregarCliente(cliente2);
                banka.agregarCliente(cliente3);

            }
            catch (Exception ex)
            {
                CH.lcd(ex.Message);
                CH.lcd(ex.ToString());
            }
        }

    }
}
