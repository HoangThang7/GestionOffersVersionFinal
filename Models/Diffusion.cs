using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class Diffusion
    {

        public int offerId { get; set; }

        public Offer offer { get; set; }

        public int bidderId { get; set; }

        public Bidder bidder { get; set; }

        public Diffusion()
        {

        }

        public Diffusion(Offer offer, Bidder bidder)
        {
            this.offer = offer;
            this.bidder = bidder;
        }
    }
}
