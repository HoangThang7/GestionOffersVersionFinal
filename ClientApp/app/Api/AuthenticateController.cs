using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GestionOffer.ClientApp.app.Repository;
using GestionOffer.Dto;
using GestionOffers.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app.Api
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private static UserRepository userRepository = new UserRepository();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public User Post([FromBody]Authenticater user)
        {
            try
            {
                Console.WriteLine(user);
                User newUser = new User();
                var res = userRepository.GetIdentity(user.email);

                if (res != null)
                {
                    MD5 md5hash = MD5.Create();
                    byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(user.password));
                    StringBuilder sBuilder = new StringBuilder();
                    StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    if (0 == comparer.Compare(res.password,sBuilder.ToString()))
                    {
                        return res;
                    }
                    else
                    {
                        return newUser;
                    }
                }
                else
                {
                    return newUser;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }

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
