using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.HouseBuilder
{
    public class HouseBuilder_Window
    {
        public string Name;
        public double Width;
        public double Height;

        public HouseBuilder_Window(string Name, double Width, double Height)
        {
            this.Name = Name;
            this.Width = Width;
            this.Height = Height;
        }
    }
}
