using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.CSV_Processing
{
    public class CSV_Tester
    {
        public void TestCSV()
        {
            List<CellTower> savedCellTowers = new List<CellTower>();
            
            CSV_Parser parser = new CSV_Parser();
            savedCellTowers = parser.LoadCSV(@"D:\Projects\School\Programming\003_ThirdGrade\Utilities\utilities\UtilitiesSol\csvFiles\sourceCSV\CellTowers_ZemanLukas.csv");

            foreach (CellTower cellTower in savedCellTowers)
            {
                Console.Write(cellTower.ISP + ";");
                Console.Write(cellTower.CID + ";");
                Console.Write(cellTower.PhysCID + ";");
                Console.Write(cellTower.Band + ";");
                Console.Write(cellTower.Location);
                Console.WriteLine();
            }

            List<CellTower> newCellTowers = new List<CellTower>();
            newCellTowers.Add(new CellTower("Vodafone", 129725, 1, 1800, "Kourim, Mirove namesti"));
            newCellTowers.Add(new CellTower("Vodafone", 124235, 281, 2100, "Kostelec nad Cernymi lesy, vez kostela"));
            newCellTowers.Add(new CellTower("T-Mobile", 183255, 390, 800, "Korenice, hydroglobus"));
            newCellTowers.Add(new CellTower("T-Mobile", 184115, 21, 1800, "Zdanice, obecni urad"));
            newCellTowers.Add(new CellTower("O2", 198120, 66, 800, "Bulanka, hydroglobus"));

            CSV_Creator creator = new CSV_Creator();
            creator.SaveCSV(@"D:\Projects\School\Programming\003_ThirdGrade\Utilities\utilities\UtilitiesSol\csvFiles\newCSV\NewCellTowers.csv", newCellTowers);
        }
    }
}
