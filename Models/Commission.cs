using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class Commission
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string code { get; set; }

        [Required]
        public string libelle { get; set; }

        public virtual ICollection<Offer> offers { get; set; }

        public ICollection<Member> memberCommis { get; } = new List<Member>();

        public Commission()
        {

        }

        public Commission(string code, string libelle)
        {
            this.code = code;
            this.libelle = libelle;
           
        }
    }
}
