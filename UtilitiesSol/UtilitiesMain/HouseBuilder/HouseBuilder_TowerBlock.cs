using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.HouseBuilder
{
    public class HouseBuilder_TowerBlock
    {
        public HouseBuilder_Adress Adress;
        public List<HouseBuilder_Floor> Floors;

        public HouseBuilder_TowerBlock(HouseBuilder_Adress Adress, List<HouseBuilder_Floor> Floors)
        {
            this.Adress = Adress;
            this.Floors = Floors;
        }
    }
}
