using a_magical_kingdomDB.DATA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace a_magical_kingdomDB
{
    public class Service_kingdon
    {
        
        public List<Cities_Data> GetCities()
        {
            List<Cities_Data> Citieslist = new List<Cities_Data>();   
            using (StreamReader r = new StreamReader("jsonDB/Cities.json"))
            {
                string json = r.ReadToEnd();
                List<Cities_Data> Cities = JsonConvert.DeserializeObject<List<Cities_Data>>(json);
                Citieslist = Cities;
            }
          ;
            return Citieslist;   
        }
        public List<Streets_Data> GetStreets()
        {
            List<Streets_Data> Streetslist = new List<Streets_Data>();
            using (StreamReader r = new StreamReader("jsonDB/Streets.json"))
            {
                string json = r.ReadToEnd();
                List<Streets_Data> Streets = JsonConvert.DeserializeObject<List<Streets_Data>>(json);
                Streetslist = Streets;
            }
         ;
            return Streetslist;
        }
    }
}
