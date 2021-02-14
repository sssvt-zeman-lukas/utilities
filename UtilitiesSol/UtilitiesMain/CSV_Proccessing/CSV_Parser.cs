using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.CSV_Processing
{
    public class CSV_Parser
    {
        public List<CellTower> LoadCSV(string filePath)
        { 
            List<CellTower> cellTowers = new List<CellTower>();
            bool firstLine = true;

            StreamReader streamReader = new StreamReader(filePath);

            try
            {
                while (!streamReader.EndOfStream)
                {                    
                    string line = streamReader.ReadLine();
                    string[] separatedData = line.Split(';');

                    if (firstLine)
                    {
                        if (!int.TryParse(separatedData[1], out int result))
                        {
                            firstLine = false;
                            continue;
                        }
                        else
                        {
                            firstLine = false;
                        }
                    }

                    cellTowers.Add(new CellTower(separatedData[0], Convert.ToInt32(separatedData[1]), Convert.ToInt32(separatedData[2]), Convert.ToInt32(separatedData[3]), separatedData[4]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                streamReader.Close();
                streamReader.Dispose();
            }

            return cellTowers;
        }
    }
}
