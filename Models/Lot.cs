using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class Lot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string code { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public double prix { get; set; }


        [ForeignKey("offerId")]
        public int? offerId { get; set; }
        public Offer offer { get; set; }

        public Lot()
        {

        }

    }
}
