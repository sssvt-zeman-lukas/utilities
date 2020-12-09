using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.HouseBuilder
{
    public class HouseBuilder_Flat
    {
        public double Width;
        public double Height;
        public HouseBuilder_Door Door;
        public HouseBuilder_Window Window1;
        public HouseBuilder_Window Window2;

        public HouseBuilder_Flat(double Width, double Height, HouseBuilder_Door Door, HouseBuilder_Window Window1, HouseBuilder_Window Window2)
        {
            this.Width = Width;
            this.Height = Height;
            this.Door = Door;
            this.Window1 = Window1;
            this.Window2 = Window2;
        }
    }
}
