using System;
using GestBankV1.src.Modelo;
using GestBankV1.src.Vista;


namespace GestBankV1.src.Controlador 
{
    static class ControladorEmpleado {


        public static void accion(int accion, ref Banka banka)
        {
            switch (accion)
            {
                case 1:
                    ControladorEmpleado.registrarEmpleado(ref banka);
                    break;
                case 2:
                    ControladorEmpleado.mostrarDatosEmpleado(banka.lista_empleados);
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
                    InterfazDireccion.listarEmpleados(banka.lista_empleados);
                    break;
            }
        }

        // PROCEDIMIENTO PARA REGISTRAR UN CLIENTE EN LA BANKA
        // @param Banka - la banca para usar su metodo agregarCliente
        public static void registrarEmpleado(ref Banka banka)
        {   
            // 1. Creamos un cliente vacio
            // 2. Pedimos datos uno a uno
            // 3. Con el cliente completo, le contratamos una cuenta de ahorros,
            // 4. Evaluamos el tipoCliente y asignamos
            // 4. Lo agregamos a la banka

            bool salir = false;
            Empleado empleado = new Empleado();
            Cliente cliente = new Cliente();
            Contrato contrato = null;
            TipoCliente tipoc = null;
            TipoEmpleado tipoe = null;
            int indice = 0;
            int indicee = 0;
            float saldo = 0.0F;
            byte totalte;
            string dni="";
            

            if (banka.lista_clientes!=null) {
                indice = banka.lista_clientes.Length+1;
            }

            do
            {
                empleado.id=indice;
                empleado.nombre = InterfazCliente.leerNombre();
                empleado.apellidos = InterfazCliente.leerApellidos();
                do
                {
                    try
                    {
                        dni = InterfazCliente.leerDni().ToUpper();
                        if (!banka.existeDNI(dni))
                        {
                            empleado.dni = dni;
                            salir = true;
                        }
                        else
                        {
                            CH.lcdColor("!> EL D.N.I. YA ESTÁ REGISTRADO EN EL SISTEMA", ConsoleColor.Red);
                        }
                    }
                    catch (Exception e)
                    {
                        CH.lcd(e.Message);
                        //CH.lcd(e.StackTrace);
                    }
                } while (!salir);
                salir = false;
                do
                {
                    try
                    {
                        empleado.fecha_nac = CH.leerCadena("FECHA NACIMIENTO..");
                        salir = true;
                    }
                    catch (Exception e)
                    {
                        CH.lcd(e.Message);
                    }
                } while (!salir);
                salir = false;
                CH.lcdColor("-- DATOS DE ACCESO --",ConsoleColor.Blue);
                empleado.usuario = CH.leerCadena("NOMBRE DE USUARIO.");
                empleado.password = CH.leerCadena("CONTRASEÑA........");
                salir = true;
            } while (!salir);

            // YA TENEMOS EL CLIENTE... A CONTRATAR UNA CUENTA CUENTA AHORROS SI O SI

            contrato = ControladorContrato.crearContratoDefault(banka.lista_productos[0]); // 0 - Cuenta Ahorros
            contrato.id_cliente=empleado.id; // EN VERDAD NO ES NECESARIO, PUES ES CONTRARO ES CONTENIDO EN UN CLIENTE
            empleado.agregarContrato(contrato);

            // YA QUE TENEMOS EL CONTRATO, EVALUAMOS EL IMPORTE PARA VER EL TIPO DE CLIENTE

            saldo = contrato.saldo;
            if (saldo>15000.00F) {
                tipoc = banka.lista_tipos_clientes[2]; // 0-silver 1-gold 2-platinum
            } else if (saldo>6000.00F) {
                tipoc = banka.lista_tipos_clientes[1];
            } else {
                tipoc = banka.lista_tipos_clientes[0];
            }

            CH.lcd("\n"+contrato.ToString());
            
            empleado.tipo_cliente=tipoc;

            // AHORA VAMOS A DECIRLE QUE TIPO DE EMPLEADO ES...
            CH.lcd("\ni> OK, MiK... Ahora vamos a decir que tipo de empleado es...\n");
            Byte.TryParse(banka.lista_tipos_empleados.Length.ToString(),out totalte);
            InterfazEmpleado.listarTiposEmpleadosIndice(banka.lista_tipos_empleados);
            indicee = CH.leerOpcionMsg(totalte,"Elige un Tipo de Empleado");
            tipoe = banka.lista_tipos_empleados[indicee-1];

            empleado.tipo_empleado=tipoe;
            cliente = new Cliente(empleado.id,empleado.nombre, empleado.apellidos, empleado.dni, empleado.fecha_nac, empleado.usuario, empleado.password, tipoc);
            empleado.cliente=cliente;
            banka.contratarEmpleado(empleado);
            banka.agregarCliente(empleado);
            CH.lcd(empleado.ToString());
            CH.lcdColor("\ni> Se ha agregado un nuevo empleado y cliente a la banka...",ConsoleColor.Green);
            CH.pausa();
        }

        public static void mostrarDatosEmpleado(Empleado[] empleados) {
            int numcli = 0;
            int opcion;
            if (empleados!=null) {
                numcli = empleados.Length;
            }
            if (numcli>0) {
                // 1. listar todos los clientes
                // 2. pedir el cliente
                // 3. mostrar toString cliente
                InterfazDireccion.listarEmpleadosIndice(empleados);
                opcion = InterfazDireccion.pedirCliente(numcli,"Elige un cliente de la lista");
                CH.lcd(empleados[opcion-1].ToString());
                if (empleados[opcion-1].lista_contratos!=null) {
                    InterfazComercial.listarContratos(empleados[opcion-1]);
                }
            } else {
                CH.lcd("!> No hay empleados en la banka!");
            }
            CH.pausa();
        }

    }
}