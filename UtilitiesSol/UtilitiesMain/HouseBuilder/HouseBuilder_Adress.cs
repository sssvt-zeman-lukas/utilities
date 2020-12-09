using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain.HouseBuilder
{
    public class HouseBuilder_Adress
    {
        public string Adress;
        public int HouseNumber;
        public string City;
        public int PostalCode;

        public HouseBuilder_Adress(string Adress, int HouseNumber, string City, int PostalCode)
        {
            this.Adress = Adress;
            this.HouseNumber = HouseNumber;
            this.City = City;
            this.PostalCode = PostalCode;
        }
    }
}
