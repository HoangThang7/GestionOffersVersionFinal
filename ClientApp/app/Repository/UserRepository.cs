using GestionOffers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    public class UserRepository : BaseRepository<User>
    {

        public UserRepository() : base(Context.Create())
        {

        }

        public User GetIdentity(string mail)
        {
            User identity = new User();

           

            identity = _context.User.Include("address").Include("provider").Where(u => u.mail == mail).FirstOrDefault();

            return identity;
        }


        public IEnumerable<User> GetListUser()
        {
            List<User> listUser = new List<User>();
         

            listUser = _context.User.Include("address").Include("provider").ToList();

            return listUser;
        }


        public bool UpdateUser(User user)
        {
            try
            {
                Console.WriteLine(user);

                User userUpdate = _context.User.Include("address").Include("provider").Where( t => t.Id == user.Id).FirstOrDefault();

                Console.WriteLine(userUpdate);

                userUpdate.firstName = user.firstName;
                userUpdate.lastName = user.lastName;
                userUpdate.mail = user.mail;
                userUpdate.numberTel = user.numberTel;
                userUpdate.password = user.password;
                userUpdate.type = user.type;
                userUpdate.address.street = user.address.street;
                userUpdate.address.zip = user.address.zip;
                userUpdate.address.city = user.address.city;
                userUpdate.address.country = user.address.country;
                userUpdate.address.region = user.address.region;

                _context.SaveChanges();


                return true;
            }
              catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                return false;
            }

        }

        

    }
}
