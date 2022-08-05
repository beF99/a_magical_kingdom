using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_magical_kingdomDB.DATA
{
    public class Cities_Data
    {
        private string streetName;

        public Cities_Data(string streetName, int cityId)
        {
            this.streetName = streetName;
            CityId = cityId;
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
