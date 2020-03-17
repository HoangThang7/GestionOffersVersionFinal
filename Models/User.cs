using GestionOffer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffers.Models
{
    public class User
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public  DateTime date { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string mail { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int numberTel { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        public Usertype type { get; set; }

        public virtual Address address { get; set; }

        public virtual Provider provider { get; set; }

        public ICollection<Member> member { get; } = new List<Member>();

        public User()
        {

        }


        public User(string firstName, string lastName, DateTime date, string mail, int tel, string password, Usertype usertype, Address address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.date = date;
            this.mail = mail;
            this.numberTel = tel;
            this.password = password;
            this.type = usertype;
            this.address = address;
        }

        public User(string firstName, string lastName, DateTime date, string mail, int tel, string password, Usertype usertype, Address address, Provider provider)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.date = date;
            this.mail = mail;
            this.numberTel = tel;
            this.password = password;
            this.type = usertype;
            this.address = address;
            this.provider = provider;
        }


    }
}
