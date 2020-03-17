using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GestionOffer.ClientApp.app.Repository;
using GestionOffer.Dto;
using GestionOffer.Models;
using GestionOffers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app.Api
{
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private static FileRepository fileRepository = new FileRepository();
        

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<FileResult> Get(int id)
        {
            try
            {
                return fileRepository.GetFiles(id);
                
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
            
        }

        // POST api/<controller>
        [HttpPost]
        public void Post()
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
