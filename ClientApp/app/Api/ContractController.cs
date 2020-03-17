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
    public class ContractController : Controller
    {
        private static ContractRepository contractRepository = new ContractRepository();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Contract Get(int id)
        {
            return contractRepository.getContract(id);
        }

        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]ContractDto contract)
        {
            Console.WriteLine(contract);
            return contractRepository.PostContract(contract);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]Contract contract)
        {
            Console.WriteLine(id);
            Console.WriteLine(contract);
            return contractRepository.UpdateContract(id, contract);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return contractRepository.DeleteById(id);
        }
    }
}
