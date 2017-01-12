using System;

namespace GestBankV1.src.Modelo 
{
    class Producto {

        // ZONA DE ATRIBUTOS O MIEMBROS
        public int id;
        public string nombre;
        private string _descripcion;
        private float _tipo_interes;
        public Boolean activo;
        
        // Getters & Setters

        public string descripcion {
            get {
                if (_descripcion==null) {
                    _descripcion="Sin descripcion";
                }
                return _descripcion;
            }
            set {
                _descripcion=value;
            }

        }

        public float tipo_interes { // puede ser negativo
            get {
                return _tipo_interes;
            }
            set {
                _tipo_interes=value;
            }
        }
        
        // ZONA DE CONSTRUCTORES
        // CONSTRUCTOR VACIO        
        public Producto() {
            this.id=0;
            this.nombre="";
            this.descripcion="";
            this.tipo_interes=0.0F;
            this.activo=false;
        }

        // CONSTRUCTOR CON TODOS LOS DATOS
        public Producto(int id, string nombre, string descripcion, float tipo, Boolean activo) {
            this.id=id;
            this.nombre=nombre;
            this.descripcion=descripcion;
            this.tipo_interes=tipo;
            this.activo=activo;
        }

        // ZONA DE MÉTODOS
        override
        public String ToString() {
            string salida = "";
            salida+="SOY UN PRODUCTO\n";
            salida+="===============\n";
            salida+="CÓDIGO......: " + this.id + "\n";
            salida+="NOMBRE......: " + this.nombre + "\n";
            salida+="DESCRIPCION.: " + this.descripcion + "\n";
            salida+="TIPO INTERES: " + this.tipo_interes + "%\n";
            return salida;
        }

    }
}