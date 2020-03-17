using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionOffer.ClientApp.app.Repository;
using GestionOffer.Dto;
using GestionOffer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app.Api
{
    [Route("api/[controller]")]
    public class DepouillementController : Controller
    {
        private static DepouillementRepository depouillementRepository = new DepouillementRepository();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Depouillement Get(int id)
        {
            return depouillementRepository.GetDepouille(id);
        }

        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]DepouillementDto depouille)
        {
            Console.WriteLine(depouille);
            return depouillementRepository.PostDepouille(depouille);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]Depouillement depouille)
        {
            Console.WriteLine(id);
            Console.WriteLine(depouille);
            return depouillementRepository.UpdateDepouille(id, depouille);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return depouillementRepository.DeleteById(id);
        }
    }
}
