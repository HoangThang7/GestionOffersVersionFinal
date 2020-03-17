using GestionOffer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffers.Models
{
    public class Address
    {
        [ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int?  AddressId { get; set; }

        [Required]
        public string street { get; set; }

        [Required]
        public int zip { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string region { get; set; }

        [Required]
        public string country { get; set; }

        [ForeignKey("bidderId")]
        public int? bidderId { get; set; }
        public Bidder bidder { get; set; }


        public Address() { }

        public Address(string street, int zip, string city, string region, string country ) {

            this.street = street;
            this.zip = zip;
            this.city = city;
            this.region = region;
            this.country = country;

        }
    }
}
