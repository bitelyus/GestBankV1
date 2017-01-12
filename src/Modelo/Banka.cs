// UNA BANCA ES UN ARRAY DE EMPLEADOS (UN DIRECTOR QUE PUEDA HACERLO TODO)
// CON UN ARRAY DE CLIENTES, PRODUCTOS, Y CONTRATOS DE CLIENTES QUE CONTRATAN
// PRODUCTOS .. CON UNOS TIPOS DE EMPLEADOS Y DE CLIENTES... EA!

using System;

namespace GestBankV1.src.Modelo
{
    class Banka
    {

        public string nombre;
        private TipoCliente[] _lista_tipos_clientes;
        private TipoEmpleado[] _lista_tipos_empleados;
        private Cliente[] _lista_clientes;
        private Empleado[] _lista_empleados;
        private Producto[] _lista_productos;

        public Empleado[] lista_empleados
        {
            get
            {
                return _lista_empleados;
            }
        }

        public Cliente[] lista_clientes
        {
            get
            {
                return _lista_clientes;
            }
        }

        public Producto[] lista_productos
        {
            get
            {
                return _lista_productos;
            }
        }

        public TipoCliente[] lista_tipos_clientes {
            get {
                return _lista_tipos_clientes;
            }
        }

        public TipoEmpleado[] lista_tipos_empleados {
            get {
                return _lista_tipos_empleados;
            }
        }


        public TipoEmpleado getTipoEmpleado(int indice)
        {
            if (_lista_tipos_empleados != null)
            {

            }
            else
            {
                throw new Exception("Lista de Empleados Vacía!");
            }
            return _lista_tipos_empleados[indice - 1];
        }

        public Banka()
        {
            this.nombre = "GestBankV1 - by MiK >:)";
            this._lista_tipos_clientes = null;
            this._lista_tipos_empleados = null;
            this._lista_clientes = null;
            this._lista_empleados = null;
            this._lista_productos = null;
            this.cargarTipos();
        }

        // MÉTODOS PARA NUTRIR DE DATOS LOS ARRAY DINÁMICOS DE DATOS

        // MÉTODO PARA AGREGAR UN TIPO DE CLIENTE
        public bool agregarTipoCliente(TipoCliente tipo)
        {
            bool agregado = false;
            TipoCliente[] copia = null;

            if (_lista_tipos_clientes == null)
            {
                _lista_tipos_clientes = new TipoCliente[1];
            }
            else
            {
                copia = new TipoCliente[_lista_tipos_clientes.Length];
                _lista_tipos_clientes.CopyTo(copia, 0);
                _lista_tipos_clientes = new TipoCliente[copia.Length + 1];
                copia.CopyTo(_lista_tipos_clientes, 0);
                copia = null;
            }
            _lista_tipos_clientes[_lista_tipos_clientes.Length - 1] = tipo;
            agregado = true;
            return agregado;
        }

        // MÉTODO PARA AGREGAR UN TIPO DE EMPLEADO
        public bool agregarTipoEmpleado(TipoEmpleado tipo)
        {
            bool agregado = false;
            TipoEmpleado[] copia = null;

            if (_lista_tipos_empleados == null)
            {
                _lista_tipos_empleados = new TipoEmpleado[1];
            }
            else
            {
                copia = new TipoEmpleado[_lista_tipos_empleados.Length];
                _lista_tipos_empleados.CopyTo(copia, 0);
                _lista_tipos_empleados = new TipoEmpleado[copia.Length + 1];
                copia.CopyTo(_lista_tipos_empleados, 0);
                copia = null;
            }
            _lista_tipos_empleados[_lista_tipos_empleados.Length - 1] = tipo;
            agregado = true;
            return agregado;
        }

        // MÉTODO PARA AGREGAR UN PRODUCTO AL LISTADO
        public bool agregarProducto(Producto producto)
        {
            bool agregado = false;
            Producto[] copia = null;

            if (_lista_productos == null)
            {
                _lista_productos = new Producto[1];
            }
            else
            {
                copia = new Producto[_lista_productos.Length];
                _lista_productos.CopyTo(copia, 0);
                _lista_productos = new Producto[copia.Length + 1];
                copia.CopyTo(_lista_productos, 0);
                copia = null;
            }
            _lista_productos[_lista_productos.Length - 1] = producto;
            agregado = true;
            return agregado;
        }

        // MÉTODO PARA CONTRATAR UN EMPLEADO
        public bool contratarEmpleado(Empleado empleado)
        {
            bool agregado = false;
            Empleado[] copia = null;

            if (_lista_empleados == null)
            {
                _lista_empleados = new Empleado[1];
            }
            else
            {
                copia = new Empleado[_lista_empleados.Length];
                _lista_empleados.CopyTo(copia, 0);
                _lista_empleados = new Empleado[copia.Length + 1];
                copia.CopyTo(_lista_empleados, 0);
                copia = null;
            }
            _lista_empleados[_lista_empleados.Length - 1] = empleado;
            agregado = true;
            return agregado;
        }

        // MÉTODO PARA AGREGAR UN CLIENTE   
        public bool agregarCliente(Cliente cliente)
        {
            bool agregado = false;
            Cliente[] copia = null;

            if (_lista_clientes == null)
            {
                _lista_clientes = new Cliente[1];
            }
            else
            {
                copia = new Cliente[_lista_clientes.Length];
                _lista_clientes.CopyTo(copia, 0);
                _lista_clientes = new Cliente[copia.Length + 1];
                copia.CopyTo(_lista_clientes, 0);
                copia = null;
            }
            _lista_clientes[_lista_clientes.Length - 1] = cliente;
            agregado = true;
            return agregado;
        }


        // MÉTODO PARA COMPROBAR SI HAY DIRECTOR EN LA BANCA. ES DIOS!
        // TODO PARTE DEL DIRECTOR. SIN DIRECTOR NO SE PUEDEN CREAR EMPLEADOS
        // QUE PUEDAN AGREGAR CLIENTES NI CONTRATOS
        public Boolean hayDirector()
        {
            Boolean encontrado = false;
            if (_lista_empleados != null)
            {
                foreach (Empleado empleado in lista_empleados)
                {
                    if (empleado.tipo_empleado.nombre.Equals("DIRECCIÓN"))
                    {
                        encontrado = true;
                    }
                }
            }
            return encontrado;
        }

        public Cliente obtenerClienteXDNI(string dni) {
            Cliente cliente = null;
            if (lista_clientes!=null) {
                foreach (Cliente c in lista_clientes) {
                    if (c.dni.ToUpper().Equals(dni.ToUpper())) { 
                        cliente = c;
                        return cliente;
                    }
                }
            }
            return cliente;
        }

        public bool existeDNI(string dni) {
            bool existe = false;
            if (lista_clientes!=null) {
                foreach (Cliente c in lista_clientes) {
                    if (c.dni.ToUpper().Equals(dni.ToUpper())) { 
                        existe=true;
                        break;
                    }
                }
            }
            return existe;
        }

        public void cargarTipos()
        {

            TipoCliente tipoCSilver = new TipoCliente("SILVER", 500.00F, 1000.00F);
            TipoCliente tipoCGold = new TipoCliente("GOLD", 5000.00F, 6000.00F);
            TipoCliente tipoCPlatinum = new TipoCliente("PLATINUM", 15000.00F, 30000.00F);

            TipoEmpleado tipoEDireccion = new TipoEmpleado("DIRECCIÓN", 1);
            TipoEmpleado tipoECajero = new TipoEmpleado("CAJERO", 2);
            TipoEmpleado tipoEComercial = new TipoEmpleado("COMERCIAL", 3);

            Producto producto1 = new Producto(001, "CUENTA DE AHORRO", "Cuenta a la vista donde poder realizar operaciones de ingreso y reintegro", 1.2F, true);
            Producto producto2 = new Producto(002, "PLAZO FIJO", "Depósito que mantiene un saldo fijo por un período de tiempo y ofrece una rentabilidad fija asegurada", 2.5F, true);
            Producto producto3 = new Producto(003, "FONDO DE INVERSIÓN", "Depósito que mantiene un saldo fijo por un período de tiempo y ofrece rentabilidad variable", 5.2F, true);
            Producto producto4 = new Producto(004, "PRÉSTAMO", "Cantidad de dinero prestada al cliente que tiene que devolverlo en un plazo con un interés asociado", 16.5F, true);


            this.agregarTipoCliente(tipoCSilver);
            this.agregarTipoCliente(tipoCGold);
            this.agregarTipoCliente(tipoCPlatinum);

            this.agregarTipoEmpleado(tipoEDireccion);
            this.agregarTipoEmpleado(tipoECajero);
            this.agregarTipoEmpleado(tipoEComercial);

            this.agregarProducto(producto1);
            this.agregarProducto(producto2);
            this.agregarProducto(producto3);
            this.agregarProducto(producto4);
        }

    }
}