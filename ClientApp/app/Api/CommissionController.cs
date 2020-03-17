using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestionOffer.ClientApp.app.Repository;
using GestionOffer.Dto;
using GestionOffer.Models;
using log4net;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app.Api
{
    [Route("api/[controller]")]
    public class CommissionController : Controller
    {
        private static CommissionRepository commissionRepository = new CommissionRepository();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<CommissionDto> Get()
        {

            List<CommissionDto> listCommission = new List<CommissionDto>();
            try
            {
                return commissionRepository.GetCommissions().ToList();
              
            }
            catch (Exception e)
            {
                Debug.WriteLine("ListUser Get : " + e.Message + "||" + e.StackTrace);
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
        public bool Post([FromBody]CommissionDto commission)
        {
            Console.WriteLine(commission);

            return commissionRepository.addCommission(commission);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
           return commissionRepository.DeleteById(id);
        }
    }
}
