using System;

namespace GestBankV1.src.Modelo {
    class TipoEmpleado {
        
        // ZONA DE ATRIBUTOS

        private string _nombre;
        private byte _nivel_acceso;

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

        public byte nivel_acceso {
            get {
                if (_nivel_acceso==0) {
                    throw new Exception("No se indicó operación nivel de acceso");
                }
                return _nivel_acceso;
            }
            set {
                if (value<0) {
                    throw new Exception("Introdcue alguna cantidad positiva");
                }
                _nivel_acceso=value;
            }
        }


        // ZONA DE CONSTRUCCTORES

        public TipoEmpleado() { 
            _nombre = null;
            _nivel_acceso = 0;
        }

        public TipoEmpleado(string nombre, byte nivel) {
            this.nombre=nombre;
            this.nivel_acceso=nivel;
        }
      
        override
        public string ToString() {
            string cadena = "\n";
            cadena += "SOY UN TIPO DE EMPLEADO\n";
            cadena += "=======================\n";
            cadena += "TIPO EMPLEADO..: " + this.nombre + "\n";
            cadena += "NIVEL DE ACCESO: " + this.nivel_acceso + "\n";
            return cadena;
        }
    }
}

