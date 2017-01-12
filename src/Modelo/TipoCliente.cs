using System;

namespace GestBankV1.src.Modelo {
    class TipoCliente {
        
        // ZONA DE ATRIBUTOS

        private string _nombre;
        private float _saldo_minimo;
        private float _operacion_maxima;

        // GETTERS & SETTERER PARA ATRIBUTOS PRIVADOS
        public string nombre {
            get {
                if (_nombre==null) {
                    throw new Exception("Nombre Vacío!!");
                }
                return _nombre;
            }
            set {
                if (value=="") {
                    throw new Exception("Introduce algún Nombre!!");
                }
                _nombre = value;
            }
        }

        public float saldo_minimo {
            get {
                if (_saldo_minimo==0) {
                    throw new Exception("No se indicó saldo mínimo");
                }
                return _saldo_minimo;
            }
            set {
                if (value<0) {
                    throw new Exception("Introduce alguna cantidad positiva");
                }
                _saldo_minimo=value;
            }
        }

        public float operacion_maxima {
            get {
                if (_operacion_maxima==0) {
                    throw new Exception("No se indicó operación inferior o igual a...");
                }
                return _operacion_maxima;
            }
            set {
                if (value<0) {
                    throw new Exception("Introdcue alguna cantidad positiva");
                }
                _operacion_maxima=value;
            }
        }


        // ZONA DE CONSTRUCCTORES

        public TipoCliente() { 
            _nombre = null;
            _saldo_minimo = 0.0F;;
            _operacion_maxima = 0.0F;
        }

        public TipoCliente(string nombre, float saldo_minimo, float op_maxima) {
            this.nombre=nombre;
            this.saldo_minimo=saldo_minimo;
            this.operacion_maxima=op_maxima;
        }
      
        override
        public string ToString() {
            string cadena = "\n";
            cadena += "SOY UN TIPO DE CLIENTE\n";
            cadena += "======================\n";
            cadena += "NOMBRE TIPO.: " + this.nombre + "\n";
            cadena += "SALDO MÍNIMO: " + this.saldo_minimo + "\n";
            cadena += "OPER. MÁXIMA: " + this.operacion_maxima + "\n";
            return cadena;
        }
    }
}

