using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.HouseBuilder
{
    public class HouseBuilder_Floor
    {
        public int FloorNumber;
        public string FloorDescription;
        public List<HouseBuilder_Flat> Flat;

        public HouseBuilder_Floor(int FloorNumber, string FloorDescription, List<HouseBuilder_Flat> Flat)
        {
            this.FloorNumber = FloorNumber;
            this.FloorDescription = FloorDescription;
            this.Flat = Flat;
        }
    }
}
