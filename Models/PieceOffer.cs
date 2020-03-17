using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class PieceOffer
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }    

        [Required]
        public string type { get; set; }
        
        [Required]
        public DateTime dateCreation { get; set; }

        [Required]
        public string pathFile { get; set; }

        [ForeignKey("offerId")]
        public int offerId { get; set; }
        public Offer offer { get; set; }

        public PieceOffer()
        {

        }

    }
}
