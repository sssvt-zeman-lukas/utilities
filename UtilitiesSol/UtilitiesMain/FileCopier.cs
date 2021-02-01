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
    public class FileCopierApp
    {
        private bool Copied = false;
        
        public void Copy(string sourcePath, string endPath)
        {
            List<string> text = new List<string>();

            StreamReader streamReader = new StreamReader(sourcePath);
            StreamWriter streamWriter = new StreamWriter(endPath);

            try
            {
                while (!streamReader.EndOfStream)
                {
                    text.Add(streamReader.ReadLine());
                }

                for (int i = 0; i < text.Count; i++)
                {
                    streamWriter.WriteLine(text[i]); 
                }

                Copied = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine("CHYBA! Při kopírování souborů došlo k této chybě:");
                Console.WriteLine(exception);
                Console.ReadKey(true);
            }
            finally
            {
                streamReader.Close();                
                streamReader.Dispose();
              
                streamWriter.Close();
                streamWriter.Dispose();
            }          
        }

        public bool copied
        {
            get { return Copied; }
        }
    }
}
