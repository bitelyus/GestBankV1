using System;
using GestBankV1.src.Modelo;
using GestBankV1.src.Vista;

namespace GestBankV1.src.Controlador
{
    static class ControladorContrato {
        public static Contrato crearContratoDefault(Producto producto) {
            CH.lcd("\ni> OK, MiK... Ahora vamos a crearle una 'Cuenta de Ahorros' por defecto\n");
            Contrato contrato = new Contrato();
            contrato.id=Contrato.contratos+1;
            // el id del cliente se lo ponemos en el ControladorDireccion
            contrato.producto=producto;
            contrato.id_producto=producto.id;
            contrato.fecha_contratacion=DateTime.Now.ToString();
            contrato.fecha_finalizacion=DateTime.Now.AddYears(1).ToString(); // probando método AddYears
            contrato.saldo=InterfazContrato.leerSaldo();
            contrato.activo=true;
            Contrato.contratos = Contrato.contratos++;
            return contrato;
        }

        public static Contrato crearContrato(Producto[] productos) {
            byte opcion;
            Byte.TryParse(productos.Length.ToString(), out opcion);
            Producto producto = null;
            Contrato contrato = new Contrato();
            InterfazContrato.listarProductosIndice(productos);
            opcion = InterfazContrato.leerOpcionMsg(opcion,"Selecciona un producto de la lista");
            producto = productos[opcion-1];
            contrato.id=Contrato.contratos+1;
            contrato.producto=producto;
            contrato.id_producto=producto.id;
            contrato.fecha_contratacion=DateTime.Now.ToString();
            contrato.fecha_finalizacion=DateTime.Now.AddYears(1).ToString();
            contrato.saldo=InterfazContrato.leerSaldo();
            contrato.activo=true;
            Contrato.contratos = Contrato.contratos++;
            return contrato;
        }

    }
}