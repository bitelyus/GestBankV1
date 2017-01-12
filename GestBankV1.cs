using GestBankV1.src.Controlador;

// PREGUNTAS PARA JESUS:

// 1. COMO MODIFICAR CORRECTAMENTE LOS DATOS DE UN OBJETO?
// - con variables temporales? directamente en cada campo de objeto?
// -> AL OBJETO DIRECTAMENTE....


// 2. RECORDAR TEMA COMPARACION DE OBJETOS, A RAIZ DEL EXAMEN...
// -> 

// 3. USEMOS YA LOS ARRAYLIST!! PORFAVO... Y ENTORNO GRÁFICO!! .. PORQUE NO PUEDO USARLOS?? ArrayList no esta disponible!!


// 4. ES LO MISMO PASAR LA BANKA ENTERA COMO ARGUMENTO O SOLO EL OBJETO
//      QUE NECESITEMOS MANIPULAR? -- SUPONGO QUE NO POR EL TRAMAÑO DE TRAFICO DE DATOS, NO?

// 5. SI DESDE VARIOS CONTROLADORES TENGO QUE ACCEDER A UN MISMO METODO DE UNA INTERFAZ?? -- EN CUAL COLOCARLO??
// -> EN UNO GENERAL PARA TODOS O EN EL DE SU PROPIA NATURALEZA 

// 6. DONDE ESTA? O COMO SE CREA EL EJECUTABLE PARA TODO ESTO??


namespace ConsoleApplication
{
    public class GestBankV1
    {
        //ArrayList ads = new ArrayList();
        public static void Main(string[] args)
        {
            ControladorBanka.comenzar();
        }
    }
}

// PARA ACTUALIZAR EL REPOSITORIO REMOTO
// GIT: git remote add origin https://github.com/bitelyus/GestBankV1.git
// GIT: git push -u origin master

// RESETEAR REPOSITORIO LOCAL GIT
// GIT: rm -rf .git
// GIT: git init

// NOTAS
// 1. los puntos no los coge como decimal para el leerCantidad o float... tratarlo!, cambiar punto por coma