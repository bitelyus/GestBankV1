namespace GestBankV1.src.Modelo 
{
    class ClienteMenor:Cliente {

        private Cliente _clienteAutorizado;
        public Cliente clienteAutorizado {
            get {
                return _clienteAutorizado;
            }
            set {
                _clienteAutorizado = value;
            }
        }

        // CONSTRUCTOR VACIO POR DEFECTO...
        // LLAMAMOS AL CONSTRUCTOR DEL PADRE EN EL NUESTRO PROPIO Y AÑADIMOS AL CLIENTE MAYOR DE EDAD AUTORIZADO
        public ClienteMenor(int id, string nombre, string apellidos, string dni, string fecha_nac, string usuario, string pass, TipoCliente tipo, Cliente cliente) :
            base(id, nombre, apellidos, dni, fecha_nac, usuario, pass, tipo) {
            this.clienteAutorizado=cliente;
        }

        // CONSTRUCTOR VACIO
        public ClienteMenor() :
            base() {
            this._clienteAutorizado=null;
        }

    }
}