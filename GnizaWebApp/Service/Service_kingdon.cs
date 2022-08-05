using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using magical_kingdom.DATA;

namespace magical_kingdom
{
    public class Service_kingdon
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<Cities_Data> GetCities()
        {
            List<Cities_Data> Citieslist = new List<Cities_Data>();
            try
            {
                using (StreamReader r = new StreamReader("jsonDB/Cities.json"))
                {
                    string json = r.ReadToEnd();
                    List<Cities_Data> Cities = JsonConvert.DeserializeObject<List<Cities_Data>>(json);
                    Citieslist = Cities;
                } ;
                return Citieslist;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                return null;
            }
           
               
        }
        public List<Streets_Data> GetStreets()
        {
            List<Streets_Data> Streetslist = new List<Streets_Data>();
            try
            {
                using (StreamReader r = new StreamReader("jsonDB/Streets.json"))
                {
                    string json = r.ReadToEnd();
                    List<Streets_Data> Streets = JsonConvert.DeserializeObject<List<Streets_Data>>(json);
                    Streetslist = Streets;
                } ;
                return Streetslist;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                return null;
            }
        }

        public void InsertNewStreet(string streetName, int cityId)
        {
            try
            {
                var initialJson = File.ReadAllText("jsonDB/Streets.json");

                var array = JArray.Parse(initialJson);
                int num= array.Select(obj => obj["streetId"].Value<int>()).LastOrDefault();
                var itemToAdd = new JObject();
                itemToAdd["streetId"] = num + 1;
                itemToAdd["streetName"] = streetName;
                itemToAdd["cityId"] = cityId;

                array.Add(itemToAdd);

                var jsonToOutput = JsonConvert.SerializeObject(array, Formatting.Indented);
                File.WriteAllText("jsonDB/Streets.json", jsonToOutput);

                log.Info(": InsertNewStreet is successfully");

            }
            catch (Exception ex)
            {
                log.Error(": InsertNewStreet Get Erro: " + ex.Message);
            }
            finally
            {
                log.Info(": InsertNewStreet is finish");
            }

        }
        public void UpdateStreet(int streetId, string streetName, int cityId)
        {

            try
            {
                 string jsonString = File.ReadAllText("jsonDB/Streets.json");
                 var array = JArray.Parse(jsonString);
                 
                 
                 var companyToDeleted = array.Where(obj => obj["streetId"].Value<int>() == streetId).FirstOrDefault();
                 
                     JToken jToken = companyToDeleted.SelectToken("streetName");
                 jToken.Replace(streetName);
                  
                 string updatedJsonString = JsonConvert.SerializeObject(array, Formatting.Indented);
                 File.WriteAllText("jsonDB/Streets.json", updatedJsonString);

                log.Info(": UpdateStreet is successfully");

            }
            catch (Exception ex)
            {
                log.Error(": UpdateStreet Get Erro: " + ex.Message);
            }
            finally
            {
                log.Info(": UpdateStreet is finish");
            }
        }

        public void DeleteStreet(int streetId)
        {
            try
            {
            string jsonString = File.ReadAllText("jsonDB/Streets.json");
            var arr = JArray.Parse(jsonString);

                var companyToDeleted = arr.Where(obj => obj["streetId"].Value<int>() == streetId).ToList();

            foreach (var item in companyToDeleted)
            {
                arr.Remove(item);
            }
            string updatedJsonString = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText("jsonDB/Streets.json", updatedJsonString);

                log.Info(": DeleteStreet is successfully");

            }
            catch (Exception ex)
            {
                log.Error(": DeleteStreet Get Erro: " + ex.Message);
            }
            finally
            {
                log.Info(": DeleteStreet is finish");
            }
        }

    }
}
