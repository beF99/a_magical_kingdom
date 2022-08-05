using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magical_kingdom.DATA
{
    public class Streets_Data
    {
        private int v;

        public Streets_Data(int v, string streetName, int cityId)
        {
            this.v = v;
            StreetName = streetName;
            CityId = cityId;
        }

        public int StreetId { get; set; }
        public string StreetName { get; set; }
        public int CityId { get; set; }
    }
}
