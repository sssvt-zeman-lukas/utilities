using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.CSV_Processing
{
    public class CSV_Creator
    {
        public void SaveCSV(string savePath, List<CellTower> cellTowers)
        {
            StreamWriter streamWriter = new StreamWriter(savePath);

            try
            {
                streamWriter.WriteLine("ISP;Cell_ID;PhysCID;Band;Location");

                foreach (CellTower cellTower in cellTowers)
                {
                    streamWriter.Write(cellTower.ISP + ";");
                    streamWriter.Write(cellTower.CID + ";");
                    streamWriter.Write(cellTower.PhysCID + ";");
                    streamWriter.Write(cellTower.Band + ";");
                    streamWriter.Write(cellTower.Location);
                    streamWriter.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }
    }
}
