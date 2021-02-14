using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.CSV_Processing
{
    public class CellTower
    {
        private string InternetServiceProvider;
        private int CellID;
        private int PhysicalCellID;
        private int FrequencyBand;
        private string CellTowerLocation;

        public CellTower(string ISP, int CID, int PhysCID, int Band, string Location)
        {
            InternetServiceProvider = ISP;
            CellID = CID;
            PhysicalCellID = PhysCID;
            FrequencyBand = Band;
            CellTowerLocation = Location;
        }

        public string ISP
        {
            get { return InternetServiceProvider; }
        }

        public int CID
        {
            get { return CellID; }
        }

        public int PhysCID
        {
            get { return PhysicalCellID; }
        }

        public int Band
        {
            get { return FrequencyBand; }
        }

        public string Location
        {
            get { return CellTowerLocation; }
        }
    }
}
