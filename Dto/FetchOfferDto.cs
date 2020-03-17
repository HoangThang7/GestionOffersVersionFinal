using GestionOffer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Dto
{
    public class FetchOfferDto
    {


        public int id { get; set; }

        public string code { get; set; }

        public Categorie categorie { get; set; }

        public Direction direction { get; set; }

        public string etat { get; set; }

        public string intitule { get; set; }

        public string description { get; set; }

        public string placeDepot { get; set; }

        public DateTime dateLimit { get; set; }

        public string placeOpened { get; set; }

        public DateTime dateOpened { get; set; }

        public Commission commission { get; set; }

        public ICollection<FileContentResult> files { get; set; }

        public string manager { get; set; }

        public bool publish { get; set; }

        public ICollection<BidderDto> bidders { get; set; }


        public FetchOfferDto()
        {

        }

        public FetchOfferDto(int id, string code, string etat, string intitule, string description, string placeDepot, DateTime dateLimit, string placeOpened, DateTime dateOpened, string manager, bool publish)
        {
            this.id = id;
            this.code = code;
            this.etat = etat;
            this.intitule = intitule;
            this.description = description;
            this.placeDepot = placeDepot;
            this.placeOpened = placeOpened;
            this.dateLimit = dateLimit;
            this.dateOpened = dateOpened;
            this.manager = manager;
            this.publish = publish;
            files = new List<FileContentResult>();
            categorie = new Categorie();
            direction = new Direction();
            commission = new Commission();
            bidders = new List<BidderDto>();
        }

    }
}
