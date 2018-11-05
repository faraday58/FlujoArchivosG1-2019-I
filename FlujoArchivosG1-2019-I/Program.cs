using System;
using System.IO;
namespace FlujoArchivosG1_2019_I
{
    class Program
    {
        static void Main()
        {
            StreamWriter sw = null;
            FileStream fs= null;
            StreamReader sr = null;


            try
            {
             
                fs = new FileStream("texto1.txt", FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
                Console.WriteLine("Escriba una calaverita para almacenar \n" +
                    "Para finalizar cada línea pulse <Enter> \n" +
                    "Para finalizar la calaverita pulse dos veces <Enter> ");
                string texto = Console.ReadLine();
                while(texto.Length !=0)
                {
                    sw.WriteLine(texto);
                    texto = Console.ReadLine();
                }

                Console.WriteLine("Estoy verificando tu calaverita ;) \n");



            }
            catch(IOException error)
            {
                Console.WriteLine("Error: " + error.Message);
            }
            finally
            {
                
                sw.Close();
                fs.Close();

            }

            try
            {
                sr = new StreamReader("texto1.txt");
                string aux = sr.ReadLine();

                while(aux!= null)
                {
                    Console.WriteLine(aux);
                    aux = sr.ReadLine();
                }
            }

            catch(IOException error)
            {
                Console.WriteLine("Error: " + error.Message);
            }

            finally
            {
                sr.Close();
            }
        }
    }
}
