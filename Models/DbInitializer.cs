using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public static class DbInitializer 
    {
        public static string MD5Hash(string passw)
        {
            MD5 md5hash = MD5.Create();

            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(passw));
            StringBuilder sBuilder = new StringBuilder();
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            

            // Look for any students.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var date = new DateTime(1990-23-03);
            var address = new Address("Rue Stephenson 13", 1030, "Bruxelles", "Brabant", "Belgique");
            var user = new User("CAO", "Hoang Thang", date, "aksel@gmail.com", 0487562369, MD5Hash("Akselerenberk"), Usertype.Admin, address);

            var date1 = new DateTime(1990-23-03);
            var address1 = new Address("Rue Louize 14", 1000, "Bruxelles", "Brabant", "Belgique");
            var user1 = new User("CAO", "Hoang", date1, "caohoangthang7@gmail.com", 0487562369, MD5Hash("Hoangthang"), Usertype.Manager, address1);

            var date3 = new DateTime(1990-23-03);
            var address3 = new Address("Rue Louize 16", 1000, "Bruxelles", "Brabant", "Belgique");
            var user3 = new User("ANAIS", "Espinoza", date1, "anais@gmail.com", 0487562369, MD5Hash("Ninaespinoza"), Usertype.User, address1);

            Categorie categorie1 = new Categorie("CAT-25012", "Informatique et Reseau");
            Categorie categorie2 = new Categorie("CAT-23561", "Commerce");

            Direction direction1 = new Direction("DIR-125", "Informatique");
            Direction direction2 = new Direction("DIR-122", "Comptable");

            Provider provider = new Provider("Informatique", "ThangFax", "Freelance");
            var date2 = new DateTime(1990-225-03);
            var address2 = new Address("Rue St-Pierre 25", 1000, "Bruxelles", "Brabant", "Belgique");
            var user2 = new User("SAP", "303 Studio", date2, "ahmed@gmail.com", 048756234, MD5Hash("Ahmedarigui"), Usertype.Provider, address2, provider);
            
                     
            context.User.Add(user);
            context.User.Add(user1);
            context.User.Add(user2);
            context.User.Add(user3);
            context.Categorie.Add(categorie1);
            context.Categorie.Add(categorie2);
            context.Direction.Add(direction1);
            context.Direction.Add(direction2);
            

            context.SaveChanges();
        }
           
    }
}
