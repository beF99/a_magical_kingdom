using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using magical_kingdom;
using magical_kingdom.DATA;
using Microsoft.AspNetCore.Mvc;

namespace magical_kingdom.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       

        [HttpGet]
        public int GetPlaceTable()
        {
            return 33;
        }
        Service_kingdon SK = new Service_kingdon();
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Cities_Data> GetCities()
        {
            return SK.GetCities();
        }

        // GET: api/<StreetsController1>
        [HttpGet]
        public List<Streets_Data> GetStreets()
        {
            return SK.GetStreets();
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }


        // POST api/values
        [HttpPost]
        public void InsertNewStreet( string streetName, int cityId)
        {
            SK.InsertNewStreet(streetName, cityId);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        // PUT api/values
        [HttpPut]
        public void UpdateStreet(int streetId, string streetName, int cityId)
        {
            SK.UpdateStreet(streetId, streetName, cityId);
        }

        // PUT api/values
        [HttpPut]
        public void DeleteStreet(int streetId)
        {
            SK.DeleteStreet(streetId);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
       // //DELETE api/values
       //[HttpDelete]
       // public void DeleteStreet(int streetId)
       // {
       //     SK.DeleteStreet(streetId);
       // }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
