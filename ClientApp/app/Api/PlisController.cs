using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GestionOffer.ClientApp.app.Repository;
using GestionOffer.Models;
using log4net;
using Microsoft.AspNetCore.Mvc;
using GestionOffer.Dto;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app.Api
{
    [Route("api/[controller]")]
    public class PlisController : Controller
    {

        private static PlisRepository plisRepository = new PlisRepository();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public PlisDto Get(int id)
        {
            return plisRepository.getPlis(id);
        }

        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]PlisDto plis)
        {
           
            Console.WriteLine(plis);
            return plisRepository.PostPlis(plis);
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]PlisDto plis)
        {
            return plisRepository.updatePlis(id, plis);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                return plisRepository.DeleteById(id);
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }
    }
}
