namespace GestBankV1.src.Modelo 
{
    class Empleado:Cliente {

        // ZONA DE ATRIBUTOS O MIEMBROS
        
        private Cliente _cliente;
        private TipoEmpleado _tipo_empleado;

        public Cliente cliente {
            get {
                return _cliente;
            }
            set {
                _cliente=value;
            }
        }

        public TipoEmpleado tipo_empleado {
            get {
                return _tipo_empleado;
            }
            set {
                _tipo_empleado=value;
            }
        }

        public Empleado() {
            this._cliente = null;
            this._tipo_empleado = null;
        }

        public Empleado(int id, string nombre, string apellidos, string dni, string fecha_nac, string usuario, string pass, TipoCliente tipoc, Cliente cliente, TipoEmpleado tipoe) : base( id,  nombre,  apellidos,  dni,  fecha_nac,  usuario,  pass, tipoc) {
            this.cliente = cliente;
            this.tipo_empleado = tipoe;
        }

        override
        public string ToString() {
            string cadena = "";
            cadena+="*******************************************\n";
            cadena+="* YO SOY UN EMPLEADO! : HEREDO DE CLIENTE *\n";
            cadena+="*******************************************\n";
            cadena+=this.cliente.ToString();
            cadena+=this.tipo_empleado.ToString();
            return cadena;
        }
    }
}