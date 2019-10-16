using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando proceso");
            var client = new Alumnos.Practice_1_Create_alumno_Port_1Client();
            var request = new Alumnos.Request_system();
            var response = new Alumnos.Response_system();

            client.Open();
            request.Nombre = "Lauro";
            request.Apellidos = "Rosales Leon";
            request.Edad = "28";

            response = client.Que_pedo(request);
            Console.WriteLine("El response de BT fué: " +response.result);
            Console.ReadLine();

        }
    }
}
