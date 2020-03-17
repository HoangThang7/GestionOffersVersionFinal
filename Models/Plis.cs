using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class Plis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string code { get; set; }

        [Required]
        public string libelle { get; set; }

        [Required]
        public DateTime dateDepot { get; set; }

        [Required]
        public string typeDepot { get; set; }

        [ForeignKey("offerId")]
        public int offerId { get; set; }
        public Offer offer { get; set; }

        [ForeignKey("bidderId")]
        public int bidderId { get; set; }
        public Bidder bidder { get; set; }

        public virtual Depouillement depouillement { get; set; }

        public Plis()
        {

        }

        public Plis(int id, string code, string libelle, DateTime dateDepot, string typeDepot)
        {
            this.Id = id;
            this.code = code;
            this.libelle = libelle;
            this.dateDepot = dateDepot;
            this.typeDepot = typeDepot;
            depouillement = new Depouillement();

        }

        public Plis(string code, string libelle, DateTime dateDepot, string typeDepot)
        {
            this.code = code;
            this.libelle = libelle;
            this.dateDepot = dateDepot;
            this.typeDepot = typeDepot;
            depouillement = new Depouillement();
        }
    }
}
