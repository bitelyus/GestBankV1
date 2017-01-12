using System;

namespace GestBankV1.src.Modelo
{
    class Contrato {

        private int _id;
        private int _id_cliente;
        private int _id_producto;
        private DateTime _fecha_contratacion;
        private DateTime _fecha_finalizacion;
        private float _importe;
        private Boolean _activo;
        private Producto _producto;
        
        public static int contratos = 0;

        public int id {
            get {
                return _id;
            }
            set {
                if (value<0) {
                    throw new Exception("Introduce un id positvo!");
                }
                _id=value;
            }
        }

        public int id_cliente {
            get {
                return _id_cliente;
            }
            set {
                _id_cliente=value;
            }
        }

        public int id_producto {
            get {
                return _id_producto;
            }
            set {
                _id_producto=value;
            }
        }

        public Producto producto {
            get {
                return _producto;
            }
            set {
                _producto=value;
            }
        }
        
        public string fecha_contratacion {
            get {
                return _fecha_contratacion.ToString();
            }
            set {
                DateTime.TryParse(value,out _fecha_contratacion);
            }
        }

        public string fecha_finalizacion {
            get {
                return _fecha_finalizacion.ToString();
            }
            set {
                DateTime.TryParse(value,out _fecha_finalizacion);
            }
        }

        public float saldo {
            get {
                return _importe;
            } 
            set {
                if (value<0) {
                    throw new Exception("Introduce un importe positivo!!!");
                }
                _importe=value;
            }
        }

        public Boolean activo {
            get {
                return _activo;
            }
            set {
                _activo=value;
            }
        }

        // ZONA DE CONSTRUCTORES

        public Contrato() {
            this.id=0;
            this.id_cliente=0;
            this.id_producto=0;
            this.fecha_contratacion="";
            this.fecha_finalizacion="";
            _fecha_contratacion = new DateTime();
            this.saldo=0.0F;
            this.activo=false;
            this.producto=null;
        }

        public Contrato(int id, int id_cli, int id_prod, string fecha_inicio, string fecha_fin, float importe,Boolean activo,Producto producto) {
            this.id=id;
            this.id_cliente=id_cli;
            this.id_producto=id_prod;
            this.fecha_contratacion=fecha_inicio;
            this.fecha_finalizacion=fecha_fin;
            this.saldo=importe;
            this.activo=activo;
            this.producto=producto;
        }

        // ZONA DE MÉTODOS 

        // MÉTODO PARA INGRESAR DINERO EN CUENTA

        public void ingreso(float cantidad) {
            this._importe+=cantidad;
        }

        public bool reintegro(float cantidad) {
            bool realizado=false;
            if (cantidad>this.saldo) {
                this.saldo-=cantidad;
            }
            return realizado;
        }

        // MÉTODO PARA SACAR DINERO DE LA CUENTA

        override
        public string ToString()
        {
            string salida = "";
            salida += "SOY UN CONTRATO\n";
            salida += "===============\n";
            salida += "ID.........: " + this.id + "\n";
            salida += "ID_CLIENTE.: " + this.id_cliente + "\n";
            salida += "ID_PRODUCTO: " + this.id_producto + "\n";
            salida += "PRODUCTO...: " + this.producto.nombre + "\n";
            salida += "FECHA CONTRATACION: " + this.fecha_contratacion + "\n";
            salida += "FECHA FINALIZACION: " + this.fecha_finalizacion + "\n";
            salida += "SALDO/IMPORTE.....: " + this.saldo + " €\n";
            salida += "PRODUCTO ACTIVO...: "; 
            estaActivo(ref salida);
            salida += "\n";
            return salida;
        }

        // NO ENTIENDO PORQUE PERO PEDÍA QUE SE HICIERA EL TERNARIO CON UN MÉTODO
        private string estaActivo(ref string salida) 
        {
            return this.activo == true ? salida += "SI" : salida += "NO";
        }
    }
}