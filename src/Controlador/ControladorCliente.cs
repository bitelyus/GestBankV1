using System;
using GestBankV1.src.Vista;
using GestBankV1.src.Modelo;

namespace GestBankV1.src.Controlador
{
    static class ControladorCliente
    {

        public static void accion(int accion, ref Banka banka)
        {
            switch (accion)
            {
                case 1:
                    ControladorCliente.registrarCliente(ref banka);
                    break;
                case 2:
                    ControladorCliente.mostrarDatosCliente(banka.lista_clientes);
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
                    InterfazDireccion.listarClientes(banka.lista_clientes);
                    break;
            }
        }

        // PROCEDIMIENTO PARA REGISTRAR UN CLIENTE EN LA BANKA
        // @param Banka - la banca para usar su metodo agregarCliente
        public static void registrarCliente(ref Banka banka)
        {
            // 1. Creamos un cliente vacio
            // 2. Pedimos datos uno a uno
            // 3. Con el cliente completo, le contratamos una cuenta de ahorros
            // 4. Lo agregamos a la banka

            bool salir = false;
            Cliente cliente = new Cliente();
            Contrato contrato = null;
            TipoCliente tipoc = null;
            int indice = 0;
            float saldo = 0.0F;
            string dni = "";

            if (banka.lista_clientes != null)
            {
                indice = banka.lista_clientes.Length + 1;
            }

            do
            {
                cliente.id = indice;
                cliente.nombre = InterfazCliente.leerNombre();
                cliente.apellidos = InterfazCliente.leerApellidos();
                do
                {
                    try
                    {
                        dni = InterfazCliente.leerDni().ToUpper();
                        if (!banka.existeDNI(dni))
                        {
                            cliente.dni = dni;
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
                        cliente.fecha_nac = CH.leerCadena("FECHA NACIMIENTO..");
                        salir = true;
                    }
                    catch (Exception e)
                    {
                        CH.lcd(e.Message);
                    }
                } while (!salir);
                salir = false;
                CH.lcdColor("-- DATOS DE ACCESO --", ConsoleColor.Blue);
                cliente.usuario = CH.leerCadena("NOMBRE DE USUARIO.");
                cliente.password = CH.leerCadena("CONTRASEÑA........");
                salir = true;
            } while (!salir);

            // YA TENEMOS EL CLIENTE... A CONTRATAR UNA CUENTA CUENTA AHORROS SI O SI

            contrato = ControladorContrato.crearContratoDefault(banka.lista_productos[0]); // 0 - Cuenta de Ahorros
            contrato.id_cliente = cliente.id; // EN VERDAD NO ES NECESARIO, PUES EL CONTRARO ES CONTENIDO EN UN CLIENTE
            cliente.agregarContrato(contrato);

            // YA QUE TENEMOS EL CONTRATO, EVALUAMOS EL IMPORTE PARA VER EL TIPO DE CLIENTE

            saldo = contrato.saldo;
            if (saldo > 15000.00F)
            {
                tipoc = banka.lista_tipos_clientes[2]; // 0-silver 1-gold 2-platinum
            }
            else if (saldo > 6000.00F)
            {
                tipoc = banka.lista_tipos_clientes[1];
            }
            else
            {
                tipoc = banka.lista_tipos_clientes[0];
            }

            cliente.tipo_cliente = tipoc;
            banka.agregarCliente(cliente);

            CH.lcd("\n" + contrato.ToString());
            CH.lcd("\ni> Se ha agregado un nuevo cliente a la banka...");
            CH.pausa();
        }

        public static void mostrarDatosCliente(Cliente[] clientes)
        {
            int numcli = 0;
            int opcion;
            if (clientes != null)
            {
                numcli = clientes.Length;
            }
            if (numcli > 0)
            {
                // 1. listar todos los clientes
                // 2. pedir el cliente
                // 3. mostrar toString cliente
                InterfazDireccion.listarClientesIndice(clientes);
                opcion = InterfazDireccion.pedirCliente(numcli, "Elige un cliente de la lista");
                CH.lcd(clientes[opcion - 1].ToString());
                if (clientes[opcion - 1].lista_contratos != null)
                {
                    InterfazComercial.listarContratos(clientes[opcion - 1]);
                }
            }
            else
            {
                CH.lcd("!> No hay clientes en la banka!");
            }
            CH.pausa();
        }

    }
}