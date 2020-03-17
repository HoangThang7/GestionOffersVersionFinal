using GestionOffer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffers.Models
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {get; set; }

        [Required]
        public string code { get; set; }


        [Required]
        public string etat { get; set; }

        [Required]
        public string intitule { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string placeDepot { get; set; }

        [Required]
        public DateTime dateLimit { get; set; }

        [Required]
        public string placeOpened { get; set; }

        [Required]
        public DateTime dateOpened { get; set; }

        public string manager { get; set; }

        public DateTime dateCreation { get; set; }

        public bool publish { get; set; }

        [ForeignKey("categorieId")]
        public int  categorieId { get; set; }
        public Categorie categorie { get; set; }

        [ForeignKey("directionId")]
        public int directionId { get; set; }
        public Direction direction { get; set; }

        [ForeignKey("commissionId")]
        public int? commissionId { get; set; }
        public Commission commission { get; set; }


        public ICollection<Plis> plis { get; set; }

        public ICollection<Diffusion> diffusOffer { get;  } = new List<Diffusion>();

        public ICollection<PieceOffer> documents { get; set; } 

        public Offer() { }
    
        public Offer(string code, string intitule, string description, string placeDepot, DateTime dateLimit, string placeOpened, DateTime dateOpened, Categorie categorie, Direction direction, Commission commission)            
        {
            this.code = code;
            this.intitule = intitule;
            this.description = description;
            this.placeDepot = placeDepot;
            this.dateLimit = dateLimit;
            this.placeOpened = placeOpened;
            this.dateOpened = dateOpened;
            this.categorie = categorie;
            this.direction = direction;
            this.commission = commission;
        }
    }
}
