using System;

namespace GestBankV1.src.Modelo
{
    class Cliente
    {
        // ZONA DE ATRIBUTOS

        private int _id;
        public string nombre;
        public string apellidos;
        private string _dni;
        private DateTime _fecha_nac; 
        private string _usuario;
        private string _password;
        private TipoCliente _tipoCliente;
        private Contrato[] _contratos;       

        // Getters & Setters para miembros privados

        public int id {
            get {
                return _id;
            }
            set {
                if (value<0) {
                    throw new Exception("!> Indica un id válido!");
                }
                _id=value;
            }
        }
        public string dni
        {
            get {
                if (_dni == null) {
                    throw new Exception("!> DNI no establecido");
                }
                return _dni;
            }
            set {
                byte tipoError = 0; // 0 - No hay errror
                string mensaje = null;
                if (value.Length != 9) {
                    tipoError = 1;
                }

               tipoError = ComprobarDni(value);

                switch (tipoError) {
                    case 1:
                        //throw new Exception("Tamaño Incorrecto DNI");  >> asi no llega al break. usar variable en su lugar.
                        mensaje = "!> Tamaño Incorrecto de DNI!!";
                        break;
                    case 2:
                        //throw new Exception("Formato DNI no valido");
                        mensaje = "!> Formato DNI no válido!!";
                        break;
                    case 3:
                        //throw new Exception("Formato DNI no valido");
                        mensaje = "!> Letra DNI no válida!!";
                        break;
                }
                if (tipoError != 0) {
                    throw new Exception(mensaje);
                }
                _dni = value;
            }
        }

        public string fecha_nac {
            get {
                return _fecha_nac.ToString();
            }
            set {
                DateTime.TryParse(value,out _fecha_nac);
            }
        }

        public string usuario {
            get {
                if (_usuario==null) {
                    throw new Exception("!> Usuario no establecido!");
                }
                return _usuario;
            }
            set {
                _usuario = value; 
            }
        }

        public string password {
            get {
                if (_password==null) { 
                    throw new Exception("!> Constraseña no establecida!");
                }
                return _password;
            }
            set {
                if (value.Length<8) {
                    throw new Exception("!> Contraseña demasiado corta!");
                }
                _password=value;
            }
        }

        public TipoCliente tipo_cliente {
            get {
                return _tipoCliente;
            } 
            set {
                _tipoCliente=value;
            }
        }

        public Contrato[] lista_contratos {
            get {
                return _contratos;
            }
        }

        // ZONA DE CONSTRUCCTORES

        public Cliente() { 
            nombre = null;
            apellidos = null;
            _dni = null;
            _fecha_nac = new DateTime();
            _usuario = null;
            _password = null;
            _tipoCliente = null;
            _contratos = null;
        }

        public Cliente(int id, string nombre, string apellidos, string dni, string fecha_nac) {
            this.id=id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.dni = dni;
            this.fecha_nac = fecha_nac;
            this.usuario = nombre;
            this.password = "00000000";
            this.tipo_cliente = null;
            this._contratos = null;
        }

        public Cliente(int id, string nombre, string apellidos, string dni, string fecha_nac, string usuario, string pass) {
            this.id=id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.dni = dni;
            this.fecha_nac = fecha_nac;
            this.usuario = usuario;
            this.password = pass;
            this.tipo_cliente = null;
            this._contratos = null;
        }

        public Cliente(int id, string nombre, string apellidos, string dni, string fecha_nac, string usuario, string pass, TipoCliente tipo) {
            this.id=id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.dni = dni;
            this.fecha_nac = fecha_nac;
            this.usuario = usuario;
            this.password = pass;
            this.tipo_cliente = tipo;
            this._contratos = null;
        }

        // ZONA DE MÉTODOS

        public static byte ComprobarDni(string dni) {
            byte codigoError = 0;
            int digitos = 0;

            if (dni.Length != 9) {
                codigoError = 1;
            }

            if (codigoError == 0) {
                //Console.WriteLine("ERROR 0... A COMPROBAR DNI INTERNO!");
                if (Int32.TryParse(dni.Substring(0, 7), out digitos))
                {
                    if (char.IsDigit(dni.ToUpper()[8]))
                    {
                        //Console.WriteLine("dni.oupper[8] error!!!:" + dni.ToUpper()[8]);
                        codigoError = 3; // Letra incorrecta
                    }
                    else {
                        if (!VerificarDNI(dni)) {
                            codigoError = 3;
                        }
                    }
                }
                else
                {
                    codigoError = 2; // Formato incorrecto
                }
            }
            return codigoError;
        }

     

        // FUNCIÓN PARA COMPROVAR LA LETRA DE UN DNI
        public static bool VerificarDNI(String dni)
        {
            bool valido = false;
            string numero = dni.Substring(0, 8);
            string letra = dni.Substring(8, 1).ToUpper();
            char letrachar;
            int esnumero = 0;
            int esletra = 0;
            int resto = 0;
            char letracalculada;
            char[] letrasdni = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

            //Console.WriteLine("numero " + numero + " letra:" + letra);
            if (Int32.TryParse(numero, out esnumero))
            {
                //Console.WriteLine("ES NUMERO-- CONTINUAMOS PARA LETRA");
                if (!Int32.TryParse(letra, out esletra))
                {
                    //Console.WriteLine("ES LETRA-- A COMPROBAR");
                    resto = esnumero % 23;
                    letracalculada = letrasdni[resto];
                    Char.TryParse(letra, out letrachar);
                    //Console.WriteLine("LETRA CALCULADA: " + letracalculada + " -> LEIDA: " + letra);
                    if (letracalculada == letrachar)
                    {
                        //Console.WriteLine("DNI CON LETRA CORRECTA");
                        valido = true;
                    }
                    else
                    {
                        //Console.WriteLine(">> ERROR EN LA LETRA!!");
                        valido = false;
                    }
                }
            }
            return valido;
        } // END FUNCION VERIFICACIÓN DNI


        // MÉTODO PÚBLICO PARA AGREGAR UN CONTRATO A
        // LA LISTA DE CONTRATOS DEL CLIENTE...
       public bool agregarContrato(Contrato contrato) {
            bool agregado = false;
            Contrato[] copia = null;

            if (_contratos == null)
            {
                _contratos = new Contrato[1];
            }
            else {
                copia = new Contrato[_contratos.Length];
                _contratos.CopyTo(copia, 0);
                _contratos = new Contrato[copia.Length + 1];
                copia.CopyTo(_contratos, 0);
                copia = null;
            }
            _contratos[_contratos.Length - 1] = contrato;
            agregado = true;
            return agregado;
        }

        // FUNCIÓN PARA OBTENER UN CONTRATO DETERMINADO X INDICE
        public Contrato obtenerContrato(int indice) {
            return _contratos[indice];
        }

        // MOSTRANDO LA INFORMACIÓN DEL OBJETO CON EL TOSTRING()
        override
        public string ToString() {
            string cadena = "";
            int contratos = 0;
            if (_contratos!=null) {
                contratos = this._contratos.Length;
            }
            cadena += "\nSOY UN CLIENTE\n";
            cadena += "==============\n";
            cadena += "ID........: " + this.id + "\n";
            cadena += "NOMBRE....: " + this.nombre + " " + this.apellidos + "\n";
            cadena += "DNI.......: " + this.dni + "\n";
            cadena += "FECHA NAC.: " + this.fecha_nac + "\n";
            cadena += "-----------\n";
            cadena += "USUARIO...: " + this.usuario + "\n";
            cadena += "PASSWORD..: " + this.password + "\n";
            cadena += "-------------\n";
            if (this.tipo_cliente!=null) {
                cadena += "TIPO CLIENTE: " + this.tipo_cliente.nombre + "\n";
            }
            cadena += "Nº CONTRATOS: " + contratos + "\n";
            return cadena;
        }
    }

}