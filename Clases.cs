using MySql.Data.MySqlClient;
using System.Data;

namespace libreriaClase{
    class Persona
    {

//        private string nombre;


        public string Apellido {get;set;}
        public string Nombre {get;set;}
        public int DNI {get;set;}
        public string FechaNacimiento {get;set;}


       

        public  Persona(string rApellido,string rNombre, string rFechaNacimiento, int rDni){
            Apellido = rApellido;
            Nombre = rNombre;
            FechaNacimiento = rFechaNacimiento;
            DNI = rDni;

        }

        public Persona(){
            
        }
        public string caminar(){

            return "Caminando....";

        }

        public void mostrarPersona(){
            Console.WriteLine("Apellido: {0}", Apellido);
            Console.WriteLine("Nombre: {0}", Nombre);
            Console.WriteLine("Fecha Nacimiento: {0}", FechaNacimiento);
            Console.WriteLine("DNI: {0}", DNI);
        }

        public void devolverEdad(){
            Console.WriteLine("La edad es:.....");
        }

    }

    class Alumno : Persona {

        private int legajo;
        private string curso;

        private int[] notas;


        public void estudiar(){
            Console.WriteLine("Estudiando....");
        }

        public void devolverCurso(){
            Console.WriteLine("El curso es: {0}", this.curso);
        }
    }

    class conexionBD{

        MySqlConnection Conector; 
        MySqlCommand Comando;

        public void conectar(){

            Conector = new MySqlConnection(@"server=127.0.0.1; database=5to_Escuela; Uid=5to_agbd; pwd=Trigg3rs!");
            Comando = Conector.CreateCommand();

        }

        public void insertarBD(Persona rPersona){

                Comando.CommandText = "insert into Persona (DNI,Apellido,Nombre,FechaNacimiento)  values ('" + rPersona.DNI + "', '" + rPersona.Apellido + "','" + rPersona.Nombre + "','" + rPersona.FechaNacimiento + "')";

                Comando.CommandType = CommandType.Text;
                Conector.Open();
                Comando.ExecuteNonQuery();    
                Conector.Close();        

        }
        public object countPersonnameBD(string rNombre){

            object cantidadObjeto;

                Comando.CommandText = "select count(*) from Persona where Nombre = '"+ rNombre +"'";

                Comando.CommandType = CommandType.Text;
                Conector.Open();
                cantidadObjeto = Comando.ExecuteScalar();                    
                Conector.Close();     
            
            return cantidadObjeto;   

        }
        public void MostrarAlumno(){

            // string sql = "select DNI, Apellido, Nombre from Persona where Apellido" 
            string Sql = "select * from Persona";
            Comando.CommandText = Sql; 
            Conector.Open();
            MySqlDataReader datos = Comando.ExecuteReader();

            while (datos.Read()){
                Console.Write("Apellido: ");
                Console.WriteLine(datos[2]);
                Console.Write("Nombre: ");
                Console.WriteLine(datos[3]);
                Console.Write("DNI: ");
                Console.WriteLine(datos[1]);
                Console.Write("Fecha Nacimiento: ");
                Console.WriteLine(datos[4]);
                Console.WriteLine("-------------");

            }
            // Console.WriteLine(datos[0]+"..."+datos[1]);
            datos.Close();

        }
        public static void EliminarBD(){
            
        }
    }
}