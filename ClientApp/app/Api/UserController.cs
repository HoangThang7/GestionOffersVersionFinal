using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GestionOffer.ClientApp.app.Repository;
using GestionOffers.Models;
using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private static AddressRepository addressRepository = new AddressRepository();
        private static UserRepository userRepository = new UserRepository();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET: api/<controller>
        [HttpGet("{id}")]
        public User GetCurrentUser(string id)
        {
            try
            {
                var res = userRepository.GetIdentity(id);

                if (res.mail.ToArray().Length > 0)
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Log.Error("user Get : " + e.Message + "||" + e.StackTrace);
                throw;
            }

        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            List<User> listUser = new List<User>();

            try
            {
                return userRepository.GetListUser().ToList();
                         
            }
            catch (Exception e)
            {
                Log.Error("ListUser Get : " + e.Message + "||" + e.StackTrace);
                throw;
            }

        }




        // POST api/<controller>
        [HttpPost]
        public User Post([FromBody]User user)
        {
            try
            {
                Console.WriteLine(user);
                MD5 md5hash = MD5.Create();

                byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(user.password));
                StringBuilder sBuilder = new StringBuilder();
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                user.password = sBuilder.ToString();
                user.firstName = user.firstName.ToUpper();
                user.lastName = user.lastName.ToUpper();
                var res = userRepository.Add(user);

                return res;
            }
            catch (Exception e)
            {
                Log.Error("user Post : " + e.Message + "||" + e.StackTrace);
                throw;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]User user)
        {
            Console.WriteLine(user);

            return userRepository.UpdateUser(user);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Console.WriteLine(id);
            return userRepository.DeleteById(id);
        }

    }
}
