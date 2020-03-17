using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GestionOffer.ClientApp.app.Repository;
using GestionOffer.Models;
using log4net;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app.Api
{
    [Route("api/[controller]")]
    public class DirectionController : Controller
    {

        private static DirectionRepository directionRepository = new DirectionRepository();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Direction> Get()
        {

                 
            try
            {
                return directionRepository.GetList().ToList();
             
            }
            catch (Exception e)
            {
                Log.Error("ListUser Get : " + e.Message + "||" + e.StackTrace);
                throw;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
