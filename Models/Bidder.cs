using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class Bidder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public int tel { get; set; }

        [Required]
        public string fax { get; set; }

        [Required]
        public string domaine { get; set; }

        [Required]
        public string typeEnterprise { get; set; }

        public Address address { get; set; }

        public virtual ICollection<Plis> plis { get; set; }

        public virtual ICollection<Diffusion> diffusion { get; } = new List<Diffusion>();
 

        public Bidder()
        {

        }

        public Bidder(string firstName, string lastName,string email, int tel, string fax, string domaine, string type,Address address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.tel = tel;
            this.domaine = domaine;
            this.fax = fax;
            typeEnterprise = type;
            this.address = address;
            this.plis = new List<Plis>();
        }
    }
}
