using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PracticaEvaluativa1
{
   public class Operacion
   {
        //Se instancia la lista de persona
        List<Persona> personas = new List<Persona>();
        //El metodo welcome que es donde el usuario podra poner el id de alguno de los agregados en la lista
        //ára de esa forma llamar sus datos.
        public void Welcome()
        {
            Persona p = new Persona();
            Console.WriteLine("---BIENVENIDOS---");

            Console.WriteLine("¿Desea Buscar usuarios en la lista?");
            Console.WriteLine("\n1-.Si\n2-.No");
            //Como solo son dos opciones solo use un if 
            if (Console.ReadLine() == "Si")
            {
                Console.WriteLine("Ingresa el Id:");
                p.Id = Convert.ToInt32(Console.ReadLine());
                //Se manda como parametro el id ingresado para ser evaluado
                BuscarPersona(p.Id);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        //El metodo BuscarPersona recibira el id ingresado por el usuario
        public Persona BuscarPersona(int id)
        {
            //La variable personas almacenara el metodo ObtenerPersona mandando el id que uso el usuario
            var personas = ObtenerPersona(id);
           //Se utiliza para que se haga el paso por personas si el id de persona concuerda con el ingresao
           //Este retornora la cadena
            var p = (from Persona in personas
                     where Persona.Id == id
                     select Persona).First();

            return p;
        }
        public List<string> ObtenerLineas()
        {
            //Utilizamos el try para cuando no se encuentre el documento
            try
            {
                List<string> lineas = new List<string>();
                //Hacemos un arreglo de string 
                string[] data = null;
                //Se hace la condicion para que si el documento existe se lean las lineas
                if (File.Exists("Datos.txt"))
                {

                    //Se almacenen en data que es donde tenemos nuestro arreglo de string
                    data = File.ReadAllLines("Datos.txt");

                }
                //Se hace el foreach para pasar por todos los valores almacenados en data y agregarlos 
                //en una lista 
                foreach (string iteam in data)
                {
                    lineas.Add(iteam);
                    
                }
                //la lista se retorna para que el programa compare los valores
                return lineas;
             
            }
            //El catch para que el programa capture el error en dado caso no exista un documento
            catch (System.Exception)
            {

                Console.WriteLine("Error con el documento");
            }
            return null;
        }


        //Se usa el metodo de tipo list para retornar los valores de la lista
        public List<Persona> ObtenerPersona(int id)
        {

            var lineas = ObtenerLineas();
            //Se usa un foreach para pasar por lineas y evaluar
            foreach (string p in lineas)
            {
                //Se usa un arreglo de string para cortar la cadena
                string[] info = p.Split(',');


                //Se instancia persona y se asignan las variables en su posicion en el arreglo
                Persona persona = new Persona
                {
                    Id = int.Parse(info[0]),
                    Nombre = info[1],
                    Profesion = info[2],
                    Edad = int.Parse(info[3]),

                };
                //Se agrega persona en la lista 
                personas.Add(persona);

                //Se hace la condicion para mostrar la fila del id agregado
                //Si el id que mandamos como parametro es igual al alguno de la lista 
                if (id == persona.Id)
                {
                    //Entonces se imprimira la cadena
                    Console.WriteLine(persona.Id + "-" + persona.Nombre + "-" + persona.Profesion + "-" + persona.Edad);
                    Console.ReadKey();
                    Console.Clear();
                    Welcome();

                }
            
        


            }
                //Se retorna la lista
            return personas;
        }
      
    }
}
