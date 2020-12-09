using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.HouseBuilder
{
    public class HouseBuilder_Door
    {
        public double Width;
        public double Height;
        public bool TwoSided;

        public HouseBuilder_Door(double Width, double Height, bool TwoSided)
        {
            this.Width = Width;
            this.Height = Height;
            this.TwoSided = TwoSided;
        }
    }
}
