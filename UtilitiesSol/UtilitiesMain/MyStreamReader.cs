using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UtilitiesMain
{
    //vytvořeno: 21.10.; dokončeno: 28.10.
    public class MyStreamReader
    {
        public string ReadFile(string pathToFile)
        {            
            string option;

            try
            {
                StreamReader streamReader = new StreamReader(pathToFile);

                Console.WriteLine();
                Console.WriteLine("Obsah souboru: ");

                while (streamReader.EndOfStream == false)
                {
                    Console.WriteLine(streamReader.ReadLine());
                }

                streamReader.Close();
                streamReader.Dispose();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write("Při výpisu vašeho souboru došlo k chybě! A to k následující: ");
                Console.WriteLine(e);                
            }
            finally
            {               
                Console.ReadKey();
                Console.WriteLine("---");
                Console.WriteLine("Chcete vypsat další soubor?");
                Console.WriteLine("[A] - Ano    [Jiná klávesa] - Ne");
                Console.WriteLine("---");
                Console.Write("Ano nebo ne?: ");
                option = Console.ReadLine();
                Console.Clear();                
            }

            return option;
        }
    }
}
